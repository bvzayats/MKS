using System;
using System.Collections.Generic;

namespace WebAPISwagger
{
    public partial class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public int? NumberHostel { get; set; }
    }
}
