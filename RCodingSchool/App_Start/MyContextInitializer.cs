using RCodingSchool.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace RCodingSchool
{
    public class MyContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RCodingSchoolContext>
    {
        protected override void Seed(RCodingSchoolContext context)
        {
            var userList = new List<User>()
            {
                new User { FirstName = "Ольга",LastName="Атаманюк", Email="olyaatamanyuk@gmail.com", Password="123456" },
                new User { FirstName = "Марина", LastName = "Волощук", Email = "voloshuk@gmail.com" , Password = "123456" },
                new User { FirstName = "Василь", LastName = "Косован", Email = "kosovan@gmail.com", Password = "123456" },
                new User { FirstName = "Андрій", LastName = "Курган", Email = "kurgan@gmail.com", Password = "123456" },
                new User { FirstName = "Степан", LastName = "Миронюк", Email = "myronjuk@gmail.com", Password = "123456" },
                new User { FirstName = "Ігор", LastName = "Панчук", Email = "panchuk@gmail.com", Password = "123456" },
                new User { FirstName = "Вікторія", LastName = "Якозина", Email = "yakozina@gmail.com", Password = "123456" },
                new User { FirstName = "Вікторія", LastName = "Якозина", Email = "admin", Password = "admin" }
            };

            foreach (User item in userList)
            {
                item.Password = Crypto.SHA256(item.Password);
            }

            context.Users.AddRange(userList);
            context.SaveChanges();
            var user = context.Users.First();

            context.Teachers.Add(new Teacher
            {
                UserId = user.Id
            });
            context.SaveChanges();

            var subjectList = context.Subjects.AddRange(new List<Subject>()
            {
                new Subject {  Name = "Системний аналіз" },
                new Subject {  Name = "Випадкові процеси" },
                new Subject {  Name = "Охорона праці" },
                new Subject {  Name = "Алгоритми" },
                new Subject {  Name = "Алгебра" }
            });

            var chaptertList = new List<Chapter>()
            {
                new Chapter {  Name = "Початок" },
                new Chapter {  Name = "Типи даних і робота з нимим" },
                new Chapter {  Name = "Цикли" },
                new Chapter {  Name = "Масиви" },
                new Chapter {  Name = "Опрацювання даних" },
                new Chapter {  Name = "Графіки" },
                new Chapter { Name = "Кінець" },
                new Chapter
                {
                    Name = "Кінець",
                    Topics = new List<Topic>()
                    {
                        new Topic {  Name = "Початок", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."},
                        new Topic {  Name = "Початок", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."},
                        new Topic {  Name = "Початок", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."},
                       new Topic {  Name = "Початок", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page   editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident,          sometimes on purpose (injected humour and the like)."},
                    }
                }
            };
            context.Chapters.AddRange(chaptertList);

            context.SaveChanges();
        }
    }
}