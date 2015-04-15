using System.Net.Http;
using System.Runtime.Serialization;
using Caas.OpenStack.API.UriFactories;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A flavour. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class FlavorDetail : Flavor
	{
		/// <summary>	Gets or sets a value indicating whether this object is disabled. </summary>
		/// <value>	true if disabled, false if not. </value>
		[DataMember(Name = "disabled")]
		public bool Disabled { get; set; }

		/// <summary>	Gets or sets the disk. </summary>
		/// <value>	The disk. </value>
		[DataMember(Name = "disk")]
		public int Disk { get; set; }

		/// <summary>	Gets or sets the ephemeral. </summary>
		/// <value>	The ephemeral. </value>
		[DataMember(Name = "ephemeral")]
		public int Ephemeral { get; set; }

		/// <summary>	Gets or sets a value indicating whether this object is public. </summary>
		/// <value>	true if this object is public, false if not. </value>
		[DataMember(Name = "flavor-access:is_public")]
		public bool IsPublic { get; set; }

		/// <summary>	Gets or sets the ram. </summary>
		/// <value>	The ram. </value>
		[DataMember(Name = "ram")]
		public int Ram { get; set; }

		/// <summary>	Gets or sets the swap. </summary>
		/// <value>	The swap. </value>
		[DataMember(Name = "swap")]
		public int Swap { get; set; }

		/// <summary>	Gets or sets the VCPU's. </summary>
		/// <value>	The VCPU's. </value>
		[DataMember(Name = "vcpus")]
		// ReSharper disable once InconsistentNaming
		public int VCPUs { get; set; }

		/// <summary>	Get a default flavor. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="request"> 	The request. </param>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	A Flavor. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Models.server.Flavor.GenerateDefaultFlavor(HttpRequestMessage,string)"/>
		public new static FlavorDetail GenerateDefaultFlavor(HttpRequestMessage request, string tenantId)
		{
			return new FlavorDetail
			{
				Disabled = false,
				Disk = 50,
				Ephemeral = 0,
				Id = DefaultFlavorId,
				IsPublic = true,
				Links = new[]
				{
					new RestLink(ServerUriFactory.GetFlavorUri(request.RequestUri.Host, tenantId, DefaultFlavorId), RestLink.Self)
				},
				Name = DefaultFlavorName,
				Ram = 1024,
				Swap = 1024,
				VCPUs = 1
			};
		}
	}
}