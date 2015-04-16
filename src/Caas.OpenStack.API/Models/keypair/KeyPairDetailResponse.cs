// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyPairDetailResponse.cs" company="">
//   
// </copyright>
// <summary>
//   A key pair detail response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.keypair
{
	/// <summary>	A key pair detail response. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	[DataContract]
	public class KeyPairDetailResponse
	{
		/// <summary>	Gets or sets the key. </summary>
		/// <value>	The key. </value>
		[DataMember(Name = "keypair")]
		public Keypair Key { get; set; }
	}
}