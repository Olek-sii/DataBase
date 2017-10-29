using DataBaseApi;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseWinForms
{
	public class XCommand
	{
		public IPersonDAO DataBase { get; set; }

		public void Create(Person person)
		{
			DataBase.Create(person);
		}

		public List<Person> Read()
		{
			return DataBase.Read();
		}

		public void Update(Person person)
		{
			DataBase.Update(person);
		}

		public void Delete(Person person)
		{
			DataBase.Delete(person);
		}

		public List<Person> Filter(string text)
		{
			return DataBase.Read().Where((x) => 
				x.Fn.ToLower().Contains(text.ToLower())
				|| x.Ln.ToLower().Contains(text.ToLower()))
				.ToList();
		}
	}
}
