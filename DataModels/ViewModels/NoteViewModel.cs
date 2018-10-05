using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels { 
   public class NoteViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime AddDate { get; set; }
    }
}
