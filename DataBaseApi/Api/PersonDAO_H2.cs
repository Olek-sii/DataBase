using System.Collections.Generic;
using java.sql;

namespace DataBaseApi
{
	class PersonDAO_H2 : IPersonDAO
	{
        List<Person> persons = new List<Person>();

        public PersonDAO_H2()
        {
            org.h2.Driver.load();
        }

        public void Create(Person p)
        {
            //persons.Add(p);
            using (Connection conn = DriverManager.getConnection("jdbc:h2:tcp://localhost/~/test", "sa", ""))
            {
                Statement stat = conn.createStatement();
                stat.execute("INSERT INTO persons (Id, FirstName, LastName, Age) " +
                    $"VALUES ({null}, '{p.Fn}', '{p.Ln}', {p.Age})");
                if (p.PhoneNumbers.Count != 0)
                {
                    Statement statPhones = conn.createStatement();
                    for (int i = 0; i < p.PhoneNumbers.Count; ++i)
                    {
                        stat.execute(
                            "INSERT INTO [phone_numbers] (Id, person_id, phone_number) " +
                            $"VALUES ({null}, '{p.Id}', '{p.PhoneNumbers[i]}')");
                    }
                }
            }
        }

        public List<Person> Read()
        {
            List<Person> persons = new List<Person>();

            using (Connection conn = DriverManager.getConnection("jdbc:h2:tcp://localhost/~/test", "sa", ""))
            {
                Statement stat = conn.createStatement();
                ResultSet rs = stat.executeQuery("SELECT * FROM PERSONS");
                while (rs.next())
                {
                    int id = rs.getInt("ID");
                    string fn = rs.getString("FirstName");
                    string ln = rs.getString("LastName");
                    int age = rs.getInt("Age");
                    persons.Add(new Person(id, fn, ln, age));
                }

            }
            return persons;
        }

        public void Update(Person p)
        {
            /*
            Person foundP = persons.Find(x => x.Id == p.Id);
            foundP.Fn = p.Fn;
            foundP.Ln = p.Ln;
            foundP.Age = p.Age;
            */
            using (Connection conn = DriverManager.getConnection("jdbc:h2:tcp://localhost/~/test", "sa", ""))
            {
                Statement stat = conn.createStatement();
                stat.execute("UPDATE persons " +
                    $"SET FirstName='{p.Fn}', LastName='{p.Ln}', Age={p.Age}" +
                    $"WHERE Id = {p.Id};");
            }
        }

        public void Delete(Person p)
        {
            //p = persons.Find(x => x.Id == p.Id);
            //persons.Remove(p);
            using (Connection conn = DriverManager.getConnection("jdbc:h2:tcp://localhost/~/test", "sa", ""))
            {
                Statement stat = conn.createStatement();
                stat.execute("Delete FROM persons " +
                    $"WHERE Id = {p.Id};");
                if (p.PhoneNumbers.Count != 0)
                {
                    Statement statPhones = conn.createStatement();
                    for (int i = 0; i < p.PhoneNumbers.Count; ++i)
                    {
                        stat.execute(
                            "Delete FROM phone_numbers" +
                            $"WHERE person_id = {p.Id};");
                    }
                }
            }
        }
    }
}