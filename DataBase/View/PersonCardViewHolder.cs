using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataBase.View {
	class PersonCardViewHolder : Panel {

		private List<PersonCardView> _personCardViews;

		private void Init() {

		}

		public PersonCardViewHolder()
		{
			_personCardViews = new List<PersonCardView>();
			Init();
		}

		public PersonCardViewHolder(List<PersonCardView> list) {
			_personCardViews = list;
			Init();
		}

		public void Add(PersonCardView personCardView) {
			personCardView.Location = new System.Drawing.Point(0, _personCardViews.Count * 50);
			personCardView.Width = Width;
			personCardView.Height = 50;
			personCardView.BackColor = Color.FromArgb(200, personCardView.Location.Y, 200);

			_personCardViews.Add(personCardView);
			Controls.Add(personCardView);
		}
	}
}
