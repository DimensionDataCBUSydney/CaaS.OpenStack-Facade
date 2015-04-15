using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.keypair
{
	/// <summary>	A keypair. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	[DataContract]
	public class Keypair
	{
		/// <summary>	Gets or sets the fingerprint. </summary>
		/// <value>	The fingerprint. </value>
		[DataMember(Name = "fingerprint")]
		public string Fingerprint { get; set; }

		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>	Gets or sets the public key. </summary>
		/// <value>	The public key. </value>
		[DataMember(Name = "public_key")]
		public string PublicKey { get; set; }
	}
}