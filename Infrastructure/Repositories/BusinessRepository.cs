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
        public async Task SaveBusinessAsync(Business business)
        {
            string fileName = $"business_{business.UserId}.json";
            string json = JsonConvert.SerializeObject(business, Formatting.Indented);
            await File.WriteAllTextAsync(fileName, json);
        }
    }
}
