using DataBaseApi.Api;
using System;

namespace DataBaseApi
{
	public class DBFactory
	{
		public static IPersonDAO getInstance(string key)
		{
			IPersonDAO db = null;

			switch (key)
			{
				case "MsSQL": db = new PersonDAO_MsSQL(); break;
				case "MySQL": db = new PersonDAO_MySQL(); break;
				case "H2": db = new PersonDAO_H2(); break;
                case "MongoDB": db = new PersonDAO_Mongo(); break;
                case "CSV": db = new PersonDAO_CSV(); break;
                case "JSON": db = new PersonDAO_JSON(); break;
                case "XML": db = new PersonDAO_XML(); break;
                case "YAML": db = new PersonDAO_YAML(); break;
                case "Mock": db = new PersonDAO_Mock(); break;
				default: throw new ArgumentException();
			}

			return db;
		}
	}
}