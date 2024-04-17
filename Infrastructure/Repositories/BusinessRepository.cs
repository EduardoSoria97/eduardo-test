using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BusinessRepository
    {
        public void SaveBusiness(Business business, Guid userId)
        {
            string fileName = $"business_{userId}.json";
            string json = JsonConvert.SerializeObject(business, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}
