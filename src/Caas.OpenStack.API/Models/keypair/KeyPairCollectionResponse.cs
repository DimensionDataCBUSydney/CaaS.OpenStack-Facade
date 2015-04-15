using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.keypair
{
	/// <summary>	A key pair collection response. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	[DataContract]
	public class KeyPairCollectionResponse
	{
		/// <summary>	Gets or sets the key pairs. </summary>
		/// <value>	The key pairs. </value>
		[DataMember(Name = "keypairs")]
		public KeyPairDetailResponse[] KeyPairs { get; set; } 
	}
}