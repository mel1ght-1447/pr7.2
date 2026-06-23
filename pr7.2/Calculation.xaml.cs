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
            if (Square.IsChecked == true)
            {
                CalcItem.IsEnabled = true;
            }
            else
            {
                MessageBox.Show($"Turn on Square button!", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                CalcItem.IsEnabled = false;
                return;
            }
            double.TryParse(tBDiagonal1.Text, out double diagonal1);
            double.TryParse(tBDiagonal2.Text, out double diagonal2);
            double.TryParse(tBAngle.Text, out double angle);
            double.TryParse(tBSide.Text, out double side);
            double.TryParse(tBRadius.Text, out double radius);


            double square = 0;
            string method = null;
            if (diagonal1 > 0 && diagonal2 > 0 && side > 0 && radius > 0 && angle > 0)
            {
                MessageBox.Show($"All parameters are entered!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearTextBox();
            }
            else if (angle > 0 && angle < 180 && side > 0)
            {
                double rad = angle * System.Math.PI / 180;
                square = side * side * System.Math.Sin(rad);
                method = "using side and angle";
                MessageBox.Show($"Squre: {System.Math.Round(square, 2)}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearTextBox();
            }
            else if (side > 0 && radius > 0)
            {
                if (radius >= (side / 2))
                {
                    MessageBox.Show($"The radius should be less than half the length of the side.", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    square = 2 * side * radius;
                    method = "using side and radius";
                    MessageBox.Show($"Squre: {System.Math.Round(square, 2)}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearTextBox();
                }

            }
            else if (diagonal1 > 0 && diagonal2 > 0)
            {
                square = diagonal1 * diagonal2 / 2;
                method = "using diagonals";
                MessageBox.Show($"Squre: {System.Math.Round(square, 2)}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
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


        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (Square.IsChecked == true)
            {
                CalcItem.IsEnabled = true;
            }
            else
            {
                MessageBox.Show($"Turn on Square button!", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                CalcItem.IsEnabled = false;
                return;
            }
            double.TryParse(tBDiagonal1.Text, out double diagonal1);
            double.TryParse(tBDiagonal2.Text, out double diagonal2);
            double.TryParse(tBAngle.Text, out double angle);
            double.TryParse(tBSide.Text, out double side);
            double.TryParse(tBRadius.Text, out double radius);


            double square = 0;
            string method = null;
            if (diagonal1 > 0 && diagonal2 > 0 && side > 0 && radius > 0 && angle > 0)
            {
                MessageBox.Show($"All parameters are entered!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearTextBox();
            }
            else if (angle > 0 && angle < 180 && side > 0)
            {
                double rad = angle * System.Math.PI / 180;
                square = side * side * System.Math.Sin(rad);
                method = "using side and angle";
                MessageBox.Show($"Squre: {System.Math.Round(square, 2)}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearTextBox();
            }
            else if (side > 0 && radius > 0)
            {
                if (radius >= (side / 2))
                {
                    MessageBox.Show($"The radius should be less than half the length of the side.", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    square = 2 * side * radius;
                    method = "using side and radius";
                    MessageBox.Show($"Squre: {System.Math.Round(square, 2)}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearTextBox();
                }

            }
            else if (diagonal1 > 0 && diagonal2 > 0)
            {
                square = diagonal1 * diagonal2 / 2;
                method = "using diagonals";
                MessageBox.Show($"Squre: {System.Math.Round(square, 2)}\nMethod: {method}", "rhomb", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearTextBox();
            }
            else
            {
                MessageBox.Show($"Check the entered parameters for calculating the Square!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearTextBox();
            }
        }
    }
}
