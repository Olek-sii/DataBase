using System;
using System.Collections.Generic;
using System.IO;

namespace DataBaseApi
{
    class PersonDAO_CSV : IPersonDAO
    {
        string path = "CSV_DB.txt";
        private void IsCreated()
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(path);
                string str = sr.ReadLine();
                sr.Close();
                if (str.Length == 0)
                    throw new Exception();

            }
            catch(Exception)
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("Id, Fn, Ln, Age, PhoneNumbers");
                sw.Close();
            }
        }
        private Person FromCSV(string str)
        {
            string[] args = str.Split(',');
            Person parsed = new Person(Int32.Parse(args[0].Trim(' ')), args[1].Trim(' '), args[2].Trim(' '), Int32.Parse(args[3].Trim(' ')));
            if (args.Length > 4)
            {
                for (int i=4; i< args.Length; ++i)
                {
                    parsed.AddPhoneNumber(args[i].Trim(' '));
                }
            }
            return parsed;
        }
        private string ToCSV(Person p)
        {
            string csv_string = "";

            csv_string += p.Id + ", ";
            csv_string += p.Fn + ", ";
            csv_string += p.Ln + ", ";
            csv_string += p.Age;
            if (p.PhoneNumbers != null)
            {
                foreach (string phone in p.PhoneNumbers)
                {
                    csv_string += ", "+phone;
                }
            }

            return csv_string;
        }
        private void ReCreateFromTMP()
        {
            StreamReader sr = new StreamReader("tmp.txt");
            StreamWriter sw = new StreamWriter(path);
            string str;
            while(!sr.EndOfStream)
            {
                str = sr.ReadLine();
                sw.WriteLine(str);
            }
            sr.Close();
            sw.Close();
        }

        public void Create(Person p)
        {
            IsCreated();
            string csv_string = ToCSV(p);
            StreamWriter sw = 
                new StreamWriter(File.Open(path, FileMode.Append, FileAccess.Write));
            sw.WriteLine(csv_string);
            sw.Close();
        }

        public void Delete(Person p)
        {
            IsCreated();
            StreamReader sr = new StreamReader(path);
            StreamWriter tmp = new StreamWriter("tmp.txt");
            string str = sr.ReadLine();
            tmp.WriteLine(str);
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine();
                Person p_db = FromCSV(str);
                if (p_db.Id != p.Id)
                {
                    tmp.WriteLine(str);
                }
            }
            tmp.Close();
            sr.Close();
            ReCreateFromTMP();
        }
        public List<Person> Read()
        {
            List<Person> li = new List<Person>();
            StreamReader data = new StreamReader(path);
            string str;
            data.ReadLine();
            while (!data.EndOfStream)
            {
                str = data.ReadLine();
                Person p = FromCSV(str);
                li.Add(p);
            }
            data.Close();
            return li;
        }
        public void Update(Person p)
        {
            IsCreated();
            StreamReader sr = new StreamReader(path);
            StreamWriter tmp = new StreamWriter("tmp.txt");
            string str = sr.ReadLine();
            tmp.WriteLine(str);
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine();
                Person p_db = FromCSV(str);
                if (p_db.Id != p.Id)
                {
                    tmp.WriteLine(str);
                }
                else
                {
                    tmp.WriteLine(ToCSV(p));
                }
            }
            tmp.Close();
            sr.Close();
            ReCreateFromTMP();
        }
    }
}
