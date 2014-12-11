using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Caas.OpenStack.API.Models.api
{
    [DataContract]
    public class ExtensionList
    {
        // TODO : implement correct class when these are supported.
        [DataMember(Name = "values")]
        public string[] Values { get; set; }
    }
}