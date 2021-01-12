using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Models
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string email { get;set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Producto Producto { get; set; }
    }
}
