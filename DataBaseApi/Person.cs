namespace DataBaseApi
{
	public class Person
	{
		public int Id { get; set; }
		public string Fn { get; set; }
		public string Ln { get; set; }
		public int Age { get; set; }

		public Person(int id, string fn, string ln, int age)
		{
			this.Id = id;
			this.Fn = fn;
			this.Ln = ln;
			this.Age = age;
		}

        public Person()
        {

        }

        public void Init(int Id, string FirstName, string LastName, int Age)
        {
            this.Id = Id;
            this.Fn = FirstName;
            this.Ln = LastName;
            this.Age = Age;
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