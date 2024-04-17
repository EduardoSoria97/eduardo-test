using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateBusinessCommand
    {
        public Guid UserId { get; set; } 
        public string BusinessName { get; set; }
        public string CIF { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
