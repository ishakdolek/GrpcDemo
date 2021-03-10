using System.ComponentModel.DataAnnotations;

namespace GrpcDemo.Entities
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public string Fax { get; set; }
        public string SkypeId { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}