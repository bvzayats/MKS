using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tetiana_Test.Models
{
    public class MovieVodel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public float IMDb { get; set; }
        public string Critical_acclaim { get; set; }
    }
}
