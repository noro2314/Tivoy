using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Models
{
   public class Order
    {
        public int Id { get; set; }
        public int? TourId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
