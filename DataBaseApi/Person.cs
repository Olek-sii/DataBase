using System.Collections.Generic;

namespace DataBaseApi
{
	public class Person
	{
		public int Id { get; set; }
		public string Fn { get; set; }
		public string Ln { get; set; }
		public int Age { get; set; }
        public List<string> PhoneNumbers { get; set; }

        public Person()
        {
            PhoneNumbers = new List<string>(); PhoneNumbers = new List<string>();
        }

        public Person(int id, string fn, string ln, int age)
		{
			this.Id = id;
			this.Fn = fn;
			this.Ln = ln;
			this.Age = age;
            PhoneNumbers = new List<string>();
        }

        public Person(int id, string fn, string ln, int age, List<string> phones)
        {
            this.Id = id;
            this.Fn = fn;
            this.Ln = ln;
            this.Age = age;
            this.PhoneNumbers = phones;
        }

        public void Init(int Id, string FirstName, string LastName, int Age)
        {
            this.Id = Id;
            this.Fn = FirstName;
            this.Ln = LastName;
            this.Age = Age;
        }

        public void AddPhoneNumber(string phone)
        {
            if (PhoneNumbers == null)
                PhoneNumbers = new List<string>();
            PhoneNumbers.Add(phone);
        }

        public static int CompareById(Person x, Person y)
        {
            if (x.Id > y.Id)
                return 1;
            else if (x.Id < y.Id)
                return -1;
            else
                return 0;
        }
    }
}