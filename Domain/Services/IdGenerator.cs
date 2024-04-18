using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public static class IdGenerator
    {
        public static Guid GenerateUniqueId() 
        { 
            return Guid.NewGuid();
        }
    }
}
