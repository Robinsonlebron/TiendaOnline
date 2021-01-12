using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Models
{
    public class Orden
    {
        public Orden()
        {
            ordenDetails = new List<OrderDetails>();
        }

        public int Id { get; set; }
        [Display(Name = "Numero de Orden")]
        public string NoOrder { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Numero de telefono")]
        public string PhoneNo { get; set; }
        [Required]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Direccion")]

        public string Address { get; set; }
        [Required]
        [Display(Name = "lat")]
        public string lat { get; set; }
        [Required]
        [Display(Name = "lng")]
        public string lng { get; set; }
        [Required]
        [Display(Name = "Comentario")]
        public string Comentario { get; set; }
  
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        public string OrderDate { get; set; }

        public virtual List<OrderDetails> ordenDetails { get; set; }
        

    }
}