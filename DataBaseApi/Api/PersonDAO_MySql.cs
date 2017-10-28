using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
	class PersonDAO_MySQL : IPersonDAO
	{
		List<Person> persons = new List<Person>();
        string connectionString = @"server=localhost;user id=root;password=1234;database=person;persistsecurityinfo=True";
        public void Create(Person p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [Persons] (Id, Fn, Ln, Age) " +
                    $"VALUES ({p.Id}, '{p.Fn}', '{p.Ln}', {p.Age})", connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Person> Read()
        {
            List<Person> persons = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Persons];", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string fn = reader.GetString(1);
                    string ln = reader.GetString(2);
                    int age = reader.GetInt32(3);
                    persons.Add(new Person(id, fn, ln, age));
                }

            }
            return persons;
        }

        public void Update(Person p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [Persons]" +
                    $"SET Fn='{p.Fn}', Ln='{p.Ln}', Age={p.Age}" +
                    $"WHERE Id = {p.Id};", connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Person p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Delete FROM [Persons] " +
                    $"WHERE Id = {p.Id};", connection);
                command.ExecuteNonQuery();
            }

        }
    }
}