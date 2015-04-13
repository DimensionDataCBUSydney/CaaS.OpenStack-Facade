using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.api
{
	/// <summary>	An extension collection response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ExtensionCollectionResponse
	{
		/// <summary>	Gets or sets the extensions. </summary>
		/// <value>	The extensions. </value>
		[DataMember(Name = "extensions")]
		public Extension[] Extensions { get; set; }
	}
}