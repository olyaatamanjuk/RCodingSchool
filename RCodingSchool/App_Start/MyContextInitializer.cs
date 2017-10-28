﻿using RCodingSchool.Models;
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
                new User { FirstName = "Адміністратор", LastName = "Адміністратор", Email = "admin", Password = "admin" },
				new User { FirstName = "Ірина", LastName = "Дорошенко", Email = "doroshenko@mail.com", Password = "123456", IsActive = true  },
				new User { FirstName = "Адміністратор", LastName = "Адміністратор", Email = "malyk@gmail.com", Password = "123456", IsActive = true  },
				new User { FirstName = "Адміністратор", LastName = "Адміністратор", Email = "yurchenko@gmail.com", Password = "123456", IsActive = true  },
				new User { FirstName = "Адміністратор", LastName = "Адміністратор", Email = "antonjuk@gmail.com", Password = "123456" },
				new User { FirstName = "Адміністратор", LastName = "Адміністратор", Email = "lukashiv@gmail.com", Password = "123456" }
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
				new Teacher {UserId = 9 },
				new Teacher {UserId = 10 },
				new Teacher {UserId = 11 },
				new Teacher {UserId = 12 },
				new Teacher {UserId = 13 },
			};

			context.Teachers.AddRange(teacherList);

			var studentsList = new List<Student>()
			{
				new Student {UserId = 1 , GroupId = 1},
				new Student {UserId = 2, GroupId = 2 },
				new Student {UserId = 3, GroupId = 3},
				new Student {UserId = 4, GroupId = 4 },
				new Student {UserId = 5, GroupId = 4 },
				new Student {UserId = 6, GroupId = 2 },
				new Student {UserId = 7, GroupId = 2 },
				new Student {UserId = 8, GroupId = 1}
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
			var newsList = new List<News>()
			{
				new News {Title = "Захист практики", NewsAuthorId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).", Date = DateTime.Now },
				new News {Title = "Студентська конференція", NewsAuthorId = 1, Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",  Date = DateTime.Now}
			};

			context.Chapters.AddRange(chaptertList);
			context.News.AddRange(newsList);

            context.SaveChanges();
        }
    }
}