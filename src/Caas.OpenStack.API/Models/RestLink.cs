using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models
{
	[DataContract]
	public class RestLink
	{
		public const string Self = "self";
		public const string Bookmark = "bookmark";

		public RestLink(string href, string rel)
		{
			Href = href;
			Rel = rel;
		}

		[DataMember(Name = "href")]
		public string Href { get; set; }

		[DataMember(Name = "rel")]
		public string Rel { get; set; }
	}
}