using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.serviceCatalog
{
	/// <summary>	An endpoint. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class Endpoint
	{
		/// <summary>	Gets or sets URL of the document. </summary>
		/// <value>	The URL. </value>
		[DataMember(Name = "url")]
		public string Url { get; set; }

		/// <summary>	Gets or sets the region. </summary>
		/// <value>	The region. </value>
		[DataMember(Name = "region")]
		public string Region { get; set; }

		/// <summary>	Gets or sets URL of the internal. </summary>
		/// <value>	The internal URL. </value>
		[DataMember(Name = "internalURL")]
		public string InternalUrl { get; set; }

		/// <summary>	Gets or sets the identifier. </summary>
		/// <value>	The identifier. </value>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>	Gets or sets URL of the public. </summary>
		/// <value>	The public URL. </value>
		[DataMember(Name = "publicURL")]
		public string PublicUrl { get; set; }
	}
}