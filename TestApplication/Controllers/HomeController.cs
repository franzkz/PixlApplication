using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApplication.Services;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly PixlService pixlService = PixlService.Instance;
        public async Task<ActionResult> Index()
        {
            var request = await pixlService.GetRequestTokenAsync();
            var access = await pixlService.GetAccessTokenAsync(request.RequestToken);

            return View(access);
        }

    }
}
