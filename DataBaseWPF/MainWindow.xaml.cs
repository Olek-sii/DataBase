using DataBaseApi;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DataBaseWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		TableModel tm = new TableModel();

		public MainWindow()
		{
			InitializeComponent();
			tm.SetDataBase(dbSelector.SelectedItem.ToString());
		}

		private Person GetPerson()
		{
			int id = Int32.Parse(idTextBox.Text);
			string fn = fnTextBox.Text;
			string ln = lnTextBox.Text;
			int age = Int32.Parse(ageTextBox.Text);
			return new Person(id, fn, ln, age);
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			tm.Create(GetPerson());
		}

		private void btnRead_Click(object sender, RoutedEventArgs e)
		{
			dataGridView.ItemsSource = tm.Read();
			dataGridView.Items.Refresh();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			tm.Update(GetPerson());
		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			tm.Delete(GetPerson());
		}

		private void dbSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			tm.SetDataBase(dbSelector.SelectedItem.ToString());
		}
	}
}
