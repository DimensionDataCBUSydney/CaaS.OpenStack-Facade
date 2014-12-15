using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Caas.OpenStack.API.Models.server
{
    [DataContract]
    public class Flavor
    {
        public Flavor()
        {
            Links = new RestLink[]{
                new RestLink("http://openstack.example.com/openstack/flavors/1", RestLink.Bookmark)
            };
        }

        [DataMember(Name = "id")]
        public int Id = 1; // No mapping to flavors in CaaS API

        [DataMember(Name = "links")]
        public RestLink[] Links { get; set; }
    }
}