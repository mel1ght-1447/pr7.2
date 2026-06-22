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

namespace pr7._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
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
                    case Key.I:
                        InputItem_Click(sender, e);
                        break;
                    case Key.E:
                        ExitItem_Click(sender, e);
                        break;
                    case Key.A:
                        AboutItem_Click(sender, e);
                        break;
                }
            }
        }

        private void InputItem_Click(object sender, RoutedEventArgs e)
        {
            Calculation window = new Calculation();
            window.Show();

        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            WindowAbout about = new WindowAbout();
            about.Show();
        }
    }
}
