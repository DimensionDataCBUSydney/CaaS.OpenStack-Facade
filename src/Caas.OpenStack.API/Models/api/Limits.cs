// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Limits.cs" company="">
//   
// </copyright>
// <summary>
//   Collection of limits and rates
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.api
{
	/// <summary>	Collection of limits and rates </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class Limits
	{
		/// <summary>	Gets or sets the absolute limits. </summary>
		/// <value>	The absolute. </value>
		[DataMember(Name = "absolute")]
		public AbsoluteLimits Absolute { get; set; }

		/// <summary>	Gets or sets the rate collection </summary>
		/// <value>	The rate. </value>
		[DataMember(Name = "rate")]
		public Rate[] Rates { get; set; }
	}
}