using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Caas.OpenStack.API.Models.api
{
    [DataContract]
    public class ExtensionResponse
    {
        [DataMember(Name = "extensions")]
        public ExtensionList Extensions { get; set; }
    }
}