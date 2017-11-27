using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace RCodingSchool
{
    public class MyContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RCodingSchoolContext>
    {
        protected override void Seed(RCodingSchoolContext context)
        {
            var groupList = new List<Group>()
            {
                new Group { Name = "402" },
                new Group { Name = "407" },
                new Group { Name = "507" },
                new Group { Name = "222" },
            };
            context.Groups.AddRange(groupList);

            var userList = new List<User>()
            {
                new User { FirstName = "Ольга",LastName="Атаманюк", Email="olyaatamanyuk@gmail.com", Password="123456", IsActive = true },
                new User { FirstName = "Марина", LastName = "Волощук", Email = "voloshuk@gmail.com" , Password = "123456",  IsActive = true },
                new User { FirstName = "Василь", LastName = "Косован", Email = "kosovan@gmail.com", Password = "123456" ,  IsActive = true },
                new User { FirstName = "Андрій", LastName = "Курган", Email = "kurgan@gmail.com", Password = "123456" },
                new User { FirstName = "Степан", LastName = "Миронюк", Email = "myronjuk@gmail.com", Password = "123456" },
                new User { FirstName = "Ігор", LastName = "Панчук", Email = "panchuk@gmail.com", Password = "123456" },
                new User { FirstName = "Вікторія", LastName = "Якозина", Email = "yakozina@gmail.com", Password = "123456" },
                new User { FirstName = "Ірина", LastName = "Дорошенко", Email = "doroshenko@mail.com", Password = "123456", IsActive = true  },

                new User { FirstName = "Адміністратор", LastName = "Адміністратор", Email = "admin", Password = "admin", IsActive = true, isAdmin = true },
                new User { FirstName = "Ігор", LastName = "Малик", Email = "malyk@gmail.com", Password = "123456", IsActive = true  },
                new User { FirstName = "Ігор", LastName = "Юрченко", Email = "yurchenko@gmail.com", Password = "123456", IsActive = true  },
                new User { FirstName = "Світлана", LastName = "Антонюк", Email = "antonjuk@gmail.com", Password = "123456" },
                new User { FirstName = "Тарас", LastName = "Лукашів", Email = "lukashiv@gmail.com", Password = "123456" }
            };

            foreach (User item in userList)
            {
                item.Password = Crypto.SHA256(item.Password);
            }

            context.Users.AddRange(userList);
            context.SaveChanges();
            var user = context.Users.First();

            var teacherList = new List<Teacher>()
            {
                new Teacher { UserId = 9 },
                new Teacher { UserId = 10 },
                new Teacher { UserId = 11 },
                new Teacher { UserId = 12 },
                new Teacher { UserId = 13 },
            };

            context.Teachers.AddRange(teacherList);

            var studentsList = new List<Student>()
            {
                new Student { UserId = 1, GroupId = 1 }, 
                new Student { UserId = 2, GroupId = 2 },
                new Student { UserId = 3, GroupId = 3 },
                new Student { UserId = 4, GroupId = 4 },
                new Student { UserId = 5, GroupId = 4 },
                new Student { UserId = 6, GroupId = 2 },
                new Student { UserId = 7, GroupId = 2 },
                new Student { UserId = 8, GroupId = 1 }
            };

            context.Students.AddRange(studentsList);


            var subjectList = context.Subjects.AddRange(new List<Subject>()
            {
                new Subject {  Name = "Системний аналіз" , IsExam = true},
                new Subject {  Name = "Випадкові процеси" , IsExam = false},
                new Subject {  Name = "Охорона праці",IsExam = true },
                new Subject {  Name = "Алгоритми",IsExam = false },
                new Subject {  Name = "Алгебра", IsExam = true }
            });
            context.SaveChanges();

            var teacherGroups = new List<TeacherGroup>()
            {
                new TeacherGroup { GroupId = 1, TeacherId = 1 },
                new TeacherGroup { GroupId = 2, TeacherId = 1 },
                new TeacherGroup { GroupId = 3, TeacherId = 1 },
            };

            context.TeacherGroup.AddRange(teacherGroups);

            var subject = context.Subjects.First();

            var chaptertList = new List<Chapter>()
            {
                new Chapter {  Name = "Початок" , SubjectId = subject.Id},
                new Chapter {  Name = "Типи даних і робота з нимим" , SubjectId = subject.Id },
                new Chapter {  Name = "Цикли" , SubjectId = subject.Id },
                new Chapter {  Name = "Масиви"  , SubjectId = subject.Id},
                new Chapter {  Name = "Опрацювання даних" , SubjectId = subject.Id },
                new Chapter {  Name = "Графіки"  , SubjectId = subject.Id},
                new Chapter { Name = "Кінець" , SubjectId = subject.Id },
                new Chapter
                {
                    SubjectId = subject.Id,
                    Name = "Кінець",
                    Topics = new List<Topic>()
                    {
                        new Topic {  Name = "Тема 1", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."},
                        new Topic {  Name = "Тема 2", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."},
                        new Topic {  Name = "Тема 3", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."},
                       new Topic {  Name = "Тема 4", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page   editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident,          sometimes on purpose (injected humour and the like)."},
                    }
                }
            };
            context.Chapters.AddRange(chaptertList);

            var newsList = new List<News>()
            {
                new News {Title = "Захист практики", NewsAuthorId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now },
                new News {Title = "Студентська конференція", NewsAuthorId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",  Date = DateTime.Now}
            };
            context.News.AddRange(newsList);

            var taskList = new List<Task>()
            {
                new Task { Name = "Лабораторна робота 1", TeacherId = 1 , Text = "Необхідно зробити лабораторну роботу у середовищі R", SubjectId = 1 },
                new Task { Name = "Лабораторна робота 2", TeacherId = 2 , Text = "Обчислити приклади ", SubjectId = 2 },
                new Task { Name = "На додаткові бали", TeacherId = 2 , Text = "Довести теореми ", SubjectId = 2 },
            };

            context.Tasks.AddRange(taskList);

            context.SaveChanges();
        }
    }
}