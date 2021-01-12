using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Descripcion { get; set; }
        public string image { get; set; }
        [Display(Name ="Color Producto")]
        public string Color { get; set; }
        [Required]
        public string Cantidad { get; set; }
        [Required]
        [Display(Name = "disponible")]
        public bool disponible { get; set; }
        [Required]
        public int ProductTypeId{ get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductTypes ProductTypes { get; set; }
        [Required]
        public int specialTagId { get; set; }
        [ForeignKey("specialTagId")]
        public SpecialTag specialTag{ get; set; }

    }
}
