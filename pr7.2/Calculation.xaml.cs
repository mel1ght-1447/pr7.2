using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pr7._2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Calculation : Window
    {

        public Calculation()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //if (rBSquare.IsChecked == false)
            //{
            //    CalcItem.IsEnabled = false;
            //}
            //else
            //    CalcItem.IsEnabled = true;
        }

        private void CalcItem_Click(object sender, RoutedEventArgs e)
        {
            
            if (!double.TryParse(tBDiagonal1.Text, out double diagonal1) )
            {
                diagonal1 = 0;
            }
            if (!double.TryParse(tBDiagonal2.Text, out double diagonal2))
                diagonal2 = 0;
            if (!double.TryParse(tBAngle.Text, out double angle))
                angle = 0;
            if (!double.TryParse(tBSide.Text, out double side))
                side = 0;
            if (!double.TryParse(tBRadius.Text, out double radius))
                radius = 0;

            double square = 0;
            string method = null;
            if (diagonal1 > 0 && diagonal2 > 0 && angle == 0 && side == 0 && radius == 0)
            {
                square = diagonal1 * diagonal2 / 2;
                method = "using diagonals";
                MessageBox.Show($"Squre: {square}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (angle > 0 && angle < 180 && side > 0 && diagonal1 == 0 && diagonal2 == 0 && radius == 0)
            {
                double rad = angle * System.Math.PI / 180;
                square = side * side * System.Math.Sin(rad);
                method = "using side and angle";
                MessageBox.Show($"Squre: {square}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (side > 0 && radius > 0 && diagonal1 == 0 && diagonal2 == 0 && angle == 0)
            {
                square = 2 * side * radius;
                method = "using side and radius";
                MessageBox.Show($"Squre: {square}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show($"Check the entered parameters for calculating the Square!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
