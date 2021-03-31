using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyClassLibrary;
using MyClassLibrary.Models;
using System.Data.Entity;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IRepository<Person> _repository;

        public PersonsController(IRepository<Person> repository){
            _repository = repository;
        }

        // GET: api/<PersonsController>
        [HttpGet]
        public IEnumerable<Person> Get(){
            return _repository.GetAll();
        }

        // GET api/<PersonsController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id){
            var person = _repository.Find(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST api/<PersonsController>
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person){
            if (person == null)
                return BadRequest();

            _repository.Add(person);
            return Ok("successfully");
        }

        // PUT api/<PersonsController>/5
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, [FromBody] Person itm){
            var person = _repository.Update(id, itm);
            if (person == null)
                BadRequest();

            return Ok(person);
        }

        // DELETE api/<PersonsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(int id){
            var person = _repository.Remove(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }
    }
}
