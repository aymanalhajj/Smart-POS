using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class ActionStatusModel
    {
        public ActionStatusModel( string message, int status = 1)
        {
            Status = status;
            Message = message;
        }
        public int? Status { get; set; }
        public string? Message { get; set; }
    }
}
