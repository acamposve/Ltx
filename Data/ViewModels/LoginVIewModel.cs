using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ViewModels
{
    public class LoginVIewModel
    {
        public int passHash { get; set; }
        public string message { get; set; }

        public consignatario Consignatario { get; set; }
    }
}
