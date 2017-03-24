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

namespace Assignment5TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool xTurn = true;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                Button btn = sender as Button;
            if (xTurn)
            {
                btn.Content = "X";
                xTurn = false;
            }
            else
            {
                btn.Content = "O";
                xTurn = true;
            }
        }
    }
}
