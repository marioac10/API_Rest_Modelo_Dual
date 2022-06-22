using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.Tables
{
    public class materia
    {
        public materia()
        {
            alumno = new List<Alumno_Materia>();
        }

        [Key]
        public int id_materia { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_materia { get; set; }

        [Required]
        [StringLength(50)]
        public string clave { get; set; }

        [Required]
        [StringLength(5)]
        public string creditos { get; set; }

        [Required]
        [StringLength(10)]
        public string semestre { get; set; }

        public virtual List<Alumno_Materia> alumno { get; set; }
    }
}