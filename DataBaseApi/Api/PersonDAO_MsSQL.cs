using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseApi
{
	class PersonDAO_MsSQL : IPersonDAO
	{
		string connectionString = @"Data Source=COMP07\SQLEXPRESS;Initial Catalog=Person;Integrated Security=True";
		public void Create(Person p)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(
					"INSERT INTO [Persons] (Id, Fn, Ln, Age) " +
					$"VALUES ({null}, '{p.Fn}', '{p.Ln}', {p.Age})", connection);
				command.ExecuteNonQuery();

                if (p.PhoneNumbers.Count != 0)
                {
                    SqlCommand commandPhones;
                    for (int i = 0; i < p.PhoneNumbers.Count; ++i)
                    {
                        commandPhones = new SqlCommand(
                            "INSERT INTO [phone_numbers] (Id, person_id, phone_number) " +
                            $"VALUES ({null}, '{p.Id}', '{p.PhoneNumbers[i]}')", connection);
                        commandPhones.ExecuteNonQuery();
                    }
                }
            }
		}

		public List<Person> Read()
		{
			List<Person> persons = new List<Person>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand("SELECT * FROM Persons;", connection);
				SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
				{
					int id = reader.GetInt32(0);
					string fn = reader.GetString(1);
					string ln = reader.GetString(2);
					int age = reader.GetInt32(3);
                    List<string> phones = new List<string>();
                    SqlCommand commandPhones = new SqlCommand("SELECT FROM phone_numbers" +
                            $"WHERE person_id = {id};", connection);
                    SqlDataReader readerPhones = command.ExecuteReader();
                    while(readerPhones.Read())
                    {
                        phones.Add(reader.GetString(2));
                    }

                    persons.Add(new Person(id, fn, ln, age, phones));
				}

			}
			return persons;
		}

		public void Update(Person p)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand("UPDATE Persons" +
					$"SET Fn='{p.Fn}', Ln='{p.Ln}', Age={p.Age}" +
					$"WHERE Id = {p.Id};", connection);
				command.ExecuteNonQuery();

                if (p.PhoneNumbers.Count != 0)
                {
                    SqlCommand commandDelAddPhones = new SqlCommand(
                            "Delete FROM phone_numbers" +
                            $"WHERE person_id = {p.Id};", connection);
                    commandDelAddPhones.ExecuteNonQuery();

                    SqlCommand commandPhones;
                    for (int i = 0; i < p.PhoneNumbers.Count; ++i)
                    {
                        commandPhones = new SqlCommand(
                            "INSERT INTO [phone_numbers] (Id, person_id, phone_number) " +
                            $"VALUES ({null}, '{p.Id}', '{p.PhoneNumbers[i]}')", connection);
                        commandPhones.ExecuteNonQuery();
                    }
                }
            }
		}

		public void Delete(Person p)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand( "Delete FROM Persons " + 
					$"WHERE Id = {p.Id};", connection);
				command.ExecuteNonQuery();
                if (p.PhoneNumbers.Count != 0)
                {
                    SqlCommand commandPhones;commandPhones = new SqlCommand(
                            "Delete FROM phone_numbers" + 
                            $"WHERE person_id = {p.Id};", connection);
                        commandPhones.ExecuteNonQuery();
                }
            }
			
		}
	}
}