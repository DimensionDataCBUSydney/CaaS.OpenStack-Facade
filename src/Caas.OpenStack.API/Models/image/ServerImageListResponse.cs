using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	/// <summary>	A server image list response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ServerImageListResponse
	{
		/// <summary>	Gets or sets the images. </summary>
		/// <value>	The images. </value>
		[DataMember(Name = "images")]
		public ServerImage[] Images { get; set; }
	}
}