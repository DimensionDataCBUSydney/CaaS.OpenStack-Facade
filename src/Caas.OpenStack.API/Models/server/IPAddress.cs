// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPAddress.cs" company="">
//   
// </copyright>
// <summary>
//   An IP address.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	An IP address. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class IpAddress
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="IpAddress"/> class. 
		/// Initializes a new instance of the IP Address class. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="address">
		/// 	The address. 
		/// </param>
		public IpAddress(string address)
		{
			Address = address;
			Version = 4;
		}

		/// <summary>	Gets or sets the address. </summary>
		/// <value>	The address. </value>
		[DataMember(Name = "addr")]
		public string Address { get; set; }

		/// <summary>	Gets or sets the version. </summary>
		/// <value>	The version. </value>
		[DataMember(Name = "version")]
		public int Version { get; set; }
	}
}