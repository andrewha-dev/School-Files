using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace aha_B42L05
{
    /// <summary>
    /// Interaction logic for OwnerPet.xaml
    /// </summary>
    public partial class OwnerPet : Window
    {
        public OwnerPet()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            aha_B42L05.dsOwnerPet dsOwnerPet = ((aha_B42L05.dsOwnerPet)(this.FindResource("dsOwnerPet")));
            // Load data into the table HVK_OWNER1. You can modify this code as needed.
            aha_B42L05.dsOwnerPetTableAdapters.HVK_OWNER1TableAdapter dsOwnerPetHVK_OWNER1TableAdapter = new aha_B42L05.dsOwnerPetTableAdapters.HVK_OWNER1TableAdapter();
            dsOwnerPetHVK_OWNER1TableAdapter.Fill(dsOwnerPet.HVK_OWNER1);
            System.Windows.Data.CollectionViewSource hVK_OWNER1ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_OWNER1ViewSource")));
            hVK_OWNER1ViewSource.View.MoveCurrentToFirst();
            // Load data into the table HVK_PET. You can modify this code as needed.
            aha_B42L05.dsOwnerPetTableAdapters.HVK_PETTableAdapter dsOwnerPetHVK_PETTableAdapter = new aha_B42L05.dsOwnerPetTableAdapters.HVK_PETTableAdapter();
            dsOwnerPetHVK_PETTableAdapter.Fill(dsOwnerPet.HVK_PET);
            System.Windows.Data.CollectionViewSource hVK_OWNER1HVK_PETViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_OWNER1HVK_PETViewSource")));
            hVK_OWNER1HVK_PETViewSource.View.MoveCurrentToFirst();
        }

       

    }

    [ValueConversion(typeof(Char), typeof(String))]
    public class SizeConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "S")
                return "Small";
            else
                if (value.ToString() == "M")
                return "Medium";
            else
                if (value.ToString() == "L")
                return "Large";
            return "Unknown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
