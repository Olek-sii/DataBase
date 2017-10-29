using DataBaseApi;
using System.Drawing;
using System.Windows.Forms;

namespace DataBase.View {
	class PersonCardView : Panel
	{
		private Person _person;
		private XCommand _xCommand;

		public PersonCardView(Person person, XCommand xCommand)
		{
			_person = person;
			_xCommand = xCommand;

			Label fn = new Label();
			fn.Parent = this;
			fn.Text = person.Fn;
			fn.Location = new Point(20, 20);
			fn.Size = new Size(100, 20);

			Label ln = new Label();
			ln.Parent = this;
			ln.Text = person.Ln;
			ln.Location = new Point(130, 20);
			ln.Size = new Size(100, 20);

			Button buttonEdit = new Button();
			buttonEdit.Parent = this;
			buttonEdit.Text = "Edit";
			buttonEdit.Location = new Point(250, 5);
			buttonEdit.Click += ButtonEdit_Click;

			Button buttonDelete = new Button();
			buttonDelete.Parent = this;
			buttonDelete.Text = "Remove";
			buttonDelete.Location = new Point(250, 25);
			buttonDelete.Click += ButtonDelete_Click;
		}

		private void ButtonDelete_Click(object sender, System.EventArgs e)
		{
			_xCommand.Delete(_person);
		}

		private void ButtonEdit_Click(object sender, System.EventArgs e) {
			using (var form = new SinglePersonForm(_person))
			{
				var result = form.ShowDialog();
				if (result == DialogResult.OK)
				{
					_xCommand.Update(form._person);
				}
			}
		}
	}
}
