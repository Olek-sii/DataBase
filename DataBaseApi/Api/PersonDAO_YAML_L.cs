using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace DataBaseApi
{
    class PersonDAO_YAML_Lib : IPersonDAO
    {
        string path = "YAMLL_DB.txt";
        public void Create(Person p)
        {
            Deserializer dr = new Deserializer();
            StreamReader sr;
            List<Person> li;
            try
            {
                sr = new StreamReader(path);
                li = dr.Deserialize<List<Person>>(sr);
                sr.Close();
            }
            catch (Exception)
            {
                li = new List<Person>();
            }
            li.Add(p);
            Serializer sy = new Serializer();
            StreamWriter sw = new StreamWriter(path);
            sy.Serialize(sw, li);
            sw.Close();
        }

        public void Delete(Person p)
        {
            Deserializer dr = new Deserializer();
            StreamReader sr;
            List<Person> li;
            try
            {
                sr = new StreamReader(path);
                li = dr.Deserialize<List<Person>>(sr);
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
            Serializer sy = new Serializer();
            StreamWriter sw = new StreamWriter(path);
            sy.Serialize(sw, li);
            sw.Close();
        }

        public List<Person> Read()
        {
            Deserializer dr = new Deserializer();
            StreamReader sr;
            List<Person> li;
            try
            {
                sr = new StreamReader(path);
                li = dr.Deserialize<List<Person>>(sr);
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
            Deserializer dr = new Deserializer();
            StreamReader sr;
            List<Person> li;
            try
            {
                sr = new StreamReader(path);
                li = dr.Deserialize<List<Person>>(sr);
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
            Serializer sy = new Serializer();
            StreamWriter sw = new StreamWriter(path);
            sy.Serialize(sw, li);
            sw.Close();
        }
    }
}
