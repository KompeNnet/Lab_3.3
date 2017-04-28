using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Lab_3._3.Books;
using Lab_3._3.Helpers;

namespace Lab_3._3.Loaders
{
    class FictionLoader : BookLoader
    {
        public override dynamic Create(GroupBox g)
        {
            Fiction f = new Fiction(base.Create(g));

            GroupBox fictionGroupBox = ((Grid)g.Content).Children.OfType<GroupBox>().First(x => x.Name == "FictionGroup");
            IEnumerable<TextBox> tbList = ((Grid)fictionGroupBox.Content).Children.OfType<TextBox>();

            f.Type = tbList.First(x => x.Name == "InpFictType").Text;
            f.Age = tbList.First(x => x.Name == "InpFictAge").Text;
            f.Genre = "Fiction";
            return f;
        }

        public override dynamic BaseCreate(GroupBox g)
        {
            return new Fiction(base.Create(g));
        }

        public override Grid Load(dynamic f)
        {
            Grid g = base.Load((Book)f);

            Grid grg = FormCreator.CreateGrid(new Thickness(0, 0, 0, 0));
            grg.Children.Add(FormCreator.CreateLabel("Type (original, fanfiction)", new Thickness(10, 9, 0, 0)));
            grg.Children.Add(FormCreator.CreateTextBox("InpFictType", f.Type, new Thickness(10, 37, 0, 0)));
            grg.Children.Add(FormCreator.CreateLabel("Age limit", new Thickness(10, 59, 0, 0)));
            grg.Children.Add(FormCreator.CreateTextBox("InpFictAge", f.Age, new Thickness(10, 87, 0, 0)));
            grg.Children.Add(FormCreator.CreateLabel("Type", new Thickness(10, 109, 0, 0)));

            ComboBox cb = FormCreator.CreateComboBox("ChooseFictType", new Thickness(10, 138, 0, 0), new string[] { "FantasticTales", "Travelling" });
            cb.SelectionChanged += new SelectionChangedEventHandler(SelectionChanged);
            grg.Children.Add(cb);

            GroupBox gr = FormCreator.CreateGroupBox("FictionGroup", "Fiction", new Thickness(155, 0, 0, 0), 174, 361);
            gr.Content = grg;

            g.Children.Add(gr);

            IEnumerable<ComboBox> cbList = g.Children.OfType<ComboBox>();
            ComboBox genreComboBox = cbList.First(x => x.Name == "ChooseGenre");
            genreComboBox.SelectedIndex = 1;

            return g;
        }

        public override dynamic Deserialize(dynamic d)
        {
            return Serializer.Deserialize<Fiction>(d);
        }
    }
}
