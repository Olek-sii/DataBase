using DataBaseApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase.View {
	public partial class SinglePersonForm : Form {
		public Person _person;

		public SinglePersonForm(Person person) {
			InitializeComponent();

			if (person == null)
				_person = new Person();
			else
			{
				_person = person;
				tbFn.Text = _person.Fn;
				tbLn.Text = _person.Ln;
				tbAge.Text = _person.Age.ToString();
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			_person.Fn = tbFn.Text;
			_person.Ln = tbLn.Text;
			_person.Age = Int32.Parse(tbAge.Text);
			Close();
		}
	}
}
