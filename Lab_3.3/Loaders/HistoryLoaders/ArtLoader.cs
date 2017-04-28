using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Lab_3._3.Books;
using Lab_3._3.Books.History;
using Lab_3._3.Helpers;

namespace Lab_3._3.Loaders.HistoryLoaders
{
    class ArtLoader : HistoricalLoader
    {
        public override dynamic Create(GroupBox g)
        {
            Art a = new Art(base.Create(g));

            GroupBox artGroupBox = ((Grid)g.Content).Children.OfType<GroupBox>().First(x => x.Name == "HistArtGroup");
            IEnumerable<TextBox> tbList = ((Grid)artGroupBox.Content).Children.OfType<TextBox>();

            a.ArtForm = tbList.First(x => x.Name == "InpHistArtForm").Text;
            return a;
        }

        public override dynamic BaseCreate(GroupBox g)
        {
            return new Art(base.Create(g));
        }

        public override Grid Load(dynamic a)
        {
            Grid g = base.Load((Historical)a);

            Grid grg = FormCreator.CreateGrid(new Thickness(0, 0, 0, 0));
            grg.Children.Add(FormCreator.CreateLabel("Form of art", new Thickness(10, 10, 73, 0)));
            grg.Children.Add(FormCreator.CreateTextBox("InpHistArtForm", a.ArtForm, new Thickness(9, 38, 10, 0)));

            GroupBox gr = FormCreator.CreateGroupBox("HistArtGroup", "Art", new Thickness(329, 0, 10, 10), 174, 384);
            gr.Content = grg;

            g.Children.Add(gr);

            GroupBox ftGroupBox = g.Children.OfType<GroupBox>().First(x => x.Name == "HistoricalGroup");
            IEnumerable<ComboBox> cbList = ((Grid)ftGroupBox.Content).Children.OfType<ComboBox>();
            ComboBox genreComboBox = cbList.First(x => x.Name == "ChooseHistType");
            genreComboBox.SelectedIndex = 0;

            return g;
        }

        public override dynamic Deserialize(dynamic d)
        {
            return Serializer.Deserialize<Art>(d);
        }
    }
}
