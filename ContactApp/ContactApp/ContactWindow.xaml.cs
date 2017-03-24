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
            if (uxHome.IsChecked.Value)
            {
                Contact.PhoneType = "Home";
            }
            else
            {
                Contact.PhoneType = "Mobile";
            }

            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Contact != null)
            {
                if (Contact.PhoneType == "Home")
                {
                    uxHome.IsChecked = true;
                }
                else
                {
                    uxMobile.IsChecked = true;
                }
                uxSubmit.Content = "Update";
            }
            else
            {
                Contact = new ContactModel();
                Contact.CreatedDate = DateTime.Now;
            }

            uxGrid.DataContext = Contact;
        }
    }
}