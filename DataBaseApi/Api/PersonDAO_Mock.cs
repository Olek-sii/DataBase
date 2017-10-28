using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Api
{
    class PersonDAO_Mock : IPersonDAO
    {

        SortedDictionary<int, Person> dict = new SortedDictionary<int, Person>();

		public PersonDAO_Mock() {
			Create(new Person(1, "qwe", "rty", 4));
			Create(new Person(2, "QWE", "rty", 44));
		}

        public void Create(Person p)
        {
            dict.Add(p.Id, p);
        }

        public List<Person> Read()
        {
            return dict.Values.ToList();
        }

        public void Update(Person p)
        { 
            dict[p.Id] = p;
        }

        public void Delete(Person p)
        {
            dict.Remove(p.Id);
        }
    }
}
