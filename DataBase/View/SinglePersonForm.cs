using DataBaseApi;
using System;
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

				foreach (var phone in _person.PhoneNumbers)
				{
					listView1.Items.Add(phone);
				}

			}
		}

		private void button1_Click(object sender, EventArgs e) {
			listView1.Items.Add(tbNewPhone.Text);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			_person.Fn = tbFn.Text;
			_person.Ln = tbLn.Text;
			_person.Age = Int32.Parse(tbAge.Text);
			_person.PhoneNumbers.Clear();

			foreach (ListViewItem item in listView1.Items)
			{
				_person.PhoneNumbers.Add(item.Text);
			}
				
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			//tbNewPhone.Text = listView1.SelectedItems.
		}

		private void btnDeleteNumber_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count != 0)
				listView1.Items.Remove(listView1.SelectedItems[0]);
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
