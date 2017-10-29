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
		int nextId = 0;

		public PersonDAO_Mock() {
			Create(new Person(0, "John", "Doe", 4));
			Create(new Person(0, "William", "Smith", 44));
            Create(new Person(0, "Sheila", "Smith", 37));
        }

        public void Create(Person p)
        {
			p.Id = nextId++;
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
