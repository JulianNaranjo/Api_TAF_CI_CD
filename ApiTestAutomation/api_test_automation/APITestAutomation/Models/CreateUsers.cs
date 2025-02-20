using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Models
{
    public static class CreateUsers
    {
        public static User GenerateRandomUser()
        {
            User user = new User
            {
                Name = $"Name_{Random.Shared.Next(100, 1000)}",
                UserName = $"UserName_{Random.Shared.Next(100, 1000)}",
                Email = $"TestMail_{Random.Shared.Next(100, 1000)}",
                Address = new Address
                {
                    Street = $"Street {Random.Shared.Next(100, 1000)}",
                    Suite = $"Apt. {Random.Shared.Next(100, 1000)}",
                    City = $"New York",
                    Zipcode = $"{Random.Shared.Next(10000, 99999)}-{Random.Shared.Next(1000, 9999)}",
                    Geo = new Geo
                    {
                        Lat = $"-{Random.Shared.Next(1, 100)}.{Random.Shared.Next(1000, 9999)}",
                        Lng = $"{Random.Shared.Next(1, 100)}.{Random.Shared.Next(1000, 9999)}",
                    }
                },
                Company = new Company
                {
                    Name = $"Company_{Random.Shared.Next(100, 1000)}",
                    CatchPhrase = $"CatchPhrase_{Random.Shared.Next(100, 1000)}",
                    Bs = $"Bs_{Random.Shared.Next(100, 1000)}",
                }
            };

            return user;
        }
    }
}
