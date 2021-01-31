using Logica;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FinalMagayaApi.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}

