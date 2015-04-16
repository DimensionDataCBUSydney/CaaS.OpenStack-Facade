// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerImageResponse.cs" company="">
//   
// </copyright>
// <summary>
//   A server image response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	/// <summary>	A server image response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ServerImageResponse
	{
		/// <summary>	Gets or sets the image. </summary>
		/// <value>	The image. </value>
		[DataMember(Name = "image")]
		public ServerImage Image { get; set; }
	}
}