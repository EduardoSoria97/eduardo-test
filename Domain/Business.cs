using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Business
    {
        public Guid UserId { get; set; }
        public string BusinessName { get; set; }
        public string CIF { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
