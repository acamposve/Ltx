using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels
{
    public class ConsignatarioViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        [StringLength(75)]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string AccessPassword { get; set; }


        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("AccessPassword")]
        public string ConfirmPassword { get; set; }



        [Required]
        [Display(Name = "Cedula")]
        [StringLength(75)]
        public string cedula { get; set; }




        [Required]
        [Display(Name = "Telefono")]
        [StringLength(75)]
        public string telefono { get; set; }



        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }



        [Required]
        [Display(Name = "Direccion")]
        [StringLength(500)]
        public string Add1 { get; set; }


        [Required]
        [Display(Name = "Estado")]

        public int StateId { get; set; }



        [Required]
        [Display(Name = "Ciudad")]

        public int CityId { get; set; }



        [Required]
        [Display(Name = "Sector")]
        [StringLength(500)]
        public string Sector { get; set; }
        public Guid ActivationCode { get; set; }
        public bool IsEmailVerified { get; set; }


        public List<estados> listaEstados { get; set; }

        public List<ciudades> listaCiudades { get; set; }
        public List<Sector> listaSectores { get; set; }
    }
}
