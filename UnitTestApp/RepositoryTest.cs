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
    }
}
