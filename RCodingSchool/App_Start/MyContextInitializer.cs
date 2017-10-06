using RCodingSchool.Models;
using System.Collections.Generic;

namespace RCodingSchool
{
    public class MyContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RCodingSchoolContext>
    {
        protected override void Seed(RCodingSchoolContext context)
        {
            var userList = new List<User>()
            {
                new User { FirstName = "Ольга",LastName="Атаманюк", Email="olyaatamanyuk@gmail.com", Password="123456"},
                new User { FirstName = "Марина", LastName = "Волощук", Email = "voloshuk@gmail.com" , Password = "123456"},
                new User { FirstName = "Василь", LastName = "Косован", Email = "kosovan@gmail.com", Password = "123456" },
                new User { FirstName = "Андрій", LastName = "Курган", Email = "kurgan@gmail.com", Password = "123456" },
                new User { FirstName = "Степан", LastName = "Миронюк", Email = "myronjuk@gmail.com", Password = "123456" },
                new User { FirstName = "Ігор", LastName = "Панчук", Email = "panchuk@gmail.com", Password = "123456"  },
                new User { FirstName = "Вікторія", LastName = "Якозина", Email = "yakozina@gmail.com", Password = "123456" },
                new User { FirstName = "Вікторія", LastName = "Якозина", Email = "admin", Password = "admin" }
            };
            userList.AddRange(userList);
            //context.MessagesGroups.Add(new MessageGroup { Name = "General" });
            context.SaveChanges();
        }
    }
}