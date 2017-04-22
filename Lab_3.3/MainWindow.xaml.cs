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
using Lab_3._3.Serialize;

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
        private string cbbs;
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

        private bool Loadcbbs()
        {
            try
            {
                cbbs = ChooseGenre.SelectedItem.ToString();
                cbbs = ChooseGenre.Text;
                if (ChooseGenre.SelectedIndex != 0)
                {
                    try
                    {
                        cbbs = ChooseHistType.SelectedItem.ToString();
                        cbbs = ChooseHistType.Text;
                    }
                    catch
                    {
                        try
                        {
                            cbbs = ChooseFictType.SelectedItem.ToString();
                            cbbs = ChooseFictType.Text;
                            if (ChooseFictType.Text == "Fantastic tales")
                            {
                                try
                                {
                                    cbbs = ChooseFictFantType.SelectedItem.ToString();
                                    cbbs = ChooseFictFantType.Text;
                                } catch { return false; }
                                return true;
                            }
                            return true;
                        }
                        catch { return false; }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void UploadInfo(Book book)
        {
            //TODO
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

        private void HideGroups(string state)
        {
            switch (state)
            {
                case "FictFantType":
                    for (int i = 0; i < groupsFictFantList.Count; i++)
                    {
                        groupsFictFantList[i].Visibility = Visibility.Hidden;
                    }
                    break;
                case "genre":
                    HideGroups("FictFantType");
                    for (int i = 0; i < groupsFictList.Count; i++)
                    {
                        groupsFictList[i].Visibility = Visibility.Hidden;
                    }
                    for (int i = 0; i < groupsHistList.Count; i++)
                    {
                        groupsHistList[i].Visibility = Visibility.Hidden;
                    }
                    break;
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
                HideGroups("genre");
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
                HideGroups("FictFantType");
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
                
                if (curr != null)
                {
                    bookListForm.Items.Add(new ItemInList { Id = bookListForm.Items.Count + 1, Name = curr.Name, Author = curr.Author, Data = curr });
                }
            }
            else MessageBox.Show("Incorrect info. Somewhere. Here ._.", "Smth goes wrong", MessageBoxButton.OK, MessageBoxImage.Error);
        }           //LOAD DATA

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            while (bookListForm.SelectedItems.Count > 0)
            {
                bookListForm.Items.Remove(bookListForm.SelectedItems[0]);
            }
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
