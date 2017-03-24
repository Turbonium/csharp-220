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
            uxTurn.Text = "X's Turn (X always go first).";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (xTurn)
            {
                btn.Content = "X";
                btn.IsEnabled = false;
                xTurn = false;
                WinCondition(btn.Content.ToString());
            }
            else
            {
                btn.Content = "O";
                btn.IsEnabled = false;
                xTurn = true;
                WinCondition(btn.Content.ToString());
            }
        }

        private void WinCondition(string btnContent)
        {
            if (
                (Button0.Content == btnContent && Button1.Content == btnContent && Button2.Content == btnContent) ||
                //Row 1 Check
                (Button3.Content == btnContent && Button4.Content == btnContent && Button5.Content == btnContent) ||
                //Row 2 Check
                (Button6.Content == btnContent && Button7.Content == btnContent && Button8.Content == btnContent) ||
                //Row 3 Check
                (Button0.Content == btnContent && Button3.Content == btnContent && Button6.Content == btnContent) ||
                //Column 1 Check
                (Button1.Content == btnContent && Button4.Content == btnContent && Button7.Content == btnContent) ||
                //Column 2 Check
                (Button2.Content == btnContent && Button5.Content == btnContent && Button8.Content == btnContent) ||
                //Column 3 Check
                (Button0.Content == btnContent && Button4.Content == btnContent && Button8.Content == btnContent) ||
                //Diagonal L>R Check
                (Button2.Content == btnContent && Button4.Content == btnContent && Button6.Content == btnContent)
                //Diagonal R>L Check
            )
            {
                string player = btnContent;
                uxTurn.Text = $"Player {player} Wins!";
                MessageBox.Show($"Player {player} Wins!");
                disableButtons();
            }
            else
            {
                uxTurn.Text = (xTurn == true) ? "X's Turn!" : "O's Turn!";
                foreach (Button btn in uxGrid.Children)
                {
                    if (btn.IsEnabled == true)
                    {
                        return;
                    }
                }
                uxTurn.Text = "Game OVER! No Winner!";
                MessageBox.Show("Game Over, No Winner!");
            }
        }

        private void disableButtons()
        {
            foreach (Button btn in uxGrid.Children)
            {
                btn.IsEnabled = false;
            }
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in uxGrid.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
                xTurn = true;
                uxTurn.Text = "X's Turn (X always go first).";
            }
        }

        private void uxClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanks for playing!");
            Close();
        }
    }
}
