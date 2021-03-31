using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using MyClassLibrary.Models;
using MyClassLibrary;
using MyTask.Controllers;
using Moq;

namespace UnitTestApp
{
    public class PersonsConrrollerTest
    {
        [Fact]
        public void GetAllTest(){
            var mock = new Mock<IRepository<Person>>();
            mock.Setup(p => p.GetAll()).Returns(GetTestPersons);
            var controller = new PersonsController(mock.Object);

            var act = controller.Get();

            var model = Assert.IsAssignableFrom<IEnumerable<Person>>(act);
            Assert.NotNull(act);
            Assert.Equal(act.Count(), model.Count());
        }

        [Fact]
        public void GetTest(){
            var mock = new Mock<IRepository<Person>>();
            mock.Setup(rep => rep.Find(1)).Returns(new Person { Id = 1, Name = "Tom", DisplayName = "a", Skills = new Skill[5] });
            var controller = new PersonsController(mock.Object);

            var act = controller.Get(1);

            Assert.NotNull(act);
            Assert.IsAssignableFrom<ActionResult<Person>>(act);
            Assert.IsType<OkObjectResult>(act.Result);
        }

        [Fact]
        public void PostTest(){
            var mock = new Mock<IRepository<Person>>();
            var controller = new PersonsController(mock.Object);

            var act = controller.Post(new Person { Id = 1, Name = "Tom", DisplayName = "a", Skills = new Skill[5] });

            Assert.IsType<OkObjectResult>(act.Result);
        }

        [Fact]
        public void PutTest(){
            int id = 1;
            Person person = new Person() { Name = "a", DisplayName = "b" };

            var mock = new Mock<IRepository<Person>>();
            mock.Setup(r => r.Update(id, person)).Returns(GetTestPersons().FirstOrDefault(p => p.Id == id));
            var controller = new PersonsController(mock.Object);

            var act = controller.Put(1, person);

            Assert.NotNull(act);
            Assert.IsType<OkObjectResult>(act.Result);
        }

        [Fact]
        public void DeleteTest(){
            int id = 5;
            var mock = new Mock<IRepository<Person>>();
            mock.Setup(r => r.Remove(id)).Returns(GetTestPersons().FirstOrDefault(p => p.Id == id));
            var controller = new PersonsController(mock.Object);

            var act = controller.Delete(id);

            Assert.NotNull(act.Value);
            Assert.IsType<OkObjectResult>(act.Result);
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
