// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlavorDetailResponse.cs" company="">
//   
// </copyright>
// <summary>
//   A flavour response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A flavour response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class FlavorDetailResponse
{
	/// <summary>	Gets or sets the flavour. </summary>
	/// <value>	The flavour. </value>
	[DataMember(Name = "flavor")]
	public FlavorDetail Flavor { get; set; }
}
}