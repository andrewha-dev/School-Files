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
using aha_B42L02;

namespace aha_B42L02Demo
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

        private void btnCountNumbers_Click(object sender, RoutedEventArgs e)
        {
            Counting c = new Counting();
            long num = 0;
            bool res = Int64.TryParse(txtInput.Text, out num);
            if (res)
                lblResult.Content = c.countNumbers(Convert.ToInt64(txtInput.Text));
            else
                lblResult.Content = "Error: Cannot convert";
        }

        private void btnCountNumber_Click(object sender, RoutedEventArgs e)
        {
            Counting c = new Counting();
            lblResult.Content = c.countNumber(txtInput.Text);
            
        }

        private void btnCountLetter_Click(object sender, RoutedEventArgs e)
        {
            Counting c = new Counting();
            lblResult.Content = c.countLetters(txtInput.Text);
            
        }

        //Reason why u would separate it is because it is better to 
        //have an error generated at run time, whether then directly 
        //implement it into the code
        //Also you wanna seperate testing from the other project

    }
}
