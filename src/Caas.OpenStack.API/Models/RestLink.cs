// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestLink.cs" company="">
//   
// </copyright>
// <summary>
//   A REST link.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models
{
	/// <summary>	A REST link. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class RestLink
	{
		/// <summary>	The self. </summary>
		public const string Self = "self";

		/// <summary>	The bookmark. </summary>
		public const string Bookmark = "bookmark";

		/// <summary>
		/// Initialises a new instance of the <see cref="RestLink"/> class. 
		/// Initializes a new instance of the RestLink class. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="href">
		/// 	The reference. 
		/// </param>
		/// <param name="rel">
		/// 	The relative. 
		/// </param>
		public RestLink(string href, string rel)
		{
			Href = href;
			Rel = rel;
		}

		/// <summary>	Gets or sets the reference. </summary>
		/// <value>	The reference. </value>
		[DataMember(Name = "href")]
		public string Href { get; set; }

		/// <summary>	Gets or sets the relative link name. </summary>
		/// <value>	The relative. </value>
		[DataMember(Name = "rel")]
		public string Rel { get; set; }
	}
}