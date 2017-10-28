using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Linq;

namespace DataBaseApi
{
    class PersonDAO_CSV_Lib : IPersonDAO
    {
        string path = "CSVL_DB.txt";
        public void Create(Person p)
        {
            StreamReader sr;
            List<Person> li = new List<Person>();
            try
            {
                sr = new StreamReader(path);
                var csvr = new CsvReader(sr);
                li = csvr.GetRecords<Person>().ToList();
                csvr.Dispose();
                sr.Close();
            }
            catch (Exception)
            {
            }
            li.Add(p);
            StreamWriter sw = new StreamWriter(path);
            var csv = new CsvWriter(sw);
            csv.WriteRecords(li);
            csv.Dispose();
            sw.Close();
        }

        public void Delete(Person p)
        {
            StreamReader sr;
            List<Person> li = new List<Person>();
            try
            {
                sr = new StreamReader(path);
                var csvr = new CsvReader(sr);
                li = csvr.GetRecords<Person>().ToList();
                csvr.Dispose();
                sr.Close();
            }
            catch (Exception e)
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
            var csv = new CsvWriter(sw);
            csv.WriteRecords(li);
            csv.Dispose();
            sw.Close();
        }

        public List<Person> Read()
        {
            StreamReader sr;
            List<Person> li = new List<Person>();
            try
            {
                sr = new StreamReader(path);
                var csvr = new CsvReader(sr);
                li = csvr.GetRecords<Person>().ToList();
                csvr.Dispose();
                sr.Close();
            }
            catch (Exception)
            {
            }
            return li;
        }

        public void Update(Person p)
        {
            StreamReader sr;
            List<Person> li = new List<Person>();
            try
            {
                sr = new StreamReader(path);
                var csvr = new CsvReader(sr);
                li = csvr.GetRecords<Person>().ToList();
                csvr.Dispose();
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
            var csv = new CsvWriter(sw);
            csv.WriteRecords(li);
            csv.Dispose();
            sw.Close();
        }
    }
}
