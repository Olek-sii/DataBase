using DataBaseApi;
using System.Collections.Generic;

namespace DataBaseWPF
{
	class TableModel
	{
		IPersonDAO db = null;

		public void SetDataBase(string key)
		{
			db = DBFactory.getInstance(key);
		}

		public void Create(Person p)
		{
			db.Create(p);
		}

		public List<Person> Read()
		{
			return db.Read();
		}

		public void Update(Person p)
		{
			db.Update(p);
		}

		public void Delete(Person p)
		{
			db.Delete(p);
		}
	}
}