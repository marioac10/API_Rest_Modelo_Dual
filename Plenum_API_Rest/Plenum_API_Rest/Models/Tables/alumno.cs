using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.Tables
{
    public class alumno
    {
        public alumno()
        {
            materia = new List<Alumno_Materia>();
            tema_unidad = new List<actividad_alumno>();

        }


        [Key]
        public int id_alumno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        [Display(Name = "Matrícula")]
        public string matricula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        [Display(Name = "Primer apellido")]
        public string apellido_p { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        [Display(Name = "Segundo apellido")]
        public string apellido_m { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10)]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(60)]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        [Display(Name = "Carrera")]
        public string carrera { get; set; }

        public virtual List<Alumno_Materia> materia { get; set; }

        public virtual List<actividad_alumno> tema_unidad { get; set; }
    }
}