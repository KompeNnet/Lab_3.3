using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
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
            b.Name = tbList.First(x => x.Name == "InpName").Text;
            b.PublishingOffice = tbList.First(x => x.Name == "InpPublishing").Text;
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

        public GroupBox CreateButtonsGroup(string bookType)
        {
            Grid g = FormCreator.CreateGrid(new Thickness(0, 0, 0, 0));

            Button btnTemp = FormCreator.CreateButton("BtnAdd", "Add", new Thickness(10, 0, 0, 0), BtnAdd_Click);
            btnTemp.IsEnabled = LoaderManager.resultList.Contains(bookType);
            g.Children.Add(btnTemp);

            g.Children.Add(FormCreator.CreateButton("BtnRemove", "Remove", new Thickness(75, 0, 0, 0), BtnRemove_Click));

            btnTemp = FormCreator.CreateButton("BtnSubmit", "Submit", new Thickness(140, 0, 0, 0), BtnSubmit_Click);
            btnTemp.IsEnabled = LoaderManager.resultList.Contains(bookType);
            g.Children.Add(btnTemp);
            g.Children.Add(FormCreator.CreateButton("BtnSerialize", "Serialize", new Thickness(205, 0, 0, 0), BtnSerialize_Click));
            g.Children.Add(FormCreator.CreateButton("BtnDeserialize", "Deserialize", new Thickness(270, 0, 0, 0), BtnDeserialize_Click));

            GroupBox gb = FormCreator.CreateGroupBox("ButtonGroup", "", new Thickness(520, 0, 0, 0), 352, 362);
            gb.Content = g;

            return gb;
        }

        private GroupBox GetMainGroupBox(object o)
        {
            FrameworkElement parent = (FrameworkElement)((FrameworkElement)o).Parent;
            if (parent.Name == "MainGroup") return (GroupBox)parent;                 // found MainGroupBox
            else return GetMainGroupBox(parent);
        }

        // EVENTS

        public void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            GroupBox gr = GetMainGroupBox(sender);                  // MainGroupBox
            Grid g = (Grid)gr.Parent;                               // MainGrid
            
            dynamic book = Create(gr);                              // create new book based on layout

            var temp = ((Grid)gr.Content).Children;                 // get all children of MainGroupBox
            string type = ((GroupBox)temp[temp.Count - 2]).Header.ToString();   // get pre-last GroupBox Header, because last one is ButtonGroupBox

            ListView bookListForm = g.Children.OfType<ListView>().First(x => x.Name == "BookListForm"); // find BookListForm
            bookListForm.Items.Add(new ItemInList { Type = type, Name = book.Name, Author = book.Author, Data = book });
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            GroupBox gr = GetMainGroupBox(sender);                  // MainGroupBox
            Grid g = (Grid)gr.Parent;                               // MainGrid
            ListView bookListForm = g.Children.OfType<ListView>().First(x => x.Name == "BookListForm"); // find BookListForm

            while (bookListForm.SelectedItems.Count > 0)
            {
                bookListForm.Items.Remove(bookListForm.SelectedItems[0]);
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            GroupBox gr = GetMainGroupBox(sender);
            Grid g = (Grid)gr.Parent;

            dynamic book = Create(gr);

            var temp = ((Grid)gr.Content).Children;
            string type = ((GroupBox)temp[temp.Count - 2]).Header.ToString();

            ListView bookListForm = g.Children.OfType<ListView>().First(x => x.Name == "BookListForm");
            bookListForm.Items[bookListForm.SelectedIndex] = new ItemInList { Type = type, Name = book.Name, Author = book.Author, Data = book };
        }       // like BtnAdd_Click + get selected and replace with book

        private void BtnSerialize_Click(object sender, RoutedEventArgs e)
        {
            GroupBox gr = GetMainGroupBox(sender);
            Grid g = (Grid)gr.Parent;
            ListView bookListForm = g.Children.OfType<ListView>().First(x => x.Name == "BookListForm");

            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "JSON files | *.json",
                FileName = "bookList.json"
            };
            if (dlg.ShowDialog() == true)
            {
                StreamWriter writer = new StreamWriter(dlg.OpenFile());
                foreach (ItemInList item in bookListForm.SelectedItems)
                {
                    writer.WriteLine(item.Type + ":" + Serializer.Serialize(item.Data));
                }
                writer.Dispose();
                writer.Close();
            }
        }    // selectedItems (data & type), serialize json { type: "Type", book: Object }, write in file

        private void BtnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            GroupBox gr = GetMainGroupBox(sender);
            Grid g = (Grid)gr.Parent;
            ListView bookListForm = g.Children.OfType<ListView>().First(x => x.Name == "BookListForm");

            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "JSON files | *.json"
            };
            if (dlg.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(dlg.OpenFile());
                string item;
                while ((item = reader.ReadLine()) != null)
                {
                    // indexof(':')?
                    string[] words = item.Split(':');
                    item = item.Substring(words[0].Length + 1, item.Length - words[0].Length - 1);
                    var loader = LoaderManager.GetLoader(words[0]);
                    Book book = loader.Deserialize(item);
                    bookListForm.Items.Add(new ItemInList { Type = words[0], Name = book.Name, Author = book.Author, Data = book });
                }
                reader.Dispose();
                reader.Close();
            }
        }

        protected void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).IsDropDownOpen)
            {
                string selectedText = ((ComboBox)sender).SelectedValue.ToString();

                GroupBox oldGroupBox = GetMainGroupBox(sender);     // MainGroupBox
                Grid p = (Grid)oldGroupBox.Parent;                  // MainGrid
                p.Children.Remove(oldGroupBox);                     // delete old MainGroupBox

                var b = LoaderManager.GetLoader(selectedText);      // select Loader

                Grid newGrid = b.Load(b.BaseCreate(oldGroupBox));   // create new Grid
                newGrid.Children.Add(b.CreateButtonsGroup(selectedText));         // add buttons on it

                GroupBox newGroupBox = FormCreator.CreateGroupBox("MainGroup", "Book", new Thickness(0, 0, 0, 0), 887, 384);
                newGroupBox.Content = newGrid;                      // wrap Grid into new MainGroupBox

                p.Children.Add(newGroupBox);                        // add to MainGrid
            }
        }

        public virtual dynamic Deserialize(dynamic d)
        {
            return Serializer.Deserialize<Book>(d);
        }
    }
}
