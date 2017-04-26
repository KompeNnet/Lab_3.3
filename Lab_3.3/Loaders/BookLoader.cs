using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Lab_3._3.Books;
using Lab_3._3.Helpers;

namespace Lab_3._3.Loaders
{
    class BookLoader
    {
        public virtual dynamic Create(GroupBox g)
        {
            Book b = new Book();
            IEnumerable<TextBox> tbList = ((Grid)g.Content).Children.OfType<TextBox>();

            b.Author = tbList.First(x => x.Name == "InpAuthor").Text;
            b.Name = tbList.First(x => x.Name == "InpAuthor").Text;
            b.PublishingOffice = tbList.First(x => x.Name == "InpAuthor").Text;
            return b;
        }

        public virtual dynamic BaseCreate(GroupBox g)
        {
            return Create(g);
        }

        public virtual Grid Load(dynamic b)
        {
            Grid g = new Grid();
            g.Children.Add(FormCreator.CreateLabel("Author", new Thickness(10, 27, 0, 0)));
            g.Children.Add(FormCreator.CreateTextBox("InpAuthor", b.Author, new Thickness(10, 55, 0, 0)));
            g.Children.Add(FormCreator.CreateLabel("Name", new Thickness(10, 77, 0, 0)));
            g.Children.Add(FormCreator.CreateTextBox("InpName", b.Name, new Thickness(10, 105, 0, 0)));
            g.Children.Add(FormCreator.CreateLabel("Publishing office", new Thickness(10, 128, 0, 0)));
            g.Children.Add(FormCreator.CreateTextBox("InpPublishing", b.PublishingOffice, new Thickness(10, 156, 0, 0)));
            g.Children.Add(FormCreator.CreateLabel("Book genre", new Thickness(10, 183, 0, 0)));

            ComboBox cb = FormCreator.CreateComboBox("ChooseGenre", new Thickness(10, 211, 0, 0), new string[] { "Encyclopedia", "Fiction", "Historical" });
            cb.SelectionChanged += new SelectionChangedEventHandler(SelectionChanged);
            g.Children.Add(cb);

            return g;
        }

        protected void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).IsDropDownOpen)
            {
                string selectedText = ((ComboBox)sender).SelectedValue.ToString(); //GetString((ComboBox)sender);
                GroupBox oldGroupBox = GetGroupBox(sender);     // getting old groupBox with all textboxes, labels and comboboxes
                Grid p = (Grid)oldGroupBox.Parent;
                p.Children.Remove(oldGroupBox);                             // now we deleting this groupBox from its parent

                var b = LoaderManager.GetLoader(selectedText);

                Grid newGrid = b.Load(b.BaseCreate(oldGroupBox));                               // creating new grid

                GroupBox newGroupBox = FormCreator.CreateGroupBox("MainGroup", "Book", new Thickness(0, 0, 0, 0), 524, 384);
                newGroupBox.Content = newGrid;

                p.Children.Add(newGroupBox);									// add new groupBox to form

                GroupBox displayGroupBox = p.Children.OfType<GroupBox>().First(x => x.Name == "GroupBtnsList");
                IEnumerable<Button> btnList = ((Grid)displayGroupBox.Content).Children.OfType<Button>();

                Button addButton = btnList.First(x => x.Name == "BtnAdd");
                addButton.Click += new RoutedEventHandler(BtnAdd_Click);
            }
        }

        public void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            GroupBox gr = GetGroupBox(sender);
            Grid g = (Grid)gr.Parent;

            dynamic book = this.Create(gr);

            ListView bookListForm = (ListView)g.FindName("BookListForm");
            bookListForm.Items.Add(new ItemInList { Type = "Book", Name = book.Name, Author = book.Author, Data = book });
        }

        private GroupBox GetGroupBox(object o)
        {
            FrameworkElement parent = (FrameworkElement)((FrameworkElement)o).Parent;
            if (parent.Name == "MainGroup") return (GroupBox)parent;
            else return GetGroupBox(parent);
        }
    }
}
