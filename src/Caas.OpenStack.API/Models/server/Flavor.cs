using System.Net.Http;
using System.Runtime.Serialization;
using Caas.OpenStack.API.UriFactories;

namespace Caas.OpenStack.API.Models.server
{
    /// <summary>	A flavour. </summary>
    /// <remarks>	Anthony, 4/13/2015. </remarks>
    [DataContract]
    public class Flavor
    {
	    /// <summary>	The default flavor identifier. </summary>
	    public const int DefaultFlavorId = 1;

	    /// <summary>	The default flavor name. </summary>
	    public const string DefaultFlavorName = "Default";

        /// <summary>	No mapping to flavours in CaaS API. </summary>
        /// <value>	The identifier. </value>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>	Gets or sets the links. </summary>
        /// <value>	The links. </value>
        [DataMember(Name = "links")]
        public RestLink[] Links { get; set; }

		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }

	    /// <summary>	Get a default flavor. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <param name="request"> 	The request. </param>
	    /// <param name="tenantId">	Identifier for the tenant. </param>
	    /// <returns>	A Flavor. </returns>
	    public static Flavor GenerateDefaultFlavor(HttpRequestMessage request, string tenantId)
	    {
		    return new Flavor
		    {
			    Id = DefaultFlavorId,
			    Links = new[]
			    {
				    new RestLink(ServerUriFactory.GetFlavorUri(request.RequestUri.Host, tenantId, DefaultFlavorId), RestLink.Self)
			    },
				Name = DefaultFlavorName
		    };
	    }
    }
}