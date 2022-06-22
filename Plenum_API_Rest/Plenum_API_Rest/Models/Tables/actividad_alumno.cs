using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.Tables
{
    public class actividad_alumno
    {
        public int id_alumno { get; set; }

        public int id_tema { get; set; }

        [ForeignKey("id_alumno")]
        public virtual alumno alumno { get; set; }

        public virtual tema_unidad tema_unidad { get; set; }
    }
}