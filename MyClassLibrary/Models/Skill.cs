using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyClassLibrary.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(1,10)]
        public byte Level { get; set; }

        public long PersonId { get; set; }

        public Person Person { get; set; }
    }
}
