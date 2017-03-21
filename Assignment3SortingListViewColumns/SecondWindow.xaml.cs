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
using System.ComponentModel;

namespace Assignment3SortingListViewColumns
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private bool sortAsc;

        public SecondWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1" });
            users.Add(new Models.User { Name = "Steve", Password = "3" });
            users.Add(new Models.User { Name = "Lisa", Password = "2" });
            users.Add(new Models.User { Name = "Albert", Password = "4" });

            uxList.ItemsSource = users;
        }


        private void ColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();
            var test = ((ContentControl)((GridViewColumnHeader)e.OriginalSource).Column.Header).Content.ToString();
            if (sortAsc == false)
            {
                view.SortDescriptions.Add(new SortDescription(test, ListSortDirection.Ascending));
                sortAsc = true;
            }
            else
            {
                view.SortDescriptions.Add(new SortDescription(test, ListSortDirection.Descending));
                sortAsc = false;
            }
        }
    }
}
