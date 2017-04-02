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
using GameInventory.Models;
using System.ComponentModel;
using GameInventory;

namespace GameInventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private GameModel selectedGame;

        public MainWindow()
        {
            InitializeComponent();
            LoadGames();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow();

            if (window.ShowDialog() == true)
            {
                App.GameRepository.Add(window.Games.ToRepositoryModel());
                LoadGames();
            }
        }

        private void LoadGames()
        {
            var games = App.GameRepository.GetAll();

            uxGamesList.ItemsSource = games
                .Select(t => GameModel.ToModel(t))
                .ToList();
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            // Perform a shallow copy of p1 and assign it to p2.
            var window = new GameWindow();
            window.Games = selectedGame.Clone();

            if (window.ShowDialog() == true)
            {

                App.GameRepository.Update(window.Games.ToRepositoryModel());
                LoadGames();
            }
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.GameRepository.Remove(selectedGame.GameId);
            selectedGame = null;
            LoadGames();
        }

        private void ColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxGamesList.ItemsSource);
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                view.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            view.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                (
                    AdornedElement.RenderSize.Width - 15,
                    (AdornedElement.RenderSize.Height - 5) / 2
                );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }

        private void uxGamesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedGame = (GameModel)uxGamesList.SelectedValue;
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedGame != null);
            uxContextFileDelete.IsEnabled = (selectedGame != null);
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedGame != null);
            uxContextFileChange.IsEnabled = (selectedGame != null);
        }

        private void uxFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

