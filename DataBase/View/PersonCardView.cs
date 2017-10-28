using DataBaseApi;
using System.Windows.Forms;

namespace DataBase.View {
	class PersonCardView : Panel
	{
		public PersonCardView(Person person)
		{
			Label fn = new Label();
			fn.Parent = this;
			fn.Text = person.Fn;
			fn.Location = new System.Drawing.Point(20, 20);

			Button buttonEdit = new Button();
			buttonEdit.Parent = this;
			buttonEdit.Text = "Edit";
			buttonEdit.Location = new System.Drawing.Point(110, 20);
			buttonEdit.Click += ButtonEdit_Click;
		}

		private void ButtonEdit_Click(object sender, System.EventArgs e) {
			var form = new SinglePersonForm();
			form.ShowDialog();
		}
	}
}
