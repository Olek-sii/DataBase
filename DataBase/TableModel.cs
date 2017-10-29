
using DataBase.View;
using DataBaseApi;
using System.Collections.Generic;
using System.Data;

namespace DataBaseWinForms
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

		public PersonCardViewHolder Read()
		{
			//PersonCardViewHolder res = new PersonCardViewHolder();
			//List<Person> persons = db.Read();

			//foreach (Person person in persons)
			//{
			//	res.Add(new PersonCardView(person));
			//}

			//return res;
			throw new System.Exception();
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