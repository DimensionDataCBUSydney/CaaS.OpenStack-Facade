using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.serviceCatalog
{
	/// <summary>	A service catalogue entry. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ServiceCatalogEntry
	{
		/// <summary>	Gets or sets the endpoints. </summary>
		/// <value>	The endpoints. </value>
		[DataMember(Name = "endpoints")]
		public Endpoint[] Endpoints { get; set; }

		/// <summary>	Gets or sets the endpoints links. </summary>
		/// <value>	The endpoints links. </value>
		[DataMember(Name = "endpoints_links")]
		public string[] EndpointsLinks { get; set; }

        /// <summary>	Gets or sets the endpoint type string. </summary>
        /// <value>	The endpoint type string. </value>
        [DataMember(Name = "type")]
        public string EndpointTypeString 
		{
            get
            {
                return Type.ToString();
            }
            set
			{
                EndpointType newtype;
                if (!Enum.TryParse(value, out newtype))
                {
                    Type = newtype;
                }
            } 
        }

		/// <summary>	Gets or sets the type. </summary>
		/// <value>	The type. </value>
		public EndpointType Type { get; set; }

		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}