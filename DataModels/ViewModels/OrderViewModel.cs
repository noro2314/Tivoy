using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Note { get; set; }
        public int StatusId { get; set; }
        public int? TourId { get; set; }
        public string CustomerName { get; set; }
        public string TourName { get; set; }
        public int TourPrice { get; set; }
    }
}
