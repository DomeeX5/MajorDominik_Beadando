using MajorDominik_Beadando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MajorDominik_Beadando
{
	/// <summary>
	/// Interaction logic for PersonForm.xaml
	/// </summary>
	public partial class PersonForm : Window
	{
		PeopleService service = new PeopleService();
		Person person;
		public PersonForm()
		{
			InitializeComponent();
		}

		public PersonForm(Person person)
		{
			InitializeComponent();
			this.person = person;
			LoadPerson();
			buttonAdd.Visibility = Visibility.Collapsed;
			buttonUpdate.Visibility = Visibility.Visible;
		}

		private void LoadPerson()
		{
			textBoxNev.Text = this.person.Name;
			textBoxEmail.Text= this.person.Email;
			textBoxTelefonszam.Text = this.person.Phone.ToString();
		}

		private void buttonAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Person person = CreatePersonFromInputFields();
				Person newPerson = service.Add(person);
				if (newPerson.Id != 0)
				{
					MessageBox.Show("Sikeres felvétel");
					textBoxNev.Text = "";
					textBoxEmail.Text = "";
					textBoxTelefonszam.Text = "";
				}
				else
				{
					MessageBox.Show("Hiba történt a felvétel során");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void buttonUpdate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Person person = CreatePersonFromInputFields();
				Person updated = service.Update(this.person.Id, person);
				if (updated.Id != 0)
				{
					MessageBox.Show("Sikeres módosítás");
					this.Close();
				}
				else
				{
					MessageBox.Show("Hiba történt a módosítás során");
				}
			}
			catch (Exception)
			{
				throw;
			}

		}

		private Person CreatePersonFromInputFields()
		{
			string name = textBoxNev.Text.Trim();
			string email = textBoxEmail.Text.Trim();
			string phone = textBoxTelefonszam.Text;

			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("Név kitöltése kötelező!");
			}

			if (string.IsNullOrEmpty(email))
			{
				throw new Exception("Email kitöltése kötelező!");
			}

			if (string.IsNullOrEmpty(phone))
			{
				throw new Exception("Telefonszám kitöltése kötelező!");
			}
			Person person = new Person();
			person.Name = name;
			person.Email = email;
			person.Phone = phone;
			return person;
		}
	}
}
