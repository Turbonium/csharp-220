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
        bool? nameSortAsc = null;
        bool? passwordSortAsc = null;

        public SecondWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1" });
            users.Add(new Models.User { Name = "Steve", Password = "3" });
            users.Add(new Models.User { Name = "Lisa", Password = "2" });
            users.Add(new Models.User { Name = "Albert", Password = "4" });

            uxList.ItemsSource = users;
            AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new RoutedEventHandler(ListView_OnColumnClick));
        }

        

        private void ListView_OnColumnClick(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();

            if (e.OriginalSource.ToString().Contains("Name"))
            {
                if (nameSortAsc == false || nameSortAsc == null)
                {
                    nameSortAsc = true;
                    view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));                    
                }
                else
                {
                    nameSortAsc = false;
                    view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
                }
            }

            if (e.OriginalSource.ToString().Contains("Password"))
            {
                if (passwordSortAsc == false || passwordSortAsc == null)
                {
                    passwordSortAsc = true;
                    view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
                }
                else
                {
                    passwordSortAsc = false;
                    view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Descending));
                }
            }
        }
    }
}
