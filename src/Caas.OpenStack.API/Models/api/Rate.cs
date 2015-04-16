// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rate.cs" company="">
//   
// </copyright>
// <summary>
//   A rate limit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.api
{
	/// <summary>	A rate limit. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class Rate
	{
		/// <summary>	Gets or sets the limits. </summary>
		/// <value>	The limits. </value>
		[DataMember(Name = "limit")]
		public Limit[] Limits { get; set; }

		/// <summary>	Gets or sets the Regular Expression. </summary>
		/// <value>	The Regular Expression. </value>
		[DataMember(Name = "regex")]
		public string Regex { get; set; }

		/// <summary>	Gets or sets URI of the document. </summary>
		/// <value>	The URI. </value>
		[DataMember(Name = "uri")]
		public string Uri { get; set; }
	}
}