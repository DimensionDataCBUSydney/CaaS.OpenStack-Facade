using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A flavour response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class FlavorResponse
	{
		/// <summary>	Gets or sets the flavour. </summary>
		/// <value>	The flavour. </value>
		[DataMember(Name = "flavor")]
		public Flavor Flavor { get; set; }
	}
}