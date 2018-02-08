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

namespace aha_B42L01
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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            for(int x = 50; x <= 500; x+= 50)
            {
                cbxInvest.Items.Add(Convert.ToString(x));
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            cbxInvest.Text = "50";
            txtInterest.Text = "";
            txtYears.Text = "";
            lblFuture.Content = "";
        }

        protected decimal FutureValue(int months, decimal interestRate, decimal monthlyInvestment)
        {
            decimal calcValue = 0;
            for (int i = 0; i < months; i++)
            calcValue =+ (calcValue + monthlyInvestment) * (1 + interestRate);
            return calcValue;
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            //Converting Years to months
            int yearToMonth = Convert.ToInt16(txtYears.Text);
            yearToMonth = yearToMonth * 12;

            //The interest rate
            decimal interestRate = Convert.ToDecimal(txtInterest.Text);
            interestRate = interestRate / 12 / 100;

            //Amount of money invested
            decimal amountEachMonth = Convert.ToDecimal(cbxInvest.SelectedValue);

            lblFuture.Content = FutureValue(yearToMonth, interestRate, amountEachMonth).ToString("C");
        }
    }
}
