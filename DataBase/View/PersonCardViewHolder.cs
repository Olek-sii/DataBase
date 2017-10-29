using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataBaseApi;
using DataBaseWinForms;

namespace DataBase.View {
	class PersonCardViewHolder : Panel {

		private XCommand _xCommand;

		public PersonCardViewHolder(XCommand xCommand)
		{
			_xCommand = xCommand;
		}

		public void Add(Person person) {
			PersonCardView personCardView = new PersonCardView(person, _xCommand);
			personCardView.Location = new Point(0, Controls.Count * 50);
			personCardView.Width = Width;
			personCardView.Height = 50;
			personCardView.Anchor = AnchorStyles.Top;
			personCardView.BackColor = Color.FromArgb(
				personCardView.Location.Y % 255,
				100,
				200
			);

			Controls.Add(personCardView);
		}

		public void Fill(List<Person> persons)
		{
			Controls.Clear();
			foreach (Person person in persons)
			{
				Add(person);
			}
		}
	}
}
