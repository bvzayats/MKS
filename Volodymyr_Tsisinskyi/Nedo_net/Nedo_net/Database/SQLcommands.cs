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

        public IEnumerable<T> SelectAll<T>(string query)
        {
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand(query, conn);
            dataAdapter.SelectCommand.ExecuteNonQuery();
            conn.Close();

            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            List<T> items = new List<T>();

            foreach (var row in dataTable.Rows)
            {
                T item = (T)Activator.CreateInstance(typeof(T), row);
                items.Add(item);
            }

            return items;
        }

        public T Select<T>(string query)
        {
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand(query, conn);
            dataAdapter.SelectCommand.ExecuteNonQuery();
            conn.Close();

            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            T item = (T)Activator.CreateInstance(typeof(T), dataTable.Rows[0]);

            return item;
        }

        public void Insert<T>(string query)
        {
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = new SqlCommand(query, conn);
            dataAdapter.InsertCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void Update<T>(string query)
        {
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.UpdateCommand = new SqlCommand(query, conn);
            dataAdapter.UpdateCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete<T>(string query)
        {
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.DeleteCommand = new SqlCommand(query, conn);
            dataAdapter.DeleteCommand.ExecuteNonQuery();
            conn.Close();
        }

    }
}
