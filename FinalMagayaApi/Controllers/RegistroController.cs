using Data.ViewModels;
using Logica;
using System;
using System.Web.Mvc;

namespace FinalMagayaApi.Controllers
{
    public class RegistroController : Controller
    {
        private UsuarioLogic _usuarioLogic= new UsuarioLogic(); 
        // GET: Registro
        public ActionResult Index()
        {

            return View(_usuarioLogic.registro());
        }




        // POST: consignatarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Exclude = "IsEmailVerified,ActivationCode")] ConsignatarioViewModel consignatario)
        {
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                #region //Email is already Exist 
                var isExist = IsEmailExist(consignatario.Email);
                if (isExist)
                {

                    ModelState.AddModelError("EmailExist", "Email already exist");
                    ViewBag.Error = true;
                    ViewBag.Status = false;
                    ViewBag.Message = "Este email ya esta registrado en nuestra base de datos, intente recuperar su password o intente con un email distinto";

                    return View(consignatario);
                }
                #endregion

                #region Generate Activation Code 
                consignatario.ActivationCode = Guid.NewGuid();
                #endregion

                #region  Password Hashing 
                consignatario.AccessPassword = Crypto.Hash(consignatario.AccessPassword);
                consignatario.ConfirmPassword = Crypto.Hash(consignatario.ConfirmPassword); //
                #endregion
                consignatario.IsEmailVerified = false;
                #region Save to Database

                UsuarioLogic ul = new UsuarioLogic();
                ul.GuardaConsignatario(consignatario);


                var verifyUrl = "/aplicacion/Registro/VerifyAccount/" + consignatario.ActivationCode.ToString();
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                Utilidades.SendVerificationLinkEmail(consignatario.Email, consignatario.ActivationCode.ToString(), link);

                Utilidades.SendMailRegister(consignatario);
                //Send Email to User


                message = "Registration successfully done. Account activation link " +
                    " has been sent to your email id:" + consignatario.Email;
                Status = true;

                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(consignatario);
        }


        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            return _usuarioLogic.IsEmailExist(emailID);
        }


        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            var v = _usuarioLogic.VerificarRegistro(new Guid(id));

            if (v != null)
            {
                Status = true;

               // em.CrearClienteMagaya(v);
            }
            else
            {
                ViewBag.Message = "Invalid Request";
            }


            ViewBag.Status = Status;
            return View();
        }
    }
}