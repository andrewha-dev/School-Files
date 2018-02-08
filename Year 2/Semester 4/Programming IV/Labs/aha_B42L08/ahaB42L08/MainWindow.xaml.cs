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
using L08BLL;
namespace ahaB42L08
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

        private void btnSearchAlbumId_Click(object sender, RoutedEventArgs e)
        {
            int albumIdToSearch = Convert.ToInt16(txtAlbumId.Text);
            Artist artist = new Artist();
            artist = artist.ArtistNameAndAlbumNameSingle(albumIdToSearch);
            lblAlbumTitleRes.Content = artist.Albums.ElementAt(0).Title;
            lblArtistNameRes.Content = artist.Name;
        }
    }
}
