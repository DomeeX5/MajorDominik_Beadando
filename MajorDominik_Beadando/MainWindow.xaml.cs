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
			
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Update_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
