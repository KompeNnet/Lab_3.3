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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Lab_3._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<int, GroupBox> groupsDictionary;

        public MainWindow()
        {
            InitializeComponent();
            groupsDictionary = new Dictionary<int, GroupBox>
            {
                { 0, EncycloGroup },
                { 1, FictionGroup },
                { 2, HistoricalGroup }
            };
        }

        private void ChooseGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*groupsDictionary[ChooseGenre.SelectedIndex].Visibility = Visibility.Visible;
            for (int i = 0; i < groupsDictionary.Count; i++)
            {
                if (i != ChooseGenre.SelectedIndex)
                {
                    groupsDictionary[ChooseGenre.SelectedIndex].Visibility = Visibility.Hidden;
                }
            }*/
        }
    }
}
