using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataBaseApi
{
    class PersonDAO_JSON : IPersonDAO
    {
        string path = "JSON_DB.txt";

        private string CurrentData()
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(path);
                string str = sr.ReadLine();
                sr.Close();
                return str;
            }
            catch(Exception)
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("{Persons:[]}");
                sw.Close();
                return "{Persons:[]}";
            }
        }

        private void ReCreateFromTMP()
        {
            StreamReader sr = new StreamReader("tmp.txt");
            StreamWriter sw = new StreamWriter(path);
            string str;
            str = sr.ReadLine();
            sw.WriteLine(str);
            sr.Close();
            sw.Close();
        }

        private string To_JSON(Person p)
        {
            string json_string = "{";
            json_string += "Id:" + p.Id + ",";
            json_string += "Fn:" + p.Fn + ",";
            json_string += "Ln:" + p.Ln + ",";
            json_string += "Age:" + p.Age + "";
            json_string += "}";
            return json_string;
        }
        private Person From_JSON(string str)
        {
            string[] args = str.Split(':', ',', '}');
            args = args.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            return new Person(Int32.Parse(args[1]), args[3], args[5], Int32.Parse(args[7]));
        }
        public void Create(Person p)
        {
            string data = CurrentData().TrimEnd(']','}');
            if (data.Length > 10)
                data += "},";
            data+= To_JSON(p) + "]}";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(data);
            sw.Close();
        }
        public void Delete(Person p)
        {
            StreamReader sr = new StreamReader(path);
            StreamWriter tmp = new StreamWriter("tmp.txt");
            string data = CurrentData();
            string[] JS_strings = data.Split('[', ']', '}');
            JS_strings = JS_strings.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            tmp.Write("{Persons:[");
            for (int i = 1; i < JS_strings.Length; ++i)
            {
                Person p_db = From_JSON(JS_strings[i]);
                if (p_db.Id != p.Id)
                {
                    tmp.Write(JS_strings[i] + "}");
                }
                else if (i == 1)
                {
                    if (JS_strings.Length > 2)
                    {
                        JS_strings[2] = JS_strings[2].Remove(0, 1);
                    }
                }
            }
            tmp.Write("]}");
            tmp.Close();
            sr.Close();
            ReCreateFromTMP();
        }
        public List<Person> Read()
        {
            string data = CurrentData();
            string[] JS_strings = data.Split('[', ']','}');
            JS_strings = JS_strings.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            List<Person> li = new List<Person>();
            for(int i=1;i<JS_strings.Length;++i)
            {
                li.Add(From_JSON(JS_strings[i]));
            }
            return li;
        }
        public void Update(Person p)
        {
            StreamReader sr = new StreamReader(path);
            StreamWriter tmp = new StreamWriter("tmp.txt");
            string data = CurrentData();
            string[] JS_strings = data.Split('[', ']', '}');
            JS_strings = JS_strings.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            tmp.Write("{Persons:[");
            for (int i = 1; i < JS_strings.Length; ++i)
            {
                Person p_db = From_JSON(JS_strings[i]);
                if (p_db.Id != p.Id)
                {
                    tmp.Write(JS_strings[i]+"}");
                }
                else
                {
                    tmp.Write(To_JSON(p));
                }
                if (i != JS_strings.Length - 1)
                    tmp.Write(",");
            }
            tmp.Write("]}");
            tmp.Close();
            sr.Close();
            ReCreateFromTMP();
        }
    }
}
