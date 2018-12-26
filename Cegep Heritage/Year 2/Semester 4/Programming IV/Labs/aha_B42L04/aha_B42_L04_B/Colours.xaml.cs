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

namespace aha_B42_L04_B
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

        private void fillRect(object sender, RoutedEventArgs e)
        {
            // Create a horizontal linear gradient with two stops.   
            LinearGradientBrush myGradient = new LinearGradientBrush();
            // Gradient runs x and y from 0 to 1 where 0,0 is top left.   
	        // and 1,1 is bottom right.
            myGradient.StartPoint = new Point(0,0.5);
            myGradient.EndPoint = new Point(1,0.5);
            Color firstColor = getFirstColor();
            Color secondColor = getSecondColor();
            myGradient.GradientStops.Add(new GradientStop(firstColor, 0.0));
            myGradient.GradientStops.Add(new GradientStop(secondColor, 1.0));                

	        // Use the brush to paint the rectangle.
            myRect.Fill = myGradient;

            
        }

        private Color getFirstColor()
        {
            Color firstColor = new Color();

            if (mnuiBlue.IsChecked)
                firstColor = Colors.Blue;
            if (mnuiRed.IsChecked)
                firstColor = Colors.Red;
            if (mnuiYellow.IsChecked)
                firstColor = Colors.Yellow;
            if (mnuiGrey.IsChecked)
                firstColor = Colors.Gray;

            return firstColor;
        }

        private Color getSecondColor()
        {
            Color secondColor = new Color();
            if (mnuiGreen.IsChecked)
                secondColor = Colors.Green;
            if (mnuiOrange.IsChecked)
                secondColor = Colors.Orange;
            if (mnuiPurple.IsChecked)
                secondColor = Colors.Purple;
            if (mnuiBlack.IsChecked)
                secondColor = Colors.Black;
            return secondColor;

        }

        private void btnBlue_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush myBrush;
            myBrush = new SolidColorBrush(Colors.Blue);
            myRect.Fill =  myBrush;
            uncheckAll();

        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush myBrush;
            myBrush = new SolidColorBrush(Colors.Red);
            myRect.Fill = myBrush;
            uncheckAll();
        }

        private void btnGreen_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush myBrush;
            myBrush = new SolidColorBrush(Colors.Green);
            myRect.Fill = myBrush;
            uncheckAll();
        }

        private void btnGrey_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush myBrush;
            myBrush = new SolidColorBrush(Colors.Gray);
            myRect.Fill = myBrush;
            uncheckAll();
        }

        private void mnuiBlue_Checked(object sender, RoutedEventArgs e)
        {
            mnuiRed.IsChecked = false;
            mnuiYellow.IsChecked = false;
            mnuiGrey.IsChecked = false;
        }

        private void mnuiRed_Checked(object sender, RoutedEventArgs e)
        {
            mnuiBlue.IsChecked = false;
            mnuiYellow.IsChecked = false;
            mnuiGrey.IsChecked = false;
        }

        private void mnuiYellow_Checked(object sender, RoutedEventArgs e)
        {
            mnuiRed.IsChecked = false;
            mnuiBlue.IsChecked = false;
            mnuiGrey.IsChecked = false;
        }

        private void mnuiGrey_Checked(object sender, RoutedEventArgs e)
        {
            mnuiRed.IsChecked = false;
            mnuiYellow.IsChecked = false;
            mnuiBlue.IsChecked = false;
        }

        private void mnuiGreen_Checked(object sender, RoutedEventArgs e)
        {
            mnuiOrange.IsChecked = false;
            mnuiPurple.IsChecked = false;
            mnuiBlack.IsChecked = false;
        }

        private void mnuiOrange_Checked(object sender, RoutedEventArgs e)
        {
            mnuiGreen.IsChecked = false;
            mnuiPurple.IsChecked = false;
            mnuiBlack.IsChecked = false;
        }

        private void mnuiPurple_Checked(object sender, RoutedEventArgs e)
        {
            mnuiOrange.IsChecked = false;
            mnuiGreen.IsChecked = false;
            mnuiBlack.IsChecked = false;
        }

        private void mnuiBlack_Click(object sender, RoutedEventArgs e)
        {
            mnuiOrange.IsChecked = false;
            mnuiPurple.IsChecked = false;
            mnuiGreen.IsChecked = false;
        }

        private void mnuiRectangle_Click(object sender, RoutedEventArgs e)
        {
            myRect.Height = 100;
            myRect.Width = 200;
            myRect.RadiusY = 0;
            myRect.RadiusX = 0;
        }

        private void mnuiSquare_Click(object sender, RoutedEventArgs e)
        {
            myRect.Height = 100;
            myRect.Width = 100;
            myRect.RadiusY = 0;
            myRect.RadiusX = 0;
        }

        private void mnuiCircle_Click(object sender, RoutedEventArgs e)
        {
            myRect.Height = 100;
            myRect.Width = 100;
            myRect.RadiusX = 50;
            myRect.RadiusY = 50;
            
        }

        private void mnuiEllipse_Click(object sender, RoutedEventArgs e)
        {
            myRect.Width = 50;
            myRect.RadiusY = 100;
            myRect.RadiusX = 100;
        }

        private void uncheckAll()
        {
            mnuiBlack.IsChecked = false;
            mnuiBlue.IsChecked = false;
            mnuiGreen.IsChecked = false;
            mnuiGrey.IsChecked = false;
            mnuiOrange.IsChecked = false;
            mnuiPurple.IsChecked = false;
            mnuiRed.IsChecked = false;
            mnuiYellow.IsChecked = false;
        }
    }
}
