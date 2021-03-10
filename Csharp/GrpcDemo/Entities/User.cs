using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrpcDemo.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public List<Phone> Phones { get; set; }
    }
}