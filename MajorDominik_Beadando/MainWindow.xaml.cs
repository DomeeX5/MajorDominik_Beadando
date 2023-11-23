using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MajorDominik_Beadando
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		PeopleService service = new PeopleService();
		public MainWindow()
		{
			InitializeComponent();
			peopleList.ItemsSource = service.GetAll();
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			PersonForm personForm = new PersonForm();
			personForm.Closed += (_, _) =>
			{
				peopleList.ItemsSource = service.GetAll();
			};
			personForm.ShowDialog();
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			Person selected = peopleList.SelectedItem as Person;
			if (selected == null)
			{
				MessageBox.Show("A törléshez jelölj ki egy elemet!", "Hiba", MessageBoxButton.OK);
				return;
			}
			MessageBoxResult result = MessageBox.Show($"Biztos, hogy törölni szeretnéd ezt az embert: {selected.Name}?", "Biztos?", MessageBoxButton.YesNo);
			if (result == MessageBoxResult.Yes)
			{
				if (service.Delete(selected))
				{
					MessageBox.Show("Sikeres törlés!");
				}
				else
				{
					MessageBox.Show("Hiba történt törlés során!");
					return;
				}
				peopleList.ItemsSource = service.GetAll();
			}
		}

		private void Update_Click(object sender, RoutedEventArgs e)
		{
			Person selected = peopleList.SelectedItem as Person;
			if (selected == null)
			{
				MessageBox.Show("A módosításhoz jelölj ki egy elemet!", "Hiba", MessageBoxButton.OK);
				return;
			}
			PersonForm personForm = new PersonForm();
			personForm.Closed += (_, _) =>
			{
				peopleList.ItemsSource = service.GetAll();
			};
			personForm.ShowDialog();
		}
	}
}
