using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.Tables
{
    public class unidad_aprendizaje
    {
        [Key]
        public int id_unidad { get; set; }

        [Required]
        [Display(Name = "Número")]
        [StringLength(5)]
        public string numero_unidad { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Unidad")]
        public string nombre_unidad { get; set; }

        public byte[] foto { get; set; }

        public virtual List<tema_unidad> tema_unidad { get; set; }
    }
}