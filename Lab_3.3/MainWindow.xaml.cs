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
using Lab_3._3.Books;

namespace Lab_3._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GroupBox> groupsMainList;
        private List<GroupBox> groupsHistList;
        private List<GroupBox> groupsFictList;
        private List<GroupBox> groupsFictFantList;
        private List<Book> bookList;
        private string[] cbbs;
        Factory bookOffice = new Factory();

        public MainWindow()
        {
            InitializeComponent();
            LoadingLists();
        }

        public void LoadingLists()
        {
            groupsMainList = new List<GroupBox>
            {
                EncycloGroup,
                FictionGroup,
                HistoricalGroup
            };
            groupsHistList = new List<GroupBox>
            {
                HistArtGroup,
                HistBiographyGroup
            };
            groupsFictList = new List<GroupBox>
            {
                FictFantasticTalesGroup,
                FictTravellingGroup
            };
            groupsFictFantList = new List<GroupBox>
            {
                FictFantFairyTalesGroup,
                FictFantScienceFictionGroup
            };
        }

        private void LoadBooks()
        {
            bookListForm.Items.Clear();
            foreach (var book in bookList)
            {
                bookListForm.Items.Add(book);
            }
        }

        private void DefaultCBBS(string state)
        {
            switch (state)
            {
                case "genr":
                    ChooseFictFantType.SelectedIndex = -1;
                    ChooseFictType.SelectedIndex = -1;
                    ChooseHistType.SelectedIndex = -1;
                    break;
                case "fict":
                    ChooseFictFantType.SelectedIndex = -1;
                    break;
            }
        }

        private bool Loadcbbs()
        {
            try
            {
                cbbs[0] = ChooseGenre.SelectedItem.ToString();
                if (ChooseGenre.SelectedIndex != 1)
                {
                    try
                    {
                        cbbs[1] = ChooseHistType.SelectedItem.ToString();
                    }
                    catch
                    {
                        cbbs[2] = ChooseFictType.SelectedItem.ToString();
                        cbbs[3] = ChooseFictFantType.SelectedItem.ToString();
                    }
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Incorrect info. Somewhere. Here ._.", "Smth goes wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void ChooseGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DefaultCBBS("genr");
            if (ChooseGenre.SelectedIndex != -1)
            {
                for (int i = 0; i < groupsMainList.Count; i++)
                {
                    if (ChooseGenre.SelectedIndex != i)
                        groupsMainList[i].Visibility = Visibility.Hidden;
                }
                groupsMainList[ChooseGenre.SelectedIndex].Visibility = Visibility.Visible;    
            }
        }

        private void ChooseHistType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChooseHistType.SelectedIndex != -1)
            {
                for (int i = 0; i < groupsHistList.Count; i++)
                {
                    if (ChooseHistType.SelectedIndex != i)
                        groupsHistList[i].Visibility = Visibility.Hidden;
                }
                groupsHistList[ChooseHistType.SelectedIndex].Visibility = Visibility.Visible;
            }
        }

        private void ChooseFictType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DefaultCBBS("fict");
            if (ChooseFictType.SelectedIndex != -1)
            {
                for (int i = 0; i < groupsFictList.Count; i++)
                {
                    if (ChooseFictType.SelectedIndex != i)
                        groupsFictList[i].Visibility = Visibility.Hidden;
                }
                groupsFictList[ChooseFictType.SelectedIndex].Visibility = Visibility.Visible;
            }
        }

        private void ChooseFictFantType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChooseFictFantType.SelectedIndex != -1)
            {
                for (int i = 0; i < groupsFictFantList.Count; i++)
                {
                    if (ChooseFictFantType.SelectedIndex != i)
                        groupsFictFantList[i].Visibility = Visibility.Hidden;
                }
                groupsFictFantList[ChooseFictFantType.SelectedIndex].Visibility = Visibility.Visible;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Loadcbbs())
            {
                Book curr = bookOffice.Create(cbbs);
                LoadBooks();
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            bookList.Remove((Book)bookListForm.SelectedItems);
            LoadBooks();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void BtnSerialize_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void BtnDeerialize_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }
    }
}
