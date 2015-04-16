// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlavorCollection.cs" company="">
//   
// </copyright>
// <summary>
//   Collection of flavours.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	Collection of flavours. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class FlavorCollection
	{
		/// <summary>	Gets or sets the flavours. </summary>
		/// <value>	The flavours. </value>
		[DataMember(Name = "flavors")]
		public Flavor[] Flavors { get; set; }
	}
}