using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.ViewModels
{
    public class UnidadesViewM
    {
        public int id { get; set; }

        public string numero { get; set; }
        public string nombre { get; set; }

        public byte[] photo { get; set; }
    }
}