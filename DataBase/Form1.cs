using DataBaseApi;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace DataBaseWinForms
{
	public partial class Form1 : Form
	{
		TableModel tm = new TableModel();

		Panel cards = new Panel();

		public Form1()
		{
			InitializeComponent();

			dbSelector.SelectedIndex = 0;

			tm.SetDataBase("Mock");
		}

		private Person GetPerson()
		{
			int id = Int32.Parse(idTextBox.Text);
			string fn = fnTextBox.Text;
			string ln = lnTextBox.Text;
			int age = Int32.Parse(ageTextBox.Text);
			return new Person(id, fn, ln, age);
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			tm.Create(GetPerson());
		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			Controls.Remove(cards);
			cards = tm.Read();
			cards.Dock = DockStyle.Bottom;
			cards.Width = Width;
			cards.BackColor = Color.Bisque;
			cards.Height = 400;
			Controls.Add(cards);
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			tm.Update(GetPerson());
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			tm.Delete(GetPerson());
		}

		private void dbSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			tm.SetDataBase(dbSelector.SelectedItem.ToString());
		}
	}
}