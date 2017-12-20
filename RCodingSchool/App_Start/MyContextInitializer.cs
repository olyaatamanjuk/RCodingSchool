using StudLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace StudLine
{
    public class MyContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StudLineContext>
    {
        protected override void Seed(StudLineContext context)
        {
            var groupList = new List<Group>()
            {
                new Group { Name = "607" },
                new Group { Name = "603" },
                new Group { Name = "507" },
                new Group { Name = "402" },
				new Group { Name = "301" },
			};
            context.Groups.AddRange(groupList);

            var userList = new List<User>()
            {
                new User { FirstName = "Ольга",LastName="Атаманюк", Email="olyaatamanyuk@gmail.com", Password="123456", IsActive = true },
                new User { FirstName = "Марина", LastName = "Волощук", Email = "voloshuk@gmail.com" , Password = "123456",  IsActive = true },
                new User { FirstName = "Василь", LastName = "Косован", Email = "kosovan@gmail.com", Password = "123456" ,  IsActive = true },
                new User { FirstName = "Андрій", LastName = "Курган", Email = "kurgan@gmail.com", Password = "123456" },
                new User { FirstName = "Степан", LastName = "Миронюк", Email = "myronjuk@gmail.com", Password = "123456", IsActive = true},
                new User { FirstName = "Ігор", LastName = "Панчук", Email = "panchuk@gmail.com", Password = "123456" ,IsActive = true},
                new User { FirstName = "Вікторія", LastName = "Якозина", Email = "yakozina@gmail.com", Password = "123456" ,IsActive = true},
				new User { FirstName = "Роман", LastName = "Качало", Email = "kachalo@gmail.com", Password = "123456" , IsActive = true},
				new User { FirstName = "Станіслав", LastName = "Раранецький", Email = "stanislavr@gmail.com", Password = "123456", IsActive = true},
				new User { FirstName = "Крістіна", LastName = "Русу", Email = "rusu@gmail.com", Password = "123456" },

				new User { FirstName = "Адміністратор", LastName = "Адміністратор", Email = "admin", Password = "admin", IsActive = true, IsAdmin = true },
				new User { FirstName = "Ірина", LastName = "Дорошенко", Email = "doroshenko@mail.com", Password = "123456", IsActive = true  },
                new User { FirstName = "Ігор", LastName = "Малик", Email = "malyk@gmail.com", Password = "123456", IsActive = true  },
                new User { FirstName = "Ігор", LastName = "Юрченко", Email = "yurchenko@gmail.com", Password = "123456", IsActive = true  },
                new User { FirstName = "Світлана", LastName = "Антонюк", Email = "antonjuk@gmail.com", Password = "123456" },
                new User { FirstName = "Тарас", LastName = "Лукашів", Email = "lukashiv@gmail.com", Password = "123456" },

				new User { FirstName = "Віталій", LastName = "Іванюк", Email = "ivanjuk@gmail.com", Password = "123456" ,IsActive = true},
				new User { FirstName = "Сергій", LastName = "Лисенко", Email = "lysenko@gmail.com", Password = "123456" ,IsActive = true},
				new User { FirstName = "Вікторія", LastName = "Солецька", Email = "solets@gmail.com", Password = "123456" ,IsActive = true},
				new User { FirstName = "Денис", LastName = "Романов", Email = "romanov@gmail.com", Password = "123456"  ,IsActive = true},
				new User { FirstName = "Іванна", LastName = "Вербицька", Email = "verb@gmail.com", Password = "123456" ,IsActive = true},
				new User { FirstName = "Олексій", LastName = "Синенко", Email = "sinenko@gmail.com", Password = "123456" },
			};

            foreach (User item in userList)
            {
                item.Password = Crypto.SHA256(item.Password);
            }

            context.Users.AddRange(userList);
            context.SaveChanges();

            var teacherList = new List<Teacher>()
            {
                new Teacher { UserId = 11 },
                new Teacher { UserId = 12 },
                new Teacher { UserId = 13 },
                new Teacher { UserId = 14 },
                new Teacher { UserId = 15 },
            };

            context.Teachers.AddRange(teacherList);

            var studentsList = new List<Student>()
            {
                new Student { UserId = 1, GroupId = 1 }, 
                new Student { UserId = 2, GroupId = 1 },
                new Student { UserId = 3, GroupId = 1 },
                new Student { UserId = 4, GroupId = 1 },
                new Student { UserId = 5, GroupId = 1 },
                new Student { UserId = 6, GroupId = 1 },
                new Student { UserId = 7, GroupId = 1 },
                new Student { UserId = 8, GroupId = 2 },
				new Student { UserId = 9, GroupId = 2 },
				new Student { UserId = 10, GroupId = 2 },
				new Student { UserId = 16, GroupId = 3 },
				new Student { UserId = 17, GroupId = 4 },
				new Student { UserId = 18, GroupId = 3 },
				new Student { UserId = 19, GroupId = 4 },
				new Student { UserId = 20, GroupId = 4 },
				new Student { UserId = 21, GroupId = 3 }
			};

            context.Students.AddRange(studentsList);

            context.Subjects.AddRange(new List<Subject>()
            {
                new Subject { Name = "Кластерний аналіз" , IsExam = true },
                new Subject { Name = "Випадкові процеси" , IsExam = false },
                new Subject { Name = "Математичний аналіз", IsExam = true },
                new Subject { Name = "Методи оптимізації",IsExam = false },
                new Subject { Name = "Економетрія", IsExam = true }
            });
            context.SaveChanges();

            var teacherGroups = new List<TeacherGroup>()
            {
                new TeacherGroup { GroupId = 1, TeacherId = 1 },
                new TeacherGroup { GroupId = 2, TeacherId = 1 },
                new TeacherGroup { GroupId = 3, TeacherId = 1 },
				new TeacherGroup { GroupId = 1, TeacherId = 3 },
				new TeacherGroup { GroupId = 2, TeacherId = 3 },
				new TeacherGroup { GroupId = 3, TeacherId = 3 }
			};

			context.TeacherGroup.AddRange(teacherGroups);

			var groupSubjects = new List<GroupSubject>()
			{
				new GroupSubject {GroupId = 1, SubjectId = 1 },
				new GroupSubject {GroupId = 1, SubjectId = 2 },
				new GroupSubject {GroupId = 1, SubjectId = 3 },
				new GroupSubject {GroupId = 1, SubjectId = 4 }
			};

			context.GroupSubject.AddRange(groupSubjects);

			var teacherSubjects = new List<TeacherSubject>()
			{
				new TeacherSubject {TeacherId = 3, SubjectId = 1 },
				new TeacherSubject {TeacherId = 3, SubjectId = 2 },
				new TeacherSubject {TeacherId = 3, SubjectId = 3 },
				new TeacherSubject {TeacherId = 3, SubjectId = 4 }

			};

			context.TeacherSubject.AddRange(teacherSubjects);
			var subject = context.Subjects.First();

            var chaptertList = new List<Chapter>()
            {
                new Chapter { Name = "Розділ 1" , SubjectId = subject.Id },
                new Chapter { Name = "Розділ 2" , SubjectId = subject.Id },
                new Chapter { Name = "Розділ 3" , SubjectId = subject.Id },
                new Chapter { Name = "Розділ 4"  , SubjectId = subject.Id },
                new Chapter { Name = "Розділ 5" , SubjectId = subject.Id },
                new Chapter { Name = "Розділ 6"  , SubjectId = subject.Id },
                new Chapter { Name = "Розділ 7" , SubjectId = subject.Id },
                new Chapter
                {
                    SubjectId = subject.Id,
                    Name = "Індекс Херста",
                    Topics = new List<Topic>()
                    {
                        new Topic { Name = "Метод GPH", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                        new Topic { Name = "Метод MDFA", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                        new Topic { Name = "Модель ARFIMA", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                        new Topic { Name = "Модель AR", AuthorId = 1, Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page   editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." }
                    }
                }
            };

            context.Chapters.AddRange(chaptertList);

			var newsList = new List<News>()
			{
				new News { Title = "News Title", UserId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now.AddMonths(-4)},
				new News { Title = "News Title", UserId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now.AddMonths(-2) },
				new News { Title = "News Title", UserId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now.AddMonths(-3) },
				new News { Title = "News Title", UserId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now.AddMonths(-1) },
				new News { Title = "News Title", UserId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now },
				new News { Title = "Захист асистенської практики", UserId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now },
				new News { Title = "Захист переддипломної практики", UserId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now },
				new News { Title = "Студентська конференція", UserId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now },
				new News { Title = "Захист магістерських робіт", UserId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",  Date = DateTime.Now }
            };

            context.News.AddRange(newsList);

            var taskList = new List<Task>()
            {
                new Task { Name = "Лабораторна робота 1", TeacherId = 3 , Text = "Необхідно зробити лабораторну роботу у середовищі R", SubjectId = 1 },
                new Task { Name = "Лабораторна робота 2", TeacherId = 3 , Text = "Обчислити приклади ", SubjectId = 2 },
                new Task { Name = "На додаткові бали", TeacherId = 2 , Text = "Довести теореми ", SubjectId = 2 }
			};

            context.Tasks.AddRange(taskList);
            context.SaveChanges();
        }
    }
}