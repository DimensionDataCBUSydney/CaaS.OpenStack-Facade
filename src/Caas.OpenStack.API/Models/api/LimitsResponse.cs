using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.api
{
	/// <summary>	The limits response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public class LimitsResponse
	{
		/// <summary>	Gets or sets the limits. </summary>
		/// <value>	The limits. </value>
		[DataMember(Name = "limits")]
		public Limits Limits { get; set; }
	}
}