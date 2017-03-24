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

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MouseWindow.xaml
    /// </summary>
    public partial class MouseWindow : Window
    {
        private void uxCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateStatus(e);

            if (uxCanvas.Children.Count > 0 && isMoving)
            {
                var ellipse = (Ellipse)uxCanvas.Children[0];

                Point location = e.GetPosition(null);

                // Move the ellipse to the new location
                //ellipse.Margin = new Thickness(
                //    location.X,
                //    location.Y,
                //    0, 0);

                //Excercise 2:  Take into account the downpoint and the margins
                ellipse.Margin = new Thickness(
                    ellipse.Margin.Left - (downPoint.X - location.X),
                    ellipse.Margin.Top - (downPoint.Y - location.Y),
                    0,0);

                downPoint = location;
            }
        }

        private bool isMoving;
        private Point downPoint;

        private void uxCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point location = e.GetPosition(null);
            downPoint = location;

            if (uxCanvas.Children.Count == 0)
            {
                var ellipse = new Ellipse();
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
                ellipse.Fill = mySolidColorBrush;
                ellipse.StrokeThickness = 2;
                ellipse.Stroke = Brushes.Black;

                ellipse.Height = 100;
                ellipse.Width = 100;

                ellipse.Margin = new Thickness(location.X, location.Y, 0, 0);

                uxCanvas.Children.Add(ellipse);
            }
            else
            {
                var element = uxCanvas.InputHitTest(location);
                if (element != null) isMoving = element is Ellipse;
            }

            UpdateStatus(e);
        }

        private void uxCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isMoving = false;
            UpdateStatus(e);
        }

        private void UpdateStatus(MouseEventArgs e)
        {
            Point location = e.GetPosition(null);
            uxStatus.Text = string.Format("({0},{1}) IsMoving={2}", location.X, location.Y, isMoving);
        }
    }
}
