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

            GroupBox newGroupBox = FormCreator.CreateGroupBox("MainGroup", "Book", new Thickness(0, 0, 0, 0), 887, 384);
            Grid g = new BookLoader().Load(new Book());
            g.Children.Add(new BookLoader().CreateButtonsGroup("Book"));
            newGroupBox.Content = g;

            MainGrid.Children.Add(newGroupBox);
        }

        private void BookListForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookListForm.SelectedIndex != -1)
            {
                MainGrid.Children.RemoveAt(1);

                ItemInList elem = (ItemInList)BookListForm.Items.GetItemAt(BookListForm.SelectedIndex);

                var loader = LoaderManager.GetLoader(elem.Type);

                GroupBox newGroupBox = FormCreator.CreateGroupBox("MainGroup", "Book", new Thickness(0, 0, 0, 0), 887, 384);
                Grid g = loader.Load(elem.Data);
                g.Children.Add(loader.CreateButtonsGroup(elem.Type));
                newGroupBox.Content = g;

                MainGrid.Children.Add(newGroupBox);
            }
        }
    }
}
