using Caas.OpenStack.API.Models.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Caas.OpenStack.API.Controllers
{
    public class ExtensionsController : ApiController
    {
        [Route(Constants.CurrentApiVersion+"/{tenantId}/extensions")]
        public ExtensionResponse GetExtensions(string tenantId)
        {
            return new ExtensionResponse()
            {
                Extensions = new ExtensionList()
                {
                    Values = new string[] { }
                }
            };
        }
    }
}
