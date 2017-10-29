using System;
using System.Collections.Generic;
using System.IO;

namespace DataBaseApi
{
    class PersonDAO_YAML : IPersonDAO
    {
        string path="YAML_DB.txt";
        private string ToYAML(Person p)
        {
            string yaml_string = "- ";
            yaml_string += "Id:" + p.Id;
            yaml_string += "\n  Fn:" + p.Fn;
            yaml_string += "\n  Ln:" + p.Ln;
            yaml_string += "\n  Age:" + p.Age + "\n";
            if (p.PhoneNumbers.Count != 0)
            {
                yaml_string += "\n  PhoneNumbers:" + "\n";

                for (int i = 0; i < p.PhoneNumbers.Count; ++i)
                {
                    yaml_string += "\n\t-Number" + i + ":" + p.PhoneNumbers[i] + "\n";
                }
            }

            return yaml_string;
        }
        private Person FromYAML(string str)
        {
            string[] args = str.Split('\n', ':');
            Person parsed = new Person(Int32.Parse(args[1]), args[3], args[5], Int32.Parse(args[7]));
            if (args.Length >= 10)
            {
                for (int i = 10; i < args.Length; i+=2)
                {
                    parsed.AddPhoneNumber(args[i].Trim(' '));
                }
            }
            return parsed;
        }
        
        private List<string> CurrentData()
        {
            StreamReader sr = new StreamReader(path);
            List<string> data = new List<string>();
            while (!sr.EndOfStream)
            {
                data.Add(sr.ReadLine());
            }
            sr.Close();
            return data;
        }
        public void Create(Person p)
        {
            IsCreated();
            StreamWriter sw = new StreamWriter(File.Open(path, FileMode.Append, FileAccess.Write));
            sw.Write(ToYAML(p));
            sw.Close();
        }
        private void ReCreate(List<Person> li)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write("Persons:\n");
            foreach(Person p in li)
            {
                sw.Write(ToYAML(p));
            }
            sw.Close();
        }
        public void Delete(Person p)
        {
            IsCreated();
            List<string> data = CurrentData();
            List<Person> li = new List<Person>();
            string yaml_string = "";
            int i = 0;
            while (++i < data.Count)
            {
                yaml_string += data[i] + "\n";
                if (i % 4 == 0)
                {
                    if (FromYAML(yaml_string).Id != p.Id)
                    {
                        li.Add(FromYAML(yaml_string));
                    }
                    yaml_string = "";
                }
            }
            ReCreate(li);
        }
        public List<Person> Read()
        {
            IsCreated();
            List<string> data = CurrentData();
            List<Person> li = new List<Person>();
            string yaml_string="";
            int i = 0;
            while(++i<data.Count)
            {
                yaml_string += data[i]+"\n";
                if(i%4==0)
                {
                    li.Add(FromYAML(yaml_string));
                    yaml_string = "";
                }
            }
            return li;
        }
        public void Update(Person p)
        {
            IsCreated();
            List<string> data = CurrentData();
            List<Person> li = new List<Person>();
            string yaml_string = "";
            int i = 0;
            while (++i < data.Count)
            {
                yaml_string += data[i] + "\n";
                if (i % 4 == 0)
                {
                    if (FromYAML(yaml_string).Id != p.Id)
                    {
                        li.Add(FromYAML(yaml_string));
                    }
                    else
                    {
                        li.Add(p);
                    }
                    yaml_string = "";
                }
            }
            ReCreate(li);
        }

        private void IsCreated()
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                sr.Close();
            }
            catch (Exception)
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Write("Persons:\n");
                sw.Close();
            }
        }
    }
}
