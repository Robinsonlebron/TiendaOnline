using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Areas.Admin.Model
{
    public class RoleUservm
    {
        [Required]
        [Display(Name="User")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}
