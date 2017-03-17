using ContactApp.Models;
using System;
using System.Windows;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        public ContactWindow()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public ContactModel Contact { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Contact = new ContactModel();

            Contact.Name = uxName.Text;
            Contact.Email = uxEmail.Text;

            if (uxHome.IsChecked.Value)
            {
                Contact.PhoneType = "Home";
            }
            else
            {
                Contact.PhoneType = "Mobile";
            }

            Contact.PhoneNumber = uxPhoneNumber.Text;
            Contact.Age = (int)uxAge.Value;
            Contact.Notes = uxNotes.Text;
            Contact.CreatedDate = DateTime.Now;

            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}