using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkCinema.Models
{
    public class Movie:Entity
    {
        public string MovieName { get; set; }
        public string ImagePath { get; set; }
        public string MovieDate { get; set; }
        public string Age { get; set; }
        public string MovieFormat { get; set; }
        public string MovieLanguages { get; set; }
        public string MovieCondition { get; set; }
    }
}
