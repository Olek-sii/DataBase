using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Api
{
    class PersonDAO_File : IPersonDAO
    {
        IPersonDAO dao;

        public PersonDAO_File(string type)
        {
            switch (type)
            {
                // LIB
                case "CSVL": dao = new PersonDAO_CSV_Lib(); break;
                case "JSONL": dao = new PersonDAO_JSON_Lib(); break;
                case "XMLL": dao = new PersonDAO_XML_Lib(); break;
                case "YAMLL": dao = new PersonDAO_YAML_Lib(); break;
                // Custom
                case "CSV": dao = new PersonDAO_CSV(); break;
                case "JSON": dao = new PersonDAO_JSON(); break;
                case "XML": dao = new PersonDAO_XML(); break;
                case "YAML": dao = new PersonDAO_YAML(); break;
                default: throw new ArgumentException();
            }
        }

        public void Create(Person p)
        {
            dao.Create(p);
        }

        public void Delete(Person p)
        {
            dao.Delete(p);
        }

        public List<Person> Read()
        {
            return dao.Read();
        }

        public void Update(Person p)
        {
            dao.Update(p);
        }
    }
}
