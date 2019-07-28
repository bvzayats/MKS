using System;
using System.Data;

namespace Nedo_net.Entities
{
    public class Student
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsGranted { get; set; }
        public string Email { get; set; }

        public Student() { }

        public Student(DataRow row)
        {
            this.FName = row["FName"].ToString();
            this.LName = row["LName"].ToString();
            this.IsGranted = Convert.ToBoolean(row["IsGranted"]);
            this.Email = row["Email"].ToString();

        }
    }
}
