// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Limit.cs" company="">
//   
// </copyright>
// <summary>
//   A limit model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.api
{
	/// <summary>	A limit model. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class Limit
	{
		/// <summary>	Gets or sets the next available limit. </summary>
		/// <value>	The next available limit. </value>
		[DataMember(Name = "next-available")]
		public string NextAvailable { get; set; }

		/// <summary>	Gets or sets the remaining. </summary>
		/// <value>	The remaining. </value>
		[DataMember(Name = "remaining")]
		public int Remaining { get; set; }

		/// <summary>	Gets or sets the unit. </summary>
		/// <value>	The unit. </value>
		[DataMember(Name = "unit")]
		public string Unit { get; set; }

		/// <summary>	Gets or sets the value. </summary>
		/// <value>	The value. </value>
		[DataMember(Name = "value")]
		public int Value { get; set; }

		/// <summary>	Gets or sets the verb. </summary>
		/// <value>	The verb. </value>
		[DataMember(Name = "verb")]
		public string Verb { get; set; }
	}
}