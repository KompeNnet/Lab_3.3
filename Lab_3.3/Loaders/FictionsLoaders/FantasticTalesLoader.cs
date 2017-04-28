using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Lab_3._3.Books;
using Lab_3._3.Books.Fictions;
using Lab_3._3.Helpers;

namespace Lab_3._3.Loaders.FictionsLoaders
{
    class FantasticTalesLoader : FictionLoader
    {
        public override dynamic Create(GroupBox g)
        {
            FantasticTales f = new FantasticTales(base.Create(g));

            GroupBox ftGroupBox = ((Grid)g.Content).Children.OfType<GroupBox>().First(x => x.Name == "FictFantasticTalesGroup");
            IEnumerable<TextBox> tbList = ((Grid)ftGroupBox.Content).Children.OfType<TextBox>();

            f.CoAuthors = tbList.First(x => x.Name == "InpFictFantCoWorkers").Text;
            return f;
        }

        public override dynamic BaseCreate(GroupBox g)
        {
            return new FantasticTales(base.Create(g));
        }

        public override Grid Load(dynamic f)
        {
            Grid g = base.Load((Fiction)f);

            Grid grg = FormCreator.CreateGrid(new Thickness(0, 0, 0, 0));
            grg.Children.Add(FormCreator.CreateLabel("coWorkers", new Thickness(10, 9, 0, 0)));
            grg.Children.Add(FormCreator.CreateTextBox("InpFictFantCoWorkers", f.CoAuthors, new Thickness(10, 37, 0, 0)));
            grg.Children.Add(FormCreator.CreateLabel("Type", new Thickness(10, 59, 0, 0)));

            ComboBox cb = FormCreator.CreateComboBox("ChooseFictFantType", new Thickness(10, 87, 0, 0), new string[] { "FairyTales", "ScienceFiction" });
            cb.SelectionChanged += new SelectionChangedEventHandler(SelectionChanged);
            grg.Children.Add(cb);

            GroupBox gr = FormCreator.CreateGroupBox("FictFantasticTalesGroup", "Fantastic Tales", new Thickness(329, 0, 0, 0), 171, 361);
            gr.Content = grg;

            g.Children.Add(gr);

            GroupBox fictionGroupBox = g.Children.OfType<GroupBox>().First(x => x.Name == "FictionGroup");
            IEnumerable<ComboBox> cbList = ((Grid)fictionGroupBox.Content).Children.OfType<ComboBox>();
            ComboBox genreComboBox = cbList.First(x => x.Name == "ChooseFictType");
            genreComboBox.SelectedIndex = 0;

            return g;
        }

        public override dynamic Deserialize(dynamic d)
        {
            return Serializer.Deserialize<FantasticTales>(d);
        }
    }
}
