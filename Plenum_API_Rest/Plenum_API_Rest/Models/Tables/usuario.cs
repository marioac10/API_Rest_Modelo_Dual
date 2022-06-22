using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.Tables
{
    public class usuario
    {
        [Key]
        public int id_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string contraseña { get; set; }

        [StringLength(80)]
        public string token { get; set; }

    }
}