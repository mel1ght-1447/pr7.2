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
        private void ClearTextBox()
        {
            tBAngle.Clear();
            tBDiagonal1.Clear();
            tBDiagonal2.Clear();
            tBRadius.Clear();
            tBSide.Clear();
        }
        public Calculation()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (rBSquare.IsChecked == true)
            {
                CalcItem.IsEnabled = true;
            }
            else
                CalcItem.IsEnabled = false;
            this.PreviewKeyDown += Preview;
        }
        private void Preview(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.C:
                        CalcItem_Click(sender, e);
                        break;
                    case Key.B:
                        Back_Click(sender, e);
                        break;
                }
            }
        }
        private void CalcItem_Click(object sender, RoutedEventArgs e)
        {
            if (rBSquare.IsChecked == true)
            {
                CalcItem.IsEnabled = true;
            }
            else
            {
                CalcItem.IsEnabled = false;
                return;
            }

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
                ClearTextBox();
            }
            else if (angle > 0 && angle < 180 && side > 0 && diagonal1 == 0 && diagonal2 == 0 && radius == 0)
            {
                double rad = angle * System.Math.PI / 180;
                square = side * side * System.Math.Sin(rad);
                method = "using side and angle";
                MessageBox.Show($"Squre: {square}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearTextBox();
            }
            else if (side > 0 && radius > 0 && diagonal1 == 0 && diagonal2 == 0 && angle == 0)
            {
                square = 2 * side * radius;
                method = "using side and radius";
                MessageBox.Show($"Squre: {square}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearTextBox();

            }
            else
            {
                MessageBox.Show($"Check the entered parameters for calculating the Square!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearTextBox();
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
