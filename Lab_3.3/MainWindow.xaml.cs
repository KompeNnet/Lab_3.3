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
using Lab_3._3.Helpers;

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
            GroupBox newGroupBox = FormCreator.CreateGroupBox("MinGroup", "Book", new Thickness(0, 0, 0, 0), 500);
        }

        private dynamic CastType<T>(dynamic book)
        {
            return Serializer.Deserialize<T>(Serializer.Serialize(book));
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
