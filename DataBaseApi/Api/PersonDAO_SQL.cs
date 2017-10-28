using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataBaseApi.Api
{
    class PersonDAO_SQL : IPersonDAO
    {
        IPersonDAO dao;

        public PersonDAO_SQL(string type)
        {
            switch (type)
            {
                case "MsSQL": dao = new PersonDAO_MsSQL(); break;
                case "MySQL": dao = new PersonDAO_MySQL(); break;
                case "H2": dao = new PersonDAO_H2(); break;
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
