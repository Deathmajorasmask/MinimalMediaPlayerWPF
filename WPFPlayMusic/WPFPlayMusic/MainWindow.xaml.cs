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


namespace WPFPlayMusic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Song song = new Song();
            song.IDMusic = 1;
            song.SName = "Palm Trees";
            song.SArtist = "Baxter Dury";
            song.SDuracion = "00:03:50";
            song.SGenero = "Indie";

            string txtSongName = song.SName;
            TextBoxSongName.Text = "Hola";
        }

    }
}
