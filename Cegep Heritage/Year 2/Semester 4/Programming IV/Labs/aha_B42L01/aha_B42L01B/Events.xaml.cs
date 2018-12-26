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

namespace aha_B42L01B
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

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Events_Loaded(object sender, RoutedEventArgs e)
        {
            cbxCost.Items.Add("20");
            cbxCost.Items.Add("30");
            cbxCost.Items.Add("40");
            cbxCost.Items.Add("60");
            cbxCost.Items.Add("100");
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            lblEventTitle.Content = "Cost Estimate for " + txtName.Text;
            lblguestResult.Content = txtAmountGuests.Text;
            int amountGuest = Convert.ToInt16(txtAmountGuests.Text);
            int costOfGuest = Convert.ToInt16(cbxCost.SelectedValue);
            lblcostGuest.Content = costOfGuest;
            lblCostGuestTotal.Content = (costOfGuest * amountGuest).ToString("C");

            decimal theTotal = costOfGuest * amountGuest;


            if (rdLiveMusic.IsChecked == true)
            {
                lblMusicType.Content = "Live Music";
                lblMusicCost.Content = "$500";
                theTotal += 500;
            }
            else if (rdDJ.IsChecked == true)
            {
                lblMusicType.Content = "DJ";
                lblMusicCost.Content = "$500";
                theTotal += 500;
            }
            else if (rdMixed.IsChecked == true)
            {
                lblMusicType.Content = "Mixed";
                lblMusicCost.Content = "$500";
                theTotal += 500;
            }
            else
            {
                lblMusicType.Content = "None";
                lblMusicCost.Content = "$0";
            }

            if (opOpenBar.IsChecked == true)
            {
                lblOpenBar.Content = "Yes";
                lblOpenBarCost.Content = 30 * amountGuest;
                theTotal += 30 * amountGuest;
            }
            else
            {
                lblOpenBar.Content = "No";
                lblOpenBarCost.Content = "$0";
            }

            lblTotalCost.Content = theTotal.ToString("C");

        }
    }
}
