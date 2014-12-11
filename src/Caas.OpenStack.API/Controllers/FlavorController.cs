using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Caas.OpenStack.API.Controllers
{
	[Authorize]
	[RoutePrefix(Constants.CurrentApiVersion)]
    public class FlavorController : ApiController
    {
	    [Route("{tenant_id}/flavors")]
	    public string GetFlavors(string tenant_id)
	    {
		    return "example";
	    }
    }
}
