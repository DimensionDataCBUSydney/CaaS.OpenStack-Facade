using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.serviceCatalog
{
	[DataContract]
	public class ServiceCatalogEntry
	{
		[DataMember(Name = "endpoints")]
		public Endpoint[] Endpoints { get; set; }

		[DataMember(Name = "endpoints_links")]
		public string[] EndpointsLinks { get; set; }

        [DataMember(Name = "type")]
        public string EndpointTypeString {
            get
            {
                return Type.ToString();
            }
            set{
                EndpointType newtype;
                if (!Enum.TryParse<EndpointType>(value, out newtype))
                {
                    Type = newtype;
                }
            } 
        }

		public EndpointType Type { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}