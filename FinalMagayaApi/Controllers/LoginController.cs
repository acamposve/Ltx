using Data;
using Entidades.Incoming;
using Logica;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalMagayaApi.Controllers
{
    public class LoginController : Controller
    {
        private string message = "";
        bool Status = false;
        readonly UsuarioLogic ul = new UsuarioLogic();
        readonly PasswordRecoveryLogic prl = new PasswordRecoveryLogic();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        private ActionResult CreaSesion(string login, string ReturnUrl)
        {
            int timeout = 525600; // 525600 min = 1 year
            var ticket = new FormsAuthenticationTicket(login, true, timeout);
            string encrypted = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
            {
                Expires = DateTime.Now.AddMinutes(timeout),
                HttpOnly = true
            };
            Response.Cookies.Add(cookie);
            Session["UserName"] = login.ToString();

            if (Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult RecuperarPass()
        {
            return View();
        }
        
        [NonAction]
        public void SendRecoveryLinkEmail(string emailID, string activationCode)
        {
            var verifyUrl = "/Login/RecoverEmail/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            Utilidades.SendRecoveryLinkEmail(emailID, activationCode, link);
        }

        [HttpGet]
        public ActionResult RecoverEmail(string id)
        {
            string email = "";
            PasswordRecoveryLogic prl = new PasswordRecoveryLogic();
            var v = prl.IsEmailRecoverExist(id);
            if (v != null)
            {
                email = v;
            }
            else
            {
                ViewBag.Message = "Invalid Request";
            }
            ViewBag.EMail = email;




            consignatario cons = new consignatario
            {
                Email = email
            };
            return View(cons);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(consignatario login, string ReturnUrl = "")
        {
            UsuarioLogic ul = new UsuarioLogic();

            LoginIn li = new LoginIn
            {
                Login = login.Email,
                Password = login.AccessPassword
            };

            var v = ul.message(li);

            if (v != null)
            {
                if (v.passHash == 0)
                {
                    return CreaSesion(li.Login, ReturnUrl);
                }
            }

            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarPass(string email)
        {




            var v = ul.DatosUsuario(email);

            if (v != null)
            {
                PasswordRecovery pr = new PasswordRecovery
                {
                    RecoveryKey = Guid.NewGuid(),
                    Email = email,
                    IsRecovered = false
                };
                prl.InsertPR(pr);

                SendRecoveryLinkEmail(email, pr.RecoveryKey.ToString());
                message = "Registration successfully done. Account activation link " +
                    " has been sent to your email id:" + email;
                Status = true;

            }
            else
            {
                message = "Invalid credential provided";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult RecoverEmail(consignatario cons)
        {
            PasswordRecoveryLogic prl = new PasswordRecoveryLogic();
            #region  Password Hashing 
            cons.AccessPassword = Crypto.Hash(cons.AccessPassword);
            prl.actualizaPass(cons);
            #endregion

            bool Status = true;
            ViewBag.Status = Status;
            ViewBag.Message = "Contraseña Modificada!";

            return View(cons);
        }
    }
}