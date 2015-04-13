using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	/// <summary>	A base server image. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class BaseServerImage
	{
		/// <summary>	Gets or sets the identifier. </summary>
		/// <value>	The identifier. </value>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>	Gets or sets the links. </summary>
		/// <value>	The links. </value>
		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }

		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}