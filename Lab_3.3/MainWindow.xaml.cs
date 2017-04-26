using System.Windows;
using System.Windows.Controls;
using Lab_3._3.Books;
using Lab_3._3.Helpers;
using Lab_3._3.Loaders;

namespace Lab_3._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GroupBox newGroupBox = FormCreator.CreateGroupBox("MainGroup", "Book", new Thickness(0, 0, 0, 0), 524, 384);
            newGroupBox.Content = new BookLoader().Load(new Book());

            MainGrid.Children.Add(newGroupBox);

            BtnAdd.Click += new RoutedEventHandler(new BookLoader().BtnAdd_Click);
        }

        private dynamic CastType<T>(dynamic book)
        {
            return Serializer.Deserialize<T>(Serializer.Serialize(book));
        }

        private void UploadInfo(Book book)
        {
            //TODO
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            while (BookListForm.SelectedItems.Count > 0)
            {
                BookListForm.Items.Remove(BookListForm.SelectedItems[0]);
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

        private void BtnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void BookListForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookListForm.SelectedIndex != -1)
            {
                BtnRemove.IsEnabled = true;
                BtnSerialize.IsEnabled = true;
                BtnSubmit.IsEnabled = true;
                ItemInList elem = (ItemInList)BookListForm.Items.GetItemAt(BookListForm.SelectedIndex);
            }
            else
            {
                BtnRemove.IsEnabled = false;
                BtnSerialize.IsEnabled = false;
                BtnSubmit.IsEnabled = false;
            }
        }
    }
}
