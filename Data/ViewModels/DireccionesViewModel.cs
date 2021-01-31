using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class DireccionesViewModel
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Direccion { get; set; }

        public int State { get; set; }

        public string Sector { get; set; }

        public int City { get; set; }

        public List<estados> listaEstados { get; set; }

        public List<ciudades> listaCiudades { get; set; }
        public List<Sector> listaSectores { get; set; }
    }
}
