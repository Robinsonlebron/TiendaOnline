using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required]
       
        [Display(Name = "datebirth")]
        public DateTime datebirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required]
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "su contraseñas no coinciden")]
        public string ConfirmarContraseña { get; set; }
    }
}
