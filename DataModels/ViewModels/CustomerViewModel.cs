using System;
using System.Collections.Generic;
using System.Text;
using DataModels.Enums;
namespace DataModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? VisaExpiredate { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? Gender { get; set; }
        public int UserId { get; set; }
        public int OrderCount { get; set; }
        public string CityName { get; set; }
        public string PassportIdNumber { get; set; }
        public List<NoteViewModel> Notes { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public string FullName => FirstName + " " + LastName;
        public bool ActiveVisa => VisaExpiredate.HasValue && VisaExpiredate.Value > DateTime.Now;
        public string DisplayBirthDate => BirthDate.HasValue? BirthDate.Value.ToShortDateString():"-";
        public string VisaDaysLeft => ActiveVisa ? ((int)(VisaExpiredate.Value-DateTime.Now).TotalDays).ToString()+ " day(s) left" : null;
        public string DisplayGender => Gender.HasValue ? ((DataModels.Enums.Gender)(Gender)).ToString() : null;
    }
}
