using System;

namespace Caas.OpenStack.API
{
	public static class UrlGenerator
	{
		public static string GetImageUri(string tenantId, string imageId)
		{
			return String.Format(
				"{0}{1}/{2}/images/{3}",
				ConfigurationHelpers.GetBaseUrl(),
				Constants.CurrentApiVersion,
				tenantId,
				imageId
				);
		}
	}
}