// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseServerResponse.cs" company="">
//   
// </copyright>
// <summary>
//   A base server response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A base server response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class BaseServerResponse
	{
		/// <summary>	Gets or sets the servers. </summary>
		/// <value>	The servers. </value>
		[DataMember(Name = "servers")]
		public BaseServer[] Servers { get; set; }
	}
}