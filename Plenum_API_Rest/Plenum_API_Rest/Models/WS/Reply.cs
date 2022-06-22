using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plenum_API_Rest.Models.WS
{
    public class Reply
    {
        public int Result { get; set; }
        public object Data { get; set; }

        public string Message { get; set; } 

    }
}