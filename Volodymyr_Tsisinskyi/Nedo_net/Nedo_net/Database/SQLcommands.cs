using Nedo_net.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Nedo_net.Database
{
    public class SQLcommands
    {
        SqlConnection conn;

        public SQLcommands()
        {
            conn = DBUtils.GetDBConnection();
        }

        public Dictionary<int, Student> SelectAll()
        {
            List<Student> items = new List<Student>();

            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Student", conn);
            dataAdapter.SelectCommand.ExecuteNonQuery();
            conn.Close();

            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);


            foreach (var row in dataTable.Rows)
            {
                Student item = (Student)Activator.CreateInstance(typeof(Student), row);
                items.Add(item);
            }

            Dictionary<int, Student> _result = new Dictionary<int, Student>();
            for (int i = 0; i < items.Count; i++)
                _result.Add(i + 1, items[i]);


            return _result;
        }

        public Student Select(int id)
        {
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand(String.Format("SELECT * FROM Student WHERE Id = {0}", id), conn);
            dataAdapter.SelectCommand.ExecuteNonQuery();
            conn.Close();

            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            Student item = (Student)Activator.CreateInstance(typeof(Student), dataTable.Rows[0]);

            return item;
        }

        public void Insert(int id, Student value)
        {
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = new SqlCommand((String.Format("INSERT INTO Student (Id, FName, LName, IsGranted, Email) VALUES ({0}, '{1}', '{2}', {3}, '{4}')",
                                                                   id, value.FName, value.LName, value.IsGranted ? 1 : 0, value.Email)), conn);
            dataAdapter.InsertCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(int id, Student value)
        {
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.UpdateCommand = new SqlCommand(String.Format("UPDATE Student SET FName = '{0}', LName = '{1}', IsGranted = {2}, Email = '{3}' WHERE Id = {4}",
                                                                                    value.FName, value.LName, value.IsGranted ? 1 : 0, value.Email, id), conn);
            dataAdapter.UpdateCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.DeleteCommand = new SqlCommand(String.Format("DELETE FROM Student WHERE Id = {0}", id), conn);
            dataAdapter.DeleteCommand.ExecuteNonQuery();
            conn.Close();
        }

    }
}
