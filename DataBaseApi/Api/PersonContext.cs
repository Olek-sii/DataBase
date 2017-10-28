using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBaseApi.Api
{
    class PersonContext : DbContext
    {
        public PersonContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\6\DataBase+Serialization\DataBaseApi\EF\msSqlDbEF.mdf;Integrated Security=True;Connect Timeout=30")
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
