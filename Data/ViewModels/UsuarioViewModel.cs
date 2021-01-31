using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class UsuarioViewModel
    {
        public int idConsignatario { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Add1 { get; set; }
        public string Email { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string cedula { get; set; }


        public string Sector { get; set; }
        public List<AddressViewModel> direccionesUsuario { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [StringLength(500)]
        public string State { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        [StringLength(500)]
        public string City { get; set; }




        public string Direccion { get; set; }

        public int StateId { get; set; }



        public int CityId { get; set; }
    }
}
