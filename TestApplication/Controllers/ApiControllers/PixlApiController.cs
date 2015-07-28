using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestApplication.Services;

namespace TestApplication.Controllers.ApiControllers
{
    public class PixlApiController : ApiController
    {
        private readonly PixlService pixlService = PixlService.Instance;

        /// <summary>
        /// Get a list of orders
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JObject> GetOrders(string accessToken, int skip, int take)
        {
            return JObject.Parse(await pixlService.GetOrders(accessToken, skip, take));
        }
    }
}
