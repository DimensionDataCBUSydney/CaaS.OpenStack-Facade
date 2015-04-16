// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TenantResponse.cs" company="">
//   
// </copyright>
// <summary>
//   A tenant response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.identity
{
	/// <summary>	A tenant response. </summary>
	/// <remarks>	Anthony, 4/16/2015. </remarks>
	[DataContract]
	public class TenantResponse
	{
		/// <summary>	Gets or sets the tenant. </summary>
		/// <value>	The tenant. </value>
		[DataMember(Name = "tenant")]
		public Tenant Tenant { get; set; }
	}
}