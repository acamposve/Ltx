using Data;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Logica
{
    public static class Utilidades
    {
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }

        public static void SendVerificationLinkEmail(string emailID, string activationCode, string link)
        {
            var verifyUrl = "/Registro/VerifyAccount/" + activationCode;


            var fromEmail = new MailAddress("registro@ltx.com.ve", "LTX");
            var toEmail = new MailAddress(emailID);

            string subject = "Registro Exitoso!";



            string body = "<table width='660' border='0' align='center' cellpadding='1' cellspacing='0' bgcolor='#CCCCCC'><tr><td>";
            body += "<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='130' align='center' bgcolor='#f5f6f7'>";
            body += "<img src='http://ltx.com.ve/images/logo-ltx---final-201912.png' width='231' height='72' /></td></tr></table></td></tr><tr><td>";
            body += "<table border='0' align='center' cellpadding='30' cellspacing='0'><tr><td valign='top' bgcolor='#FFFFFF'>";
            body += "<h1 style='font-family: Verdana, Geneva, sans-serif;font-size: 22px; color: #333333; font-weight: bold; letter-spacing: -1px;'>";
            body += "</h1><p><span style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #000000;'>";
            body += "Gracias por escogernos como tu courier de confianza. Para continuar con el proceso de registro haz clic aqu&iacute;:</span><br /><br /></p>";
            body += "<table width='250' border='0' align='center' cellpadding='15' cellspacing='0'><tr><td align='center'><a href=" + link + " >";
            body += "<img src='http://ltx.com.ve/app/img/conf-reg.png' border='0' /></a></td></tr></table><p>&nbsp;</p>";
            body += "<p style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #777777;'><strong>¿No funciona el bot&oacute;n? </strong><br />";
            body += "Prueba copiando y pegando la siguiente direcci&oacute;n en tu navegador:<br />" + link + "</p><p><span>";
            body += "-------------------------------------------------------------------------------------</span><br /></td></tr><tr>";
            body += "<td valign='top' bgcolor='#FFFFFF'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td><span>";
            body += "<img src='http://www.ltx.com.ve/app/img/firma.png' width='176' height='39' /></span></td><td align='right'>";
            body += "<img src='http://www.ltx.com.ve/app/img/tetraemos.jpg' width='201' height='16' /></td></tr></table></td></tr></table></td></tr><tr><td>";
            body += "<table width='100%' border='0' cellspacing='0' cellpadding='30'><tr><td bgcolor='#FFFFFF'>";
            body += "<p style='font-family: Verdana, Geneva, sans-serif; font-size: 10px; color: #333333;'><strong>";
            body += "Por favor no responder a este mensaje ya que el mismo fue enviado desde una cuenta de correo electr&oacute;nico no monitoreada. </strong>";
            body += "</p><p style='font-family: Verdana, Geneva, sans-serif; font-size: 10px; color: #333333;' dir='ltr'>";
            body += "Tu contrase&ntilde;a es confidencial, LatamXpress® nunca solicitar&aacute; datos de tu cuenta y contrase&ntilde;a por correo electr&oacute;nico ni por ning&uacute;n otro medio.</p><p dir='ltr'>";
            body += "<strong style='font-family: Verdana, Geneva, sans-serif; font-size: 10px; color: #333333;' id='docs-internal-guid-76b42a8c-6675-d983-e14a-bd00f1c486aa'>";
            body += "¿Dudas? escribenos a info@ltx.com.ve y te ayudaremos</strong></p></td></tr></table></td></tr><tr><td align='center'>";
            body += "<table width='100%' border='0' cellspacing='0' cellpadding='20' style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #FFFFFF; text-decoration: none;'>";
            body += "<tr><td align='center' valign='top' bgcolor='#21619D' style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #FFFFFF; text-decoration: none;'>";
            body += "<strong>Miami - Estados Unidos</strong><br />8000 NW 29th St,<br />Miami,FL 33122<br /><br /><a href='#' style='color:#FFF; text-decoration:none'>+1(305)640-5391</a><br /><a href='#' style='color:#FFF; text-decoration:none'>+1(305)640-5639</a></td><td align='center' valign='top' bgcolor='#21619D'><strong>Caracas - Venezuela</strong><br /><a href='#' style='color:#FFF; text-decoration:none'>+58(212)655-0603</a><br />RIF:J-40620006-9 <br /><br /><br /><a href='http://www.ltx.com.ve' style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #FFFFFF; text-decoration: none;'><strong>www.ltx.com.ve</strong></a></td><td width='30%' align='center' valign='top' bgcolor='#21619D'><strong>Síguenos en:</strong><br /><br /><table width='100%' border='0' cellspacing='0' cellpadding='2'><tr><td><a href='https://www.facebook.com/Latam-Xpress-1049926855020369/?fref=ts' target='_blank'><img src='http://www.latamxpress.com/app/img/facebook.png' width='38' height='38' /></a></td><td><a href='https://www.instagram.com/latamxpress/' target='_blank'><img src='http://www.latamxpress.com/app/img/instagram.png' width='39' height='38' /></a></td><td><a href='https://twitter.com/latamxpress' target='_blank'><img src='http://www.latamxpress.com/app/img/twitter.png' width='38' height='38' /></a></td><td><a href='https://www.youtube.com/channel/UCfHfXf1oNSKP9wlPNn9_TwA' target='_blank'><img src='http://www.latamxpress.com/app/img/youtube.png' width='38' height='38' /></a></td></tr></table></td></tr></table></td></tr></table>";




            EnvioCorreo(fromEmail.ToString(), toEmail.ToString(), subject, body);
        }

        public static void SendRecoveryLinkEmail(string emailID, string activationCode, string link)
        {
            //var verifyUrl = "/Login/RecoverEmail/" + activationCode;
            //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("registro@ltx.com.ve", "LTX");
            var toEmail = new MailAddress(emailID);

            string subject = "Solicitud de cambio de contraseña!";



            string body = " <table width='660' border='0' align='center' cellpadding='1' cellspacing='0' bgcolor='#CCCCCC'><tr><td><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td height='130' align='center' bgcolor='#f5f6f7'><img src='http://ltx.com.ve/images/logo-ltx---final-201912.png' width='231' height='72' /></td></tr></table></td></tr><tr><td><table border='0' align='center' cellpadding='30' cellspacing='0'><tr><td valign='top' bgcolor='#FFFFFF'><h1 style='font-family: Verdana, Geneva, sans-serif;font-size: 22px; color: #333333; font-weight: bold; letter-spacing: -1px;'></h1><p><span style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #000000;'>Gracias por escogernos como tu courier de confianza. Para recuperar tu password haz clic aqu&iacute;:</span><br /><br /></p><table width='250' border='0' align='center' cellpadding='15' cellspacing='0'><tr><td align='center'><a href=" + link + "><img src='http://ltx.com.ve/app/img/conf-reg.png' border='0' /></a></td></tr></table><p>&nbsp;</p><p style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #777777;'><strong>¿No funciona el bot&oacute;n? </strong><br />Prueba copiando y pegando la siguiente direcci&oacute;n en tu navegador:<br />" + link + "</p><p><span>-------------------------------------------------------------------------------------</span><br /></td></tr><tr><td valign='top' bgcolor='#FFFFFF'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td><span><img src='http://www.ltx.com.ve/app/img/firma.png' width='176' height='39' /></span></td><td align='right'><img src='http://www.ltx.com.ve/app/img/tetraemos.jpg' width='201' height='16' /></td></tr></table></td></tr></table></td></tr><tr><td><table width='100%' border='0' cellspacing='0' cellpadding='30'><tr><td bgcolor='#FFFFFF'><p style='font-family: Verdana, Geneva, sans-serif; font-size: 10px; color: #333333;'><strong>Por favor no responder a este mensaje ya que el mismo fue enviado desde una cuenta de correo electr&oacute;nico no monitoreada.</strong></p><p style='font-family: Verdana, Geneva, sans-serif; font-size: 10px; color: #333333;' dir='ltr'>Tu contrase&ntilde;a es confidencial, LatamXpress® nunca solicitar&aacute; datos de tu cuenta y contrase&ntilde;a por correo electr&oacute;nico ni por ning&uacute;n otro medio.</p><p dir='ltr'><strong style='font-family: Verdana, Geneva, sans-serif; font-size: 10px; color: #333333;' id='docs-internal-guid-76b42a8c-6675-d983-e14a-bd00f1c486aa'>¿Dudas? escribenos a info@ltx.com.ve y te ayudaremos</strong></p></td></tr></table></td></tr><tr><td align='center'><table width='100%' border='0' cellspacing='0' cellpadding='20' style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #FFFFFF; text-decoration: none;'><tr><td align='center' valign='top' bgcolor='#21619D' style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #FFFFFF; text-decoration: none;'><strong>Miami - Estados Unidos</strong><br />8000 NW 29th St,<br />Miami,FL 33122<br /><br /><a href='#' style='color:#FFF; text-decoration:none'>+1(305)640-5391</a><br /><a href='#' style='color:#FFF; text-decoration:none'>+1(305)640-5639</a></td><td align='center' valign='top' bgcolor='#21619D'><strong>Caracas - Venezuela</strong><br /><a href='#' style='color:#FFF; text-decoration:none'>+58(212)655-0603</a><br />RIF:J-40620006-9 <br /><br /><br /><a href='http://www.ltx.com.ve' style='font-family: Verdana, Geneva, sans-serif; font-size: 13px; color: #FFFFFF; text-decoration: none;'><strong>www.ltx.com.ve</strong></a></td><td width='30%' align='center' valign='top' bgcolor='#21619D'><strong>Síguenos en:</strong><br /><br /><table width='100%' border='0' cellspacing='0' cellpadding='2'><tr><td><a href='https://www.facebook.com/Latam-Xpress-1049926855020369/?fref=ts' target='_blank'><img src='http://www.latamxpress.com/app/img/facebook.png' width='38' height='38' /></a></td><td><a href='https://www.instagram.com/latamxpress/' target='_blank'><img src='http://www.latamxpress.com/app/img/instagram.png' width='39' height='38' /></a></td><td><a href='https://twitter.com/latamxpress' target='_blank'><img src='http://www.latamxpress.com/app/img/twitter.png' width='38' height='38' /></a></td><td><a href='https://www.youtube.com/channel/UCfHfXf1oNSKP9wlPNn9_TwA' target='_blank'><img src='http://www.latamxpress.com/app/img/youtube.png' width='38' height='38' /></a></td></tr></table></td></tr></table></td></tr></table>";


            Utilidades.EnvioCorreo(fromEmail.ToString(), toEmail.ToString(), subject, body);




        }






        public static void SendMailRegister(ConsignatarioViewModel consigna)
        {
            //var verifyUrl = "/Login/RecoverEmail/" + activationCode;
            //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("registro@ltx.com.ve", "LTX");
            var toEmail = new MailAddress("registro@ltx.com.ve");

            string subject = "Registro en LTX.COM.VE - Magaya!";

            string sexo = "";

            switch (consigna.Sexo)
            {
                case "1":
                    sexo = "Masculino";
                    break;
                case "2":
                    sexo = "Femenino";
                    break;

                case "3":
                    sexo = "Otro";
                    // code block
                    break;
                default:
                    // code block

                    sexo = "Masculino";
                    break;
            }

            string body = "<table><tr><td>Nombre:</td><td>" + consigna.Name + " " + consigna.apellido + "</td></tr><tr></td>Email:</td><td>" + consigna.Email + "</td></tr>" +
                "<tr><td>Numero identificacion</td><td>"+ consigna.cedula +"</td></tr>" +
                "<tr><td>Telefono</td><td>" + consigna.telefono + "</td></tr>" +
                "<tr><td>Sexo:</td><td>" + sexo + "</td></tr>" +
                "<tr><td>Direccion:</td><td>" + consigna.Add1 + "</td></tr>" +
                "<tr><td>Sector:</td><td>" + consigna.Sector + "</td></tr></table>";

        

                


            Utilidades.EnvioCorreo(fromEmail.ToString(), toEmail.ToString(), subject, body);




        }










        private static void EnvioCorreo(string fromEmail, string toEmail, string subject, string body)
        {


            var smtp = new SmtpClient
            {
                Host = "outbound.mailhop.org",
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("latamcargo", "7km2plkc")
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);

        }
        //public class ProcesaEntidades
        //{

        //    DataEntidades de = new DataEntidades();
        //    public string datocliente(string email)
        //    {
        //        return de.Datocliente(email);
        //    }
        //    public void Procesador(List<XElement> pLista)
        //    {
        //        for (int i = 0; i < pLista.Count; i++)
        //        {
        //            var datos = XElement.Parse(pLista[i].ToString());
        //            Data.Entidades ent = new Data.Entidades();
        //            ent.insertaEntidades(datos);
        //        }
        //    }
        //}

        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new Utf8StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType(), "http://www.magaya.com/XMLSchema/V1");
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, "http://www.magaya.com/XMLSchema/V1");
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o, namespaces);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
    }
}
