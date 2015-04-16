// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerDetailResponse.cs" company="">
//   
// </copyright>
// <summary>
//   A server detail response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
    /// <summary>	A server detail response. </summary>
    /// <remarks>	Anthony, 4/13/2015. </remarks>
    [DataContract]
    public class ServerDetailResponse
    {
        /// <summary>	Gets or sets the server. </summary>
        /// <value>	The server. </value>
        [DataMember(Name = "server")]
        public ServerDetail Server { get; set; }
    }
}