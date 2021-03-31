using System.Linq;
using MyClassLibrary.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

            if (person.Skills.Count > 0){
                foreach(var skill in person.Skills){
                    _db.Skills.Add(skill);
                    _db.SaveChanges();
                }
            }
            long count = _db.Persons.Count();
            return count;
        }
        public IEnumerable<Person> GetAll(){
            return _db.Persons.Include(p => p.Skills).ToArray();
        }
        public Person Find(int id){
            return _db.Persons.Include(p => p.Skills).FirstOrDefault(p => p.Id == id);
        }
        public Person Remove(int id){
            Person person = _db.Persons.FirstOrDefault(p => p.Id == id);
            _db.Persons.Remove(person);
            _db.SaveChanges();
            return person;
        }
        public Person Update(int id, Person itm){
            Person person = _db.Persons.Include(s => s.Skills).FirstOrDefault(p => p.Id == id);
            if (person == null)
                return person;

            person.Name = itm.Name;
            person.DisplayName = itm.DisplayName;
            _db.Update(person);
            _db.SaveChanges();

            if (itm.Skills.Count > 0 && person.Skills.Count > 0){
                foreach(var itmSkill in itm.Skills){
                    Skill skill = person.Skills.FirstOrDefault(s => s.Id == itmSkill.Id);
                    if (skill != null){
                        skill.Name = itmSkill.Name;
                        skill.Level = itmSkill.Level;
                        _db.Skills.Update(skill);
                        _db.SaveChanges();
                    }
                }
            }
            return person;
        }
    }
}