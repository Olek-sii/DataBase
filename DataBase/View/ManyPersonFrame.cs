using DataBase.View;
using DataBaseApi;
using System.Drawing;
using System.Windows.Forms;

namespace DataBaseWinForms
{
	class ManyPersonFrame : Panel
	{
		private XCommand _xCommand = new XCommand();
		private PersonCardViewHolder _personCardViewHolder;

		public ManyPersonFrame()
		{
			Button btnCreate = new Button();
			btnCreate.Text = "Create";
			btnCreate.Location = new Point(5, 5);
			btnCreate.Size = new Size(50, 30);
			btnCreate.Click += BtnCreate_Click;
			Controls.Add(btnCreate);

			Button btnRead = new Button();
			btnRead.Text = "Read";
			btnRead.Location = new Point(65, 5);
			btnRead.Size = new Size(50, 30);
			btnRead.Click += BtnRead_Click;
			Controls.Add(btnRead);

			ComboBox dbSelector = new ComboBox();
			dbSelector.Location = new Point(120, 10);
			dbSelector.Size = new Size(90, 30);
			dbSelector.Items.AddRange(new string[] {
				"Mock",
				"MsSQL",
				"MySQL",
				"H2",
				"MongoDB",
				"CSV",
				"JSON",
				"XML",
				"YAML",
				"CSVLib",
				"JSONLib",
				"XMLLib",
				"YAMLLib"
			});
			dbSelector.SelectedIndexChanged += DbSelector_SelectedIndexChanged;
			Controls.Add(dbSelector);

			TextBox searchText = new TextBox();
			searchText.Location = new Point(225, 10);
			searchText.Size = new Size(100, 30);
			searchText.TextChanged += SearchText_TextChanged;
			Controls.Add(searchText);

			_personCardViewHolder = new PersonCardViewHolder(_xCommand);
			_personCardViewHolder.Dock = DockStyle.Bottom;
			_personCardViewHolder.BackColor = Color.LightBlue;
			_personCardViewHolder.Height = 400;
			Controls.Add(_personCardViewHolder);

			_personCardViewHolder.AutoScroll = true;
		}

		private void SearchText_TextChanged(object sender, System.EventArgs e)
		{
			TextBox searchText = (TextBox)sender;
			_personCardViewHolder.Fill( _xCommand.Filter(searchText.Text));		
		}

		private void DbSelector_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboBox dbSelector = (ComboBox)sender;
			_xCommand.DataBase = DBFactory.getInstance(dbSelector.SelectedItem.ToString());
		}

		private void BtnRead_Click(object sender, System.EventArgs e)
		{
			_personCardViewHolder.Fill(_xCommand.Read());
		}

		private void BtnCreate_Click(object sender, System.EventArgs e)
		{
			using (var form = new SinglePersonForm(null))
			{
				var result = form.ShowDialog();
				if (result == DialogResult.OK)
				{
					_xCommand.Create(form._person);
				}
			}
		}
	}
}
