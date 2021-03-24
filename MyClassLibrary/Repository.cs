using System.Linq;
using MyClassLibrary.Models;
using System.Collections.Generic;

namespace MyClassLibrary
{
    public class Repositiry : IRepository<Person>
    {
        private ApplicationContext _db;

        public Repositiry(ApplicationContext context){
            _db = context;
        }
        public long Add(Person person){
            _db.Persons.Add(person);
            _db.SaveChanges();
            long id = _db.Persons.Count();
            return id;
        }
        public IEnumerable<Person> GetAll(){
            return _db.Persons.ToArray();
        }
        public Person Find(int id){
            return _db.Persons.FirstOrDefault(p => p.Id == id);
        }
        public Person Remove(int id){
            Person person = _db.Persons.FirstOrDefault(p => p.Id == id);
            _db.Persons.Remove(person);
            _db.SaveChanges();
            return person;
        }
        public Person Update(int id, Person itm){
            Person person = _db.Persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
                return null;

            person.Name = itm.Name;
            person.DisplayName = itm.DisplayName;
            person.Skills = itm.Skills;
            _db.Update(person);
            _db.SaveChanges();
            return person;
        }
    }
}
