using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.ViewModels
{
    public class AlumnoViewModel
    {
      
        public string matricula { get; set; }

        public string nombre { get; set; }

        public string apellido_p { get; set; }

        public string apellido_m { get; set; }

        public string telefono { get; set; }

        public string correo { get; set; }

        public string carrera { get; set; }
    }
}