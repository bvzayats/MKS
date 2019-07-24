using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nedo_net.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsGranted { get; set; }
        public string Email { get; set; }
    }
}
