using System;
using System.Collections.Generic;
using System.IO;

namespace DataBaseApi
{
    class PersonDAO_XML : IPersonDAO
    {
        string path = "XML_DB.txt";
        private string ToXML(Person p)
        {
            string xml_string = "\t<Person>\n";
            xml_string += "\t\t<Id>" + p.Id + "</Id>\n";
            xml_string += "\t\t<Fn>" + p.Fn + "</Fn>\n";
            xml_string += "\t\t<Ln>" + p.Ln + "</Ln>\n";
            xml_string += "\t\t<Age>" + p.Age + "</Age>\n";
            xml_string += "\t</Person>\n";
            return xml_string;
        }
        private Person FromXML(string str)
        {
            string[] args = str.Split('\n', '>', '<');
            return new Person(Int32.Parse(args[4]), args[8], args[12], Int32.Parse(args[16]));
        }
        private void ReCreateFromTMP()
        {
            StreamReader sr = new StreamReader("tmp.txt");
            StreamWriter sw = new StreamWriter(path);
            string str;
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine();
                sw.WriteLine(str);
            }
            sr.Close();
            sw.Close();
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
                sw.Write("<Persons>\n</Persons>");
                sw.Close();
            }
        }

        public void Create(Person p)
        {
            IsCreated();
            List<string> data = CurrentData();
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < data.Count - 1; ++i)
            {
                sw.WriteLine(data[i]);
            }
            sw.Write(ToXML(p));
            sw.WriteLine(data[data.Count - 1]);
            sw.Close();
        }
        public void Delete(Person p)
        {
            IsCreated();
            List<string> data = CurrentData();
            List<Person> li = new List<Person>();
            StreamWriter sw = new StreamWriter("tmp.txt");
            string xml_string = "";
            sw.Write("<Persons>\n");
            for (int i = 1; i < data.Count; ++i)
            {
                if (i % 6 != 1 || i == 1)
                {
                    xml_string += data[i];
                }
                else
                {
                    if (FromXML(xml_string).Id != p.Id)
                    {
                        li.Add(FromXML(xml_string));
                    }
                    xml_string = data[i];
                }
            }
            foreach (Person per in li)
            {
                sw.Write(ToXML(per));
            }
            sw.Write("</Persons>");
            sw.Close();
            ReCreateFromTMP();
        }
        public List<Person> Read()
        {
            IsCreated();
            List<string> data = CurrentData();
            List<Person> li = new List<Person>();
            string xml_string = "";
            for (int i = 1; i < data.Count; ++i)
            {
                if (i % 6 != 1 || i == 1)
                {
                    xml_string += data[i];
                }
                else
                {
                    li.Add(FromXML(xml_string));
                    xml_string = data[i];
                }  
            }
            return li;
        }
        public void Update(Person p)
        {
            IsCreated();
            List<string> data = CurrentData();
            List<Person> li = new List<Person>();
            StreamWriter sw = new StreamWriter("tmp.txt");
            string xml_string = "";
            sw.Write("<Persons>\n");
            for (int i = 1; i < data.Count; ++i)
            {
                if (i % 6 != 1 || i == 1)
                {
                    xml_string += data[i];
                }
                else
                {
                    if (FromXML(xml_string).Id == p.Id)
                    {
                        li.Add(p);
                    }
                    else
                    {
                        li.Add(FromXML(xml_string));
                    }
                    xml_string = data[i];
                }
            }
            foreach(Person per in li)
            {
                sw.Write(ToXML(per));
            }
            sw.Write("</Persons>");
            sw.Close();
            ReCreateFromTMP();
        }
    }
}
