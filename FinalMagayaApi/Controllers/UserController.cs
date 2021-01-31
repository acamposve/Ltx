using Data;
using Data.ViewModels;
using Logica;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FinalMagayaApi.Controllers
{
    public class UserController : Controller
    {
        private UsuarioLogic ul = new UsuarioLogic();
        private DireccionesLogic dl = new DireccionesLogic();

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            return View(ul.ObtenerUsuarioSesion(((User).Identity).Name));
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(dl.DireccionxId(id));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DireccionesViewModel direccion)
        {
            dl.UpdateDireccion(direccion);
            return View(ul.ObtenerUsuarioSesion(((User).Identity).Name));
        }







        public JsonResult GetbyID(int ID)
        {

            return Json(dl.DireccionxId(ID), JsonRequestBehavior.AllowGet);
        }
        //public JsonResult Update(Employee emp)
        //{
        //    return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult Delete(int ID)
        //{
        //    return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        //}
    }
}