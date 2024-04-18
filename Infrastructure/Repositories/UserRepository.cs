using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository
    {
        public async Task SaveUserAsync(User user)
        {
            string fileName = $"user_{user.Id}.json";
            string json = JsonConvert.SerializeObject(user);
            await File.WriteAllTextAsync(fileName, json);
        }
    }
}
