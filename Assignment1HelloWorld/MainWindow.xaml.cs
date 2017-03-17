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

namespace Assignment1HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);
        }

        private void uxName_and_uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxName.Text.Trim().Length > 0 && uxPassword.Text.Trim().Length > 0)
            {
                uxSubmit.Content = "Submit";
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.Content = "Please enter a Username and Password";
                uxSubmit.IsEnabled = false;
            }
        }
    }
}
