using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Display(Name ="Orden")]
        public int OrderId { get; set; }
        [Display(Name = "Producto")]
        public int ProductId { get; set; }
        [ForeignKey("OrderId")]
        public Orden orden { get; set; }
        [ForeignKey("ProductId")]
        public Producto producto { get; set; }
       
    }
}
