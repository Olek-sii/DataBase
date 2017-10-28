using System.Collections.Generic;

namespace DataBaseApi
{
    public interface IPersonDAO
    {
		void Create(Person p);
		List<Person> Read();
		void Update(Person p);
		void Delete(Person p);
	}
}