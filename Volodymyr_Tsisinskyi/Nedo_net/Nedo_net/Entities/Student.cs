using System;
using System.Data;

namespace Nedo_net.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsGranted { get; set; }
        public string Email { get; set; }

        public Student() { }

        public Student(DataRow row)
        {
            this.Id = Convert.ToInt32(row["Id"]);
            this.FName = row["FName"].ToString();
            this.LName = row["LName"].ToString();
            this.IsGranted = Convert.ToBoolean(row["IsGranted"]);
            this.Email = row["Email"].ToString();

        }
    }
}
