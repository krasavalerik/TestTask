using System;
using Xunit;
using MyClassLibrary;
using MyClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using MyTask.Controllers;

namespace UnitTestApp
{
    public class RepositoryTest
    {   
        [Fact]
        public void CreateRepositoryTest(){
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb;Trusted_Connection=True;").Options;
            IRepository<Person> arrange = new Repositiry(new ApplicationContext(op));
            
            var act = arrange.GetAll();

            Assert.NotNull(arrange);
            Assert.NotNull(act);
        }

        [Fact]
        public void GetAllTest(){
            var mock = new Mock<IRepository<Person>>();
            mock.Setup(rep => rep.GetAll()).Returns(GetTestPersons);

            var act = mock.Object.GetAll();

            Assert.NotNull(act);
            //Assert.Empty(act);
            Assert.IsAssignableFrom<IEnumerable<Person>>(act);
            Assert.NotEmpty(act);
        }

        [Fact]
        public void FindTest(){
            var mock = new Mock<IRepository<Person>>();
            mock.Setup(rep => rep.Find(1)).Returns(new Person { Id = 1, Name = "Tom", DisplayName = "a", Skills = new Skill[5] });

            var act = mock.Object.Find(1);

            Assert.NotNull(act);
            Assert.IsType<Person>(act);
            //Assert.Empty(act);
        }

        [Fact]
        public void AddTest(){
            var mock = new Mock<IRepository<Person>>();
            mock.Verify(rep => rep.Add(new Person { Id = 1, Name = "Tom", DisplayName = "a", Skills = new Skill[5] }));
        }

        [Fact]
        public void UpdateTest(){
            long id = 27;
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb;Trusted_Connection=True;").Options;
            IRepository<Person> arrange = new Repositiry(new ApplicationContext(op));

            var act = arrange.Add(new Person { Name = "Tom", DisplayName = "a", Skills = null });
            //var act = arrange.Update(15, new Person { Name = "T", DisplayName = "aaa", Skills = null });
            //var act = arrange.Find(15);

            Assert.NotNull(arrange);
            //Assert.NotNull(act);
            //Assert.IsType<Person>(act);
            Assert.True(act == id);
        }

        [Fact]
        public void FindByIdTest(){
            long id = 20;
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb;Trusted_Connection=True;").Options;
            IRepository<Person> arrange = new Repositiry(new ApplicationContext(op));

            var act = arrange.Find((int)id).Id;

            Assert.True(act == id);
        }

        [Fact]
        public void RemoveTest(){
            int id = 25;
            var ob = new DbContextOptionsBuilder<ApplicationContext>();
            var op = ob.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb;Trusted_Connection=True;").Options;
            IRepository<Person> arrange = new Repositiry(new ApplicationContext(op));

            var act = arrange.Remove(id);

            Assert.NotNull(act);
            Assert.IsType<Person>(act);
        }

        private List<Person> GetTestPersons(){
            var list = new List<Person>
            {
                new Person { Id=1, Name="Tom", DisplayName="a", Skills = new Skill[5] },
                new Person { Id=2, Name="Tom", DisplayName="a", Skills = new Skill[5] },
                new Person { Id=3, Name="Tom", DisplayName="a", Skills = new Skill[5] },
                new Person { Id=4, Name="Tom", DisplayName="a", Skills = new Skill[5] },
                new Person { Id=5, Name="Tom", DisplayName="a", Skills = new Skill[5] }
            };
            return list;
        }
    }
}
