using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataBaseApi
{
    class PersonDAO_XML_Lib : IPersonDAO
    {
        string path = "XMLL_DB.txt";
        public void Create(Person p)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            List<Person> li;
            try
            {
                StreamReader sr = new StreamReader(path);
                li = (List<Person>)serializer.Deserialize(sr);
                sr.Close();
            }
            catch (Exception)
            {
                li = new List<Person>();
            }
            li.Add(p);
            StreamWriter sw = new StreamWriter(path);
            serializer.Serialize(sw, li);
            sw.Close();
        }

        public void Delete(Person p)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            List<Person> li;
            try
            {
                StreamReader sr = new StreamReader(path);
                li = (List<Person>)serializer.Deserialize(sr);
                sr.Close();
            }
            catch (Exception)
            {
                li = new List<Person>();
            }
            for (int i = 0; i < li.Count; ++i)
            {
                if (li[i].Id == p.Id)
                {
                    li.RemoveAt(i);
                    break;
                }
            }
            StreamWriter sw = new StreamWriter(path);
            serializer.Serialize(sw, li);
            sw.Close();
        }

        public List<Person> Read()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            List<Person> li;
            try
            {
                StreamReader sr = new StreamReader(path);
                li = (List<Person>)serializer.Deserialize(sr);
                sr.Close();
            }
            catch (Exception)
            {
                li = new List<Person>();
            }
            return li;
        }

        public void Update(Person p)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            List<Person> li;
            try
            {
                StreamReader sr = new StreamReader(path);
                li = (List<Person>)serializer.Deserialize(sr);
                sr.Close();
            }
            catch (Exception)
            {
                li = new List<Person>();
            }
            for (int i = 0; i < li.Count; ++i)
            {
                if (li[i].Id == p.Id)
                {
                    li.RemoveAt(i);
                    li.Insert(i, p);
                    break;
                }
            }
            StreamWriter sw = new StreamWriter(path);
            serializer.Serialize(sw, li);
            sw.Close();
        }
    }
}
