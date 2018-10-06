using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double? Review { get; set; }
        public int Rate { get; set; }
        public string MoreInfo { get; set; }
        public int Price { get; set; }

    }
}
