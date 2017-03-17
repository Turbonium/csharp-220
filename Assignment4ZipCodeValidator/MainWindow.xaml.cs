using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Assignment4ZipCodeValidator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxZip_CodeEntered(object sender, TextChangedEventArgs e)
        {
            if (IsUsorCanadianZipCode(uxZipCode.Text))
            {
                uxSubmit.Content = "Submit";
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.Content = "Please Enter a Valid ZipCode";
                uxSubmit.IsEnabled = false;
            }
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A Valid Zipcode was entered:" + uxZipCode.Text);
        }

        string _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

        private bool IsUsorCanadianZipCode(string zipCode)
        {
            bool validZipCode = true;
            if ((!Regex.Match(zipCode, _usZipRegEx).Success) && (!Regex.Match(zipCode, _caZipRegEx).Success))
            {
                validZipCode = false;
            }
            return validZipCode;
        }
    }
}
