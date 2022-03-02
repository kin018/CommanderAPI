using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.DTOs
{
    public class CommandCreateDTO
    {
        // public int Id { get; set; } Not needed since ID and Primary Key are being created by Database

        public string HowTo { get; set; }

        public string Line { get; set; }

        public string Platform { get; set;  }// Would get error if not supplied 
    }
}
