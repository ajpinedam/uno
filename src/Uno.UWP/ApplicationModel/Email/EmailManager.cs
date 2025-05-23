using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;

namespace Windows.ApplicationModel.Email
{
	public partial class EmailManager
	{
		public static IAsyncAction ShowComposeNewEmailAsync(EmailMessage message)
		{
#if __ANDROID__ || __APPLE_UIKIT__
			// Use platform-specific implementation where supported
			return ShowComposeNewEmailInternalAsync(message).AsAsyncAction();
#else
			// Otherwise fall back to mailto:
			return ComposeEmailWithMailtoUriAsync(message).AsAsyncAction();
#endif
		}

#if !__ANDROID__
		private static async Task ComposeEmailWithMailtoUriAsync(EmailMessage message)
		{
			var uri = message.ToMailtoUri();
			await Launcher.LaunchUriAsync(uri);
		}
#endif
	}
}
