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

namespace aha_B42L04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnui1_Checked(object sender, RoutedEventArgs e)
        {
            grdLeft.Visibility = Visibility.Visible;
        }

        private void mnui1_Unchecked(object sender, RoutedEventArgs e)
        {
            grdLeft.Visibility = Visibility.Hidden;
        }
        private void mnui2_Checked(object sender, RoutedEventArgs e)
        {
            grdMiddle.Visibility = Visibility.Visible;
        }
        private void mnui2_Unchecked(object sender, RoutedEventArgs e)
        {
            grdMiddle.Visibility = Visibility.Hidden;
        }

        private void mnui3_Checked(object sender, RoutedEventArgs e)
        {
            grdRight.Visibility = Visibility.Visible;
        }

        private void mnui3_Unchecked(object sender, RoutedEventArgs e)
        {
            grdRight.Visibility = Visibility.Hidden;
        }
    }
}
