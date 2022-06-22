using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.Tables
{
    public class tema_unidad
    {
        public tema_unidad()
        {
            alumno = new List<actividad_alumno>();
        }

        [Key]
        public int id_tema { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tema")]
        public string nombre_tema { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Actividad")]
        public string entregable { get; set; }

        public unidad_aprendizaje unidad { get; set; }

        public virtual List<actividad_alumno> alumno { get; set; }
    }
}