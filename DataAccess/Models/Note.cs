using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NoteText { get; set; }
        public DateTime AddedDate { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
