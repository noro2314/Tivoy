using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Models
{
    public class Customer
    {
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public DateTime? VisaExpiredate { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportIdNumber { get; set; }
        public int? ParentCustomerId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
