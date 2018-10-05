using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? VisaExpiredate { get; set; }
    }
}
