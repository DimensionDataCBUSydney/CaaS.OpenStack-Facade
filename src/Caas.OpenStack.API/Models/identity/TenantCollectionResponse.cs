// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TenantCollectionResponse.cs" company="">
//   
// </copyright>
// <summary>
//   A tenant collection response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.identity
{
	/// <summary>	A tenant collection response. </summary>
	/// <remarks>	Anthony, 4/16/2015. </remarks>
	[DataContract]
	public class TenantCollectionResponse
	{
		/// <summary>	Gets or sets the tenants. </summary>
		/// <value>	The tenants. </value>
		[DataMember(Name = "tenants")]
		public List<Tenant> Tenants { get; set; } 

		/// <summary>	Gets or sets the tenants links. </summary>
		/// <value>	The tenants links. </value>
		[DataMember(Name = "tenants_links")]
		public RestLink[] TenantsLinks { get; set; }
	}
}