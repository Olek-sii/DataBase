using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization
{
    public class Person
    {
        private int Id;
        private string FirstName;
        private string LastName;
        private int Age;
        public Person(int Id, string FirstName, string LastName, int Age)
        {
            Init(Id, FirstName, LastName, Age);
        }
        public Person()
        {

        }
        public void Init(int Id, string FirstName, string LastName, int Age)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }
        public string ToJson()
        {
            string json_string = "{";
            json_string += "Id:" + Id + ",";
            json_string += "FirstName:" + FirstName + ",";
            json_string += "LastName:" + LastName + ",";
            json_string += "Age:" + Age + "";
            json_string += "}";
            return json_string;
        }
        public void FromJson(string json_string)
        {
            string[] args = json_string.Split(':', ',', '}');
            Id = Int32.Parse(args[1]);
            FirstName = args[3];
            LastName = args[5];
            Age = Int32.Parse(args[7]);
        }
        public string ToCSV()
        {
            string csv_string = "";
            csv_string += Id + ", ";
            csv_string += FirstName + ", ";
            csv_string += LastName + ", ";
            csv_string += Age;
            return csv_string;
        }
        public void FromCSV(string csv_string)
        {
            string[] args = csv_string.Split(',');
            Id = Int32.Parse(args[0].Trim(' '));
            FirstName = args[1].Trim(' ');
            LastName = args[2].Trim(' ');
            Age = Int32.Parse(args[3].Trim(' '));
        }
        public string ToXML()
        {
            string xml_string = "<Person>";
            xml_string += "<Id>" + Id + "</Id>";
            xml_string += "<FirstName>" + FirstName + "</FirstName>";
            xml_string += "<LastName>" + LastName + "</LastName>";
            xml_string += "<Age>" + Age + "</Age>";
            xml_string += "</Person>";
            return xml_string;
        }
        public void FromXML(string xml_string)
        {
            string[] args = xml_string.Split('<', '>');
            Id = Int32.Parse(args[4]);
            FirstName = args[8];
            LastName = args[12];
            Age = Int32.Parse(args[16]);
        }
        public string ToYAML()
        {
            string yaml_string = "";
            yaml_string += "Id:" + Id;
            yaml_string += "\nFirstName:" + FirstName;
            yaml_string += "\nLastName:" + LastName;
            yaml_string += "\nAge:" + Age + "\n";
            return yaml_string;
        }
        public void FromYAML(string yaml_string)
        {
            string[] args = yaml_string.Split('\n', ':');
            Id = Int32.Parse(args[1]);
            FirstName = args[3];
            LastName = args[5];
            Age = Int32.Parse(args[7]);
        }
    }

    public class PersonSerializationReaders
    {
        public static List<Person> FromXML(string path)
        {
            List<Person> temp = new List<Person>();
            StreamReader data = new StreamReader(path);
            string str;
            while (!data.EndOfStream)
            {
                str = data.ReadLine();
                Person p = new Person();
                p.FromXML(str);
                temp.Add(p);
            }
            data.Close();
            return temp;
        }
        public static List<Person> FromCSV(string path)
        {
            List<Person> temp = new List<Person>();
            StreamReader data = new StreamReader(path);
            string str;
            data.ReadLine();
            while (!data.EndOfStream)
            {
                str = data.ReadLine();
                Person p = new Person();
                p.FromCSV(str);
                temp.Add(p);
            }
            data.Close();
            return temp;
        }
        public static List<Person> FromJson(string path)
        {
            List<Person> temp = new List<Person>();
            StreamReader data = new StreamReader(path);
            string str;
            while (!data.EndOfStream)
            {
                str = data.ReadLine();
                Person p = new Person();
                p.FromJson(str);
                temp.Add(p);
            }
            data.Close();
            return temp;
        }
        public static List<Person> FromYAML(string path)
        {
            List<Person> temp = new List<Person>();
            StreamReader data = new StreamReader(path);
            string str = "";
            while (!data.EndOfStream)
            {
                for (int i = 0; i < 4; ++i)
                {
                    str += data.ReadLine() + "\n";
                }
                Person p = new Person();
                p.FromYAML(str);
                temp.Add(p);
                str = "";
                data.ReadLine();
            }
            data.Close();
            return temp;
        }
        public static void ToXML(List<Person> persons, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            foreach (Person p in persons)
            {
                sw.WriteLine(p.ToXML());
            }
            sw.Close();
        }
        public static void ToCSV(List<Person> persons, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Id, FirstName, LastName, Age");
            foreach (Person p in persons)
            {
                sw.WriteLine(p.ToCSV());
            }
            sw.Close();
        }
        public static void ToYAML(List<Person> persons, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            foreach (Person p in persons)
            {
                sw.WriteLine(p.ToYAML());
            }
            sw.Close();
        }
        public static void ToJson(List<Person> persons, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            foreach (Person p in persons)
            {
                sw.WriteLine(p.ToJson());
            }
            sw.Close();
        }
    }
}
