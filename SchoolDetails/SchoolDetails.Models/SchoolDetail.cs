using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDetails.Models
{
    public class SchoolDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string Website { get; set; }
        public string LogoUrl { get; set; }
        public long PhoneNumber { get; set; }
    }
}
