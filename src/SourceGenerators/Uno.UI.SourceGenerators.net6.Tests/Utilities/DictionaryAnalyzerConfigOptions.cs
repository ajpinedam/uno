﻿using Microsoft.CodeAnalysis.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Uno.UI.SourceGenerators.Tests;

internal sealed class DictionaryAnalyzerConfigOptions : AnalyzerConfigOptions
{
    private Dictionary<string, string> Properties { get; }

    public DictionaryAnalyzerConfigOptions(Dictionary<string, string> properties)
    {
        Properties = properties;
    }

	public override bool TryGetValue(string key, /*[NotNullWhen(true)] [MaybeNullWhen(false)]*/ out string value)
	{
        return Properties.TryGetValue(key, out value!);
    }
}