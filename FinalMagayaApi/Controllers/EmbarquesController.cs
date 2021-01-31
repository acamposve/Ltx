using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalMagayaApi.Controllers
{
    public class EmbarquesController : Controller
    {
        private WR _wrLogic = new WR();
        // GET: Embarques
        public ActionResult Index()
        {
            return View(_wrLogic.ListaWR());
        }

        public JsonResult GetbyID(int ID)
        {
           //WR datosWE = new WR();

           // var datos = datosWE.listaWRById(ID);


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListPending()
        {
            WR datosWE = new WR();

            var datos = datosWE.ListaWR();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Pendientes()
        {
            //WR datosWE = new WR();

            //var datos = datosWE.listaWR();
            return View();
        }

        public ActionResult Transito()
        {
            return View();
        }

        public ActionResult Historial()
        {
            return View();
        }
        public ActionResult Rastreo()
        {
            return View();
        }
    }
}