using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.Tables
{
    public class Alumno_Materia
    {
        public int id_alumno { get; set; }

        public int id_materia { get; set; }

        [ForeignKey("id_alumno")]
        public virtual alumno alumno { get; set; }

        public virtual materia materia { get; set; }
    }
}