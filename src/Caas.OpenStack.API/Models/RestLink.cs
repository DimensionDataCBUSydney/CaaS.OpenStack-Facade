using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models
{
	[DataContract]
	public class RestLink
	{
		public const string Self = "self";

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