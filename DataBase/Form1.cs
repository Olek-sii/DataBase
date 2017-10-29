using System.Windows.Forms;

namespace DataBaseWinForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			//InitializeComponent();

			Width = 365;
			Height = 480;
			ManyPersonFrame frame = new ManyPersonFrame();
			frame.Dock = DockStyle.Fill;
			Controls.Add(frame);
		}
	}
}