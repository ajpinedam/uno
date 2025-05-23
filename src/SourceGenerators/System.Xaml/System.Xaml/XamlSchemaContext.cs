//
// Copyright (C) 2010 Novell Inc. http://novell.com
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// History:
// - 2021/02/21 (jerome@platform.uno): Adjust for hard link to AppDomain.AssemblyLoad
// - 2021/11/28 (jerome@platform.uno): Disable assembly loading for Uno's as loaded types are never used.

// #define SUPPORTS_LOAD_ASSEMBLIES

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;
using Uno.Xaml.Schema;

using Pair = System.Collections.Generic.KeyValuePair<string,string>;

namespace Uno.Xaml
{
	// This type caches assembly attribute search results. To do this,
	// it registers AssemblyLoaded event on CurrentDomain when it should
	// reflect dynamic in-scope asemblies.
	// It should be released at finalizer.
	[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Types manipulated here have been marked earlier")]
	[UnconditionalSuppressMessage("Trimming", "IL2055", Justification = "Types manipulated here have been marked earlier")]
	public class XamlSchemaContext
	{
		private static readonly char[] _semicolonArray = new char[] { ';' };
		public XamlSchemaContext ()
			: this (null, null)
		{
		}

		public XamlSchemaContext (IEnumerable<Assembly> referenceAssemblies)
			: this (referenceAssemblies, null)
		{
		}

		public XamlSchemaContext (XamlSchemaContextSettings settings)
			: this (null, settings)
		{
		}

		public XamlSchemaContext (IEnumerable<Assembly> referenceAssemblies, XamlSchemaContextSettings settings)
		{
			if (referenceAssemblies != null)
				reference_assemblies = new List<Assembly>(referenceAssemblies);
			else
			{
				RegisterAssemblyLoaded();
			}

			if (settings == null)
				return;

			FullyQualifyAssemblyNamesInClrNamespaces = settings.FullyQualifyAssemblyNamesInClrNamespaces;
			SupportMarkupExtensionsWithDuplicateArity = settings.SupportMarkupExtensionsWithDuplicateArity;
		}

		private void RegisterAssemblyLoaded()
		{
#if SUPPORTS_LOAD_ASSEMBLIES
			var that = new WeakReference<XamlSchemaContext>(this);

			void Hook(object o, AssemblyLoadEventArgs e)
			{
				if (that.TryGetTarget(out var target))
				{
					target.OnAssemblyLoaded(o, e);
				}
				else
				{
					AppDomain.CurrentDomain.AssemblyLoad -= Hook;
				}
			}

			// Abstract away the use of the Hool method, so that it can be called
			// from the finalizer.
			unhookAssemblyLoad = () => AppDomain.CurrentDomain.AssemblyLoad -= Hook;

			// Register the Hook method to the AssemblyLoad event, so there's no
			// hard link between "this" and the AssemblyLoad event delegate.
			AppDomain.CurrentDomain.AssemblyLoad += Hook;
#endif
		}

#if SUPPORTS_LOAD_ASSEMBLIES
		~XamlSchemaContext ()
		{
			if (reference_assemblies == null)
				unhookAssemblyLoad?.Invoke();
		}
#endif

		IList<Assembly> reference_assemblies;

		// assembly attribute caches
		Dictionary<string,string> xaml_nss;
		Dictionary<string,string> prefixes;
		Dictionary<string,string> compat_nss;
		Dictionary<string,List<XamlType>> all_xaml_types;
		XamlType [] empty_xaml_types = Array.Empty<XamlType>();
		List<XamlType> run_time_types = new List<XamlType> ();
		object gate = new object();
#if SUPPORTS_LOAD_ASSEMBLIES
		Action unhookAssemblyLoad;
#endif

		public bool FullyQualifyAssemblyNamesInClrNamespaces { get; private set; }

		public IList<Assembly> ReferenceAssemblies {
			get { return reference_assemblies; }
		}

		IEnumerable<Assembly> AssembliesInScope {
			get { return reference_assemblies ?? AppDomain.CurrentDomain.GetAssemblies (); }
		}

		public bool SupportMarkupExtensionsWithDuplicateArity { get; private set; }

		internal string GetXamlNamespace (string clrNamespace)
		{
			lock (gate)
			{
				if (clrNamespace == null) // could happen on nested generic type (see bug #680385-comment#4). Not sure if null is correct though.
					return null;
				if (xaml_nss == null) // fill it first
					GetAllXamlNamespaces();
				string ret;
				return xaml_nss.TryGetValue(clrNamespace, out ret) ? ret : null;
			}
		}

		public virtual IEnumerable<string> GetAllXamlNamespaces ()
		{
			lock (gate)
			{
				if (xaml_nss == null)
				{
					xaml_nss = new Dictionary<string, string>();
					foreach (var ass in AssembliesInScope)
						FillXamlNamespaces(ass);
				}
				return xaml_nss.Values.Distinct();
			}
		}

		public virtual ICollection<XamlType> GetAllXamlTypes (string xamlNamespace)
		{
			lock (gate)
			{
				if (xamlNamespace == null)
					throw new ArgumentNullException("xamlNamespace");
				if (all_xaml_types == null)
				{
					all_xaml_types = new Dictionary<string, List<XamlType>>();
					foreach (var ass in AssembliesInScope)
						FillAllXamlTypes(ass);
				}

				List<XamlType> l;
				if (all_xaml_types.TryGetValue(xamlNamespace, out l))
					return l;
				else
					return empty_xaml_types;
			}
		}

		public virtual string GetPreferredPrefix (string xmlns)
		{
			lock (gate)
			{
				if (xmlns == null)
					throw new ArgumentNullException("xmlns");
				if (xmlns == XamlLanguage.Xaml2006Namespace)
					return "x";
				if (prefixes == null)
				{
					prefixes = new Dictionary<string, string>();
					foreach (var ass in AssembliesInScope)
						FillPrefixes(ass);
				}
				string ret;
				return prefixes.TryGetValue(xmlns, out ret) ? ret : "p"; // default
			}
		}

		protected internal XamlValueConverter<TConverterBase> GetValueConverter<TConverterBase> (Type converterType, XamlType targetType)
			where TConverterBase : class
		{
			return new XamlValueConverter<TConverterBase> (converterType, targetType);
		}
		
		Dictionary<Pair,XamlDirective> xaml_directives = new Dictionary<Pair,XamlDirective> ();
		
		public virtual XamlDirective GetXamlDirective (string xamlNamespace, string name)
		{
			lock (gate)
			{

				XamlDirective t;
				var p = new Pair(xamlNamespace, name);
				if (!xaml_directives.TryGetValue(p, out t))
				{
					t = new XamlDirective(xamlNamespace, name);
					xaml_directives.Add(p, t);
				}
				return t;
			}
		}
		
		public virtual XamlType GetXamlType (Type type)
		{
			lock (gate)
			{
				XamlType xt = run_time_types.FirstOrDefault(t => t.UnderlyingType == type);
				if (xt == null)
					foreach (var ns in GetAllXamlNamespaces())
						if ((xt = GetAllXamlTypes(ns).FirstOrDefault(t => t.UnderlyingType == type)) != null)
							break;
				if (xt == null)
				{
					xt = new XamlType(type, this);
					run_time_types.Add(xt);
				}
				return xt;
			}
		}
		
		public XamlType GetXamlType (XamlTypeName xamlTypeName)
		{
			lock (gate)
			{
				if (xamlTypeName == null)
					throw new ArgumentNullException("xamlTypeName");

				var n = xamlTypeName;
				if (n.TypeArguments.Count == 0) // non-generic
					return GetXamlType(n.Namespace, n.Name);

				// generic
				XamlType[] typeArgs = new XamlType[n.TypeArguments.Count];
				for (int i = 0; i < typeArgs.Length; i++)
					typeArgs[i] = GetXamlType(n.TypeArguments[i]);
				return GetXamlType(n.Namespace, n.Name, typeArgs);
			}
		}
		
		protected internal virtual XamlType GetXamlType (string xamlNamespace, string name, params XamlType [] typeArguments)
		{
			lock (gate)
			{
				string dummy;
				if (TryGetCompatibleXamlNamespace(xamlNamespace, out dummy))
					xamlNamespace = dummy;

				XamlType ret;
				if (xamlNamespace == XamlLanguage.Xaml2006Namespace)
				{
					ret = XamlLanguage.SpecialNames.Find(name, xamlNamespace);
					if (ret == null)
						ret = XamlLanguage.AllTypes.FirstOrDefault(t => TypeMatches(t, xamlNamespace, name, typeArguments));
					if (ret != null)
						return ret;
				}
				ret = run_time_types.FirstOrDefault(t => TypeMatches(t, xamlNamespace, name, typeArguments));
				if (ret == null)
					ret = GetAllXamlTypes(xamlNamespace).FirstOrDefault(t => TypeMatches(t, xamlNamespace, name, typeArguments));

				if (reference_assemblies == null)
				{
					var type = ResolveXamlTypeName(xamlNamespace, name, typeArguments);
					if (type != null)
						ret = GetXamlType(type);
				}

				// If the type was not found, it just returns null.
				return ret;
			}
		}

		bool TypeMatches (XamlType t, string ns, string name, XamlType [] typeArgs)
		{
			if (t.PreferredXamlNamespace == ns && t.Name == name && t.TypeArguments.ListEquals (typeArgs))
				return true;
			if (t.IsMarkupExtension)
				return t.PreferredXamlNamespace == ns && t.Name.Substring (0, Math.Max(0, t.Name.Length - 9)) == name && t.TypeArguments.ListEquals (typeArgs);
			else
				return false;
		}

		protected internal virtual Assembly OnAssemblyResolve (string assemblyName)
		{
#pragma warning disable CS0618 // Type or member is obsolete
			return Assembly.LoadWithPartialName (assemblyName);
#pragma warning restore CS0618 // Type or member is obsolete
		}

		public virtual bool TryGetCompatibleXamlNamespace (string xamlNamespace, out string compatibleNamespace)
		{
			lock (gate)
			{
				if (xamlNamespace == null)
					throw new ArgumentNullException("xamlNamespace");
				if (compat_nss == null)
				{
					compat_nss = new Dictionary<string, string>();
					foreach (var ass in AssembliesInScope)
						FillCompatibilities(ass);
				}
				return compat_nss.TryGetValue(xamlNamespace, out compatibleNamespace);
			}
		}

#if SUPPORTS_LOAD_ASSEMBLIES
		void OnAssemblyLoaded (object o, AssemblyLoadEventArgs e)
		{
			if (reference_assemblies != null)
				return; // do nothing

			if (xaml_nss != null)
				FillXamlNamespaces (e.LoadedAssembly);
			if (prefixes != null)
				FillPrefixes (e.LoadedAssembly);
			if (compat_nss != null)
				FillCompatibilities (e.LoadedAssembly);
			if (all_xaml_types != null)
				FillAllXamlTypes (e.LoadedAssembly);
		}
#endif

		// cache updater methods
		void FillXamlNamespaces (Assembly ass)
		{
			foreach (XmlnsDefinitionAttribute xda in ass.GetCustomAttributes (typeof (XmlnsDefinitionAttribute), false))
				xaml_nss.Add (xda.ClrNamespace, xda.XmlNamespace);
		}
		
		void FillPrefixes (Assembly ass)
		{
			foreach (XmlnsPrefixAttribute xpa in ass.GetCustomAttributes (typeof (XmlnsPrefixAttribute), false))
				prefixes.Add (xpa.XmlNamespace, xpa.Prefix);
		}
		
		void FillCompatibilities (Assembly ass)
		{
			foreach (XmlnsCompatibleWithAttribute xca in ass.GetCustomAttributes (typeof (XmlnsCompatibleWithAttribute), false))
				compat_nss.Add (xca.OldNamespace, xca.NewNamespace);
		}

		void FillAllXamlTypes (Assembly ass)
		{
			foreach (XmlnsDefinitionAttribute xda in ass.GetCustomAttributes (typeof (XmlnsDefinitionAttribute), false)) {
				var l = all_xaml_types.FirstOrDefault (p => p.Key == xda.XmlNamespace).Value;
				if (l == null) {
					l = new List<XamlType> ();
					all_xaml_types.Add (xda.XmlNamespace, l);
				}
				foreach (var t in ass.GetTypes ())
					if (t.Namespace == xda.ClrNamespace)
						l.Add (GetXamlType (t));
			}
		}

		// XamlTypeName -> Type resolution

		static readonly int clr_ns_len = "clr-namespace:".Length;
		static readonly int clr_ass_len = "assembly=".Length;

		Type ResolveXamlTypeName (string xmlNamespace, string xmlLocalName, IList<XamlType> typeArguments)
		{
			string ns = xmlNamespace;
			string name = xmlLocalName;

			if (ns == XamlLanguage.Xaml2006Namespace) {
				var xt = XamlLanguage.SpecialNames.Find (name, ns);
				if (xt == null)
					xt = XamlLanguage.AllTypes.FirstOrDefault (t => t.Name == xmlLocalName);
				if (xt == null)
					throw new FormatException (string.Format (CultureInfo.InvariantCulture, "There is no type '{0}' in XAML namespace", name));
				return xt.UnderlyingType;
			}
			else if (!ns.StartsWith ("clr-namespace:", StringComparison.Ordinal))
				return null;

			Type [] genArgs = null;
			if (typeArguments != null && typeArguments.Count > 0) {
				genArgs = (from t in typeArguments select t.UnderlyingType).ToArray ();
				if (genArgs.Any (t => t == null))
					return null;
			}

			// convert xml namespace to clr namespace and assembly
			string [] split = ns.Split (_semicolonArray);
			if (split.Length != 2 || split [0].Length < clr_ns_len || split [1].Length <= clr_ass_len)
				throw new XamlParseException (string.Format (CultureInfo.InvariantCulture, "Cannot resolve runtime namespace from XML namespace '{0}'", ns));
			string tns = split [0].Substring (clr_ns_len);
			string aname = split [1].Substring (clr_ass_len);

			string taqn = GetTypeName (tns, name, genArgs);
			var ass = OnAssemblyResolve (aname);
			// MarkupExtension type could omit "Extension" part in XML name.
			Type ret = ass == null ? null : ass.GetType (taqn) ?? ass.GetType (GetTypeName (tns, name + "Extension", genArgs));
			if (ret == null)
				throw new XamlParseException (string.Format (CultureInfo.InvariantCulture, "Cannot resolve runtime type from XML namespace '{0}', local name '{1}' with {2} type arguments ({3})", ns, name, typeArguments !=null ? typeArguments.Count : 0, taqn));
			return genArgs == null ? ret : ret.MakeGenericType (genArgs);
		}
		
		static string GetTypeName (string tns, string name, Type [] genArgs)
		{
			string tfn = tns.Length > 0 ? tns + '.' + name : name;
			if (genArgs != null)
				tfn += "`" + genArgs.Length;
			return tfn;
		}
	}
}
