using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DataBaseApi
{
    class PersonDAO_JSON_Lib : IPersonDAO
    {
        string path = "JSONL_DB.txt";
        public void Create(Person p)
        {
            List<Person> li = new List<Person>();
            try
            {
                StreamReader sr = new StreamReader(path);
                string data = sr.ReadLine();
                li = JsonConvert.DeserializeObject<List<Person>>(data);
                sr.Close();
            }
            catch (Exception)
            {

            }
            li.Add(p);
            StreamWriter sw = new StreamWriter(path);
            string to_add = JsonConvert.SerializeObject(li);
            sw.Write(to_add);
            sw.Close();
        }

        public void Delete(Person p)
        {
            List<Person> li = new List<Person>();
            try
            {
                StreamReader sr = new StreamReader(path);
                string data = sr.ReadLine();
                li = JsonConvert.DeserializeObject<List<Person>>(data);
                sr.Close();
            }
            catch (Exception)
            {

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
            string to_add = JsonConvert.SerializeObject(li);
            sw.Write(to_add);
            sw.Close();
        }

        public List<Person> Read()
        {
            List<Person> li = new List<Person>();
            try
            {
                StreamReader sr = new StreamReader(path);
                string data = sr.ReadLine();
                li = JsonConvert.DeserializeObject<List<Person>>(data);
                sr.Close();
            }
            catch (Exception)
            {

            }
            return li;
        }

        public void Update(Person p)
        {
            List<Person> li = new List<Person>();
            try
            {
                StreamReader sr = new StreamReader(path);
                string data = sr.ReadLine();
                li = JsonConvert.DeserializeObject<List<Person>>(data);
                sr.Close();
            }
            catch (Exception)
            {

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
            string to_add = JsonConvert.SerializeObject(li);
            sw.Write(to_add);
            sw.Close();
        }
    }
}
