using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
    [DataContract]
    public class ServerDetailResponse
    {
        [DataMember(Name = "server")]
        public ServerDetail Server { get; set; }
    }
}