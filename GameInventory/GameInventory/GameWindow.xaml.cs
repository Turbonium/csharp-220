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
using System.Windows.Shapes;
using GameInventory.Models;

namespace GameInventory
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        public GameModel Games { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (uxDigital.IsChecked.Value)
            {
                Games.GameType = "Digital";
            }
            else
            {
                Games.GameType = "Physical";
            }

            if (uxXbox.IsChecked.Value)
            {
                Games.GamePlatform = "XBox";
            } else if (uxPC.IsChecked.Value)
            {
                Games.GamePlatform = "XBox";
            }
            else
            {
                Games.GamePlatform = "Board Game";
            }

            //Validation
            if (!validateInputs(Games))
            {
                DialogResult = false;
                Close();
            }
            else
            {
                DialogResult = true;
                Close();
            }
        }

        private bool validateInputs(GameModel gameModel)
        {
            decimal i;
            if (gameModel.GameQuantity <= 0) gameModel.GameQuantity = 1;
            bool costCheck = decimal.TryParse(gameModel.GameCostPerUnit.ToString(), out i);
            bool retailCheck = decimal.TryParse(gameModel.GameRetailPerUnit.ToString(), out i);

            if (!costCheck || gameModel.GameCostPerUnit < 0)
            {
                MessageBox.Show("Cost per unit must be a positive integer value!");
                return false;
            }

            if (!retailCheck || gameModel.GameRetailPerUnit < 0)
            {
                MessageBox.Show("Retail per unit must be a positive integer value!");
                return false;
            }
            gameModel.GameTotalCost = gameModel.GameQuantity * gameModel.GameCostPerUnit;
            gameModel.GameTotalRetail = gameModel.GameQuantity * gameModel.GameRetailPerUnit;
            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Games != null)
            {
                if (Games.GameType == "Digital")
                {
                    uxDigital.IsChecked = true;
                }
                else
                {
                    uxPhysical.IsChecked = true;
                }

                if (Games.GamePlatform == "XBox")
                {
                    uxXbox.IsChecked = true;
                }

                if (Games.GamePlatform == "PC")
                {
                    uxPC.IsChecked = true;
                }

                if (Games.GamePlatform == "Board Game")
                {
                    uxBoardGame.IsChecked = true;
                }


                uxSubmit.Content = "Update";
            }
            else
            {
                Games = new GameModel();
                Games.CreateDate = DateTime.Now;
            }

            uxGrid.DataContext = Games;
        }


        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void TextBox_KeyEnterUpdate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tBox = (TextBox)sender;
                DependencyProperty prop = TextBox.TextProperty;

                BindingExpression binding = BindingOperations.GetBindingExpression(tBox, prop);
                if (binding != null) { binding.UpdateSource(); }
            }
        }
    }
}