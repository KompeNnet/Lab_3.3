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
using Lab_3._3.Books.Fictions;
using Lab_3._3.Books.History;
using Lab_3._3.Classes;

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
        Dictionary<string, Finalization> resultDictionary;
        dynamic book;
        string requestedValue;
        public Action ActionCreation { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadingLists();
        }

        private void LoadingLists()
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
            resultDictionary = new Dictionary<string, Finalization>
            {
                { "Book", new Finalization(new Action(CreateBook), false) },
                { "Encyclopedia", new Finalization(new Action(CreateEncyclopedia), true) },
                { "Historical", new Finalization(new Action(CreateHistorical), false) },
                { "Art", new Finalization(new Action(CreateArt), true) },
                { "Biography", new Finalization(new Action(CreateBiography), true) },
                { "Fiction", new Finalization(new Action(CreateFiction), false) },
                { "Travelling", new Finalization(new Action(CreateTravelling), true) },
                { "FantasticTales", new Finalization(new Action(CreateFantasticTales), false) },
                { "ScienceFiction", new Finalization(new Action(CreateScienceFiction), true) },
                { "FairyTales", new Finalization(new Action(CreateFairyTales), true) }
            };
        }

        private dynamic CastType<T>(dynamic book)
        {
            return Serializer.Deserialize<T>(Serializer.Serialize(book));
        }

        private void CreateBook()
        {
            Book curr = new Book()
            {
                Author = InpAuthor.Text,
                Name = InpName.Text,
                PublishingOffice = InpPublishing.Text
            };
            book = curr;
        }

        private void CreateEncyclopedia()
        {
            Encyclopedia curr = CastType<Encyclopedia>(book);
            curr.Genre = "Encyclopedia";
            curr.Subject = InpEnSubject.Text;
            book = curr;
        }

        private void CreateHistorical()
        {
            Historical curr = CastType<Historical>(book);
            curr.Period = InpHistPeriod.Text;
            curr.Genre = "Historical";
            book = curr;
        }

        private void CreateArt()
        {
            Art curr = CastType<Art>(book);
            curr.ArtForm = InpHistArtForm.Text;
            book = curr;
        }

        private void CreateBiography()
        {
            Biography curr = CastType<Biography>(book);
            curr.Person = InpHistBioPerson.Text;
            curr.Years = InpHistBioYears.Text;
            book = curr;
        }

        private void CreateFiction()
        {
            Fiction curr = CastType<Fiction>(book);
            curr.Age = InpFictAge.Text;
            curr.Type = InpFictType.Text;
            curr.Genre = "Fiction";
            book = curr;
        }

        private void CreateTravelling()
        {
            Travelling curr = CastType<Travelling>(book);
            curr.Countries = InpFictTravCountries.Text;
            book = curr;
        }

        private void CreateFantasticTales()
        {
            FantasticTales curr = CastType<FantasticTales>(book);
            curr.CoAuthors = InpFictFantCoWorkers.Text;
            book = curr;
        }

        private void CreateFairyTales()
        {
            FairyTales curr = CastType<FairyTales>(book);
            curr.IsIllustrated = CheckFictFantFairyIsIllustrated.IsChecked.Value;
            book = curr;
        }

        private void CreateScienceFiction()
        {
            ScienceFiction curr = CastType<ScienceFiction>(book);
            curr.IsEarth = CheckFictFantFairyIsEarth.IsChecked.Value;
            book = curr;
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

        private string GetString(ComboBox cbb)
        {
            return ((ListBoxItem)cbb.Items[cbb.SelectedIndex]).Content.ToString();
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
                ActionCreation = new Action(CreateBook);
                //ActionCreation += resultDictionary[ChooseGenre.Text];
                ActionCreation += resultDictionary[GetString(ChooseGenre)].DataUpdate;
                BtnAdd.IsEnabled = (resultDictionary[GetString(ChooseGenre)].isFinal);
                if (BtnAdd.IsEnabled) requestedValue = GetString(ChooseGenre);
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
                ActionCreation = new Action(CreateBook);
                ActionCreation += resultDictionary[GetString(ChooseGenre)].DataUpdate;
                ActionCreation += resultDictionary[GetString(ChooseHistType)].DataUpdate;
                BtnAdd.IsEnabled = (resultDictionary[GetString(ChooseHistType)].isFinal);
                if (BtnAdd.IsEnabled) requestedValue = GetString(ChooseHistType);
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
                ActionCreation = new Action(CreateBook);
                ActionCreation += resultDictionary[GetString(ChooseGenre)].DataUpdate;
                ActionCreation += resultDictionary[GetString(ChooseFictType)].DataUpdate;
                BtnAdd.IsEnabled = (resultDictionary[GetString(ChooseFictType)].isFinal);
                if (BtnAdd.IsEnabled) requestedValue = GetString(ChooseFictType);
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
                ActionCreation = new Action(CreateBook);
                ActionCreation += resultDictionary[GetString(ChooseGenre)].DataUpdate;
                ActionCreation += resultDictionary[GetString(ChooseFictType)].DataUpdate;
                ActionCreation += resultDictionary[GetString(ChooseFictFantType)].DataUpdate;
                BtnAdd.IsEnabled = (resultDictionary[GetString(ChooseFictFantType)].isFinal);
                if (BtnAdd.IsEnabled) requestedValue = GetString(ChooseFictFantType);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ActionCreation();
            bookListForm.Items.Add(new ItemInList { Id = bookListForm.Items.Count + 1, Type = requestedValue, Name = book.Name, Author = book.Author, Data = book });
        }

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
