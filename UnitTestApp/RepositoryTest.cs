using System;
using System.Linq;
using Xunit;
using MyClassLibrary;
using MyClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UnitTestApp
{
    public class RepositoryTest
    {   
        [Fact]
        public void GetAllTest(){
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb1;Trusted_Connection=True;").Options;
            Repositiry arrange = new Repositiry(new ApplicationContext(op));
            
            var act = arrange.GetAll();

            Assert.NotNull(arrange);
            Assert.NotNull(act);
            Assert.IsAssignableFrom<IEnumerable<Person>>(act);
        }

        [Fact]
        public void FindTest(){
            long id = 7;
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb1;Trusted_Connection=True;").Options;
            IRepository<Person> arrange = new Repositiry(new ApplicationContext(op));

            var act = arrange.Find((int)id).Id;

            Assert.True(act == id);
        }

        [Fact]
        public void AddTest(){
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb1;Trusted_Connection=True;").Options;
            Repositiry arrange = new Repositiry(new ApplicationContext(op));

            var act = arrange.Add(new Person { Name = "a", DisplayName = "b" });

            Assert.IsType<long>(act);
        }

        [Fact]
        public void UpdateTest(){
            int id = 7;
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb1;Trusted_Connection=True;").Options;
            IRepository<Person> arrange = new Repositiry(new ApplicationContext(op));

            Skill[] skills = new Skill[] {
                new Skill { Id = 15, Name = "jjj", Level = 3 },
                new Skill { Id = 14, Name = "lll", Level = 5 }, 
                new Skill { Id = 144, Name = "lll", Level = 5 } 
            };
            
            var act = arrange.Update(id, new Person { Name = "a", DisplayName = "aa", Skills = skills });

            Assert.NotNull(arrange);
            Assert.NotNull(act);
            Assert.IsType<Person>(act);
            Assert.True(act.Id == id);
        }

        [Fact]
        public void RemoveTest(){
            int id = 6;
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb1;Trusted_Connection=True;").Options;
            IRepository<Person> arrange = new Repositiry(new ApplicationContext(op));

            var act = arrange.Remove(id);

            Assert.NotNull(act);
            Assert.IsType<Person>(act);
        }

        [Fact]
        public void MyTest()
        {
            int id = 5;
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb1;Trusted_Connection=True;").Options;
            ApplicationContext applicationContext = new ApplicationContext(op);
            Repositiry arrange = new Repositiry(applicationContext);

            Person p = new Person() { Name = "a", DisplayName = "a" };
            Person p1 = new Person() { Name = "bbb", DisplayName = "b" };
            Person p2 = new Person() { Name = "ccc", DisplayName = "c" };

            Skill skill = new Skill() { Name = "a", Level = 1, Person = p };
            Skill skill1 = new Skill() { Name = "b", Level = 2, PersonId = 6 };
            Skill skill2 = new Skill() { Name = "c", Level = 3, PersonId = 6 };

            Person per = arrange.Find(6);
            List<Skill> skills = per.Skills.ToList();
            string s = skills[0].Name;

            //HashSet<Skill> skills = (HashSet<Skill>)per.Skills;
            //string s = skills.First(s => s.Id == 9).Name;
            //string s1 = skills.First(s => s.Id == 10).Name;
            //Person per1 = skills.First(s => s.Id == 9).Person;
            //Person per2 = skills.First(s => s.Person.Equals(per)).Person;

            //arrange.Remove(5);
            //arrange.Add(p1);
            ///var act = arrange.GetAll();
            //var act = arrange.Remove(id);
            //arrange.ads();

            //Assert.NotNull(per);
            //Assert.True(per.Name.Equals("bbb"));
            //Assert.True(per.Skills.Count == 0);
            //Assert.NotNull(act);
            //Assert.IsType<Skill[]>(act);

            //Assert.NotNull(skills);
            Assert.True(s.Equals("b"));
            //Assert.True(s1.Equals("c"));
            Assert.True(skills.Count == 2);
            //Assert.True(per.Equals(per1) && per.Equals(per2));
        }
    }
}
