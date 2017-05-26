using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Lab_3._3.Books.Fictions;
using Lab_3._3.Helpers;

namespace Lab_3._3.Loaders.FictionsLoaders
{
    class ScienceFictionLoader : FantasticTalesLoader
    {
        public override dynamic Create(GroupBox g)
        {
            ScienceFiction s = new ScienceFiction(base.Create(g));

            GroupBox sfGroupBox = ((Grid)g.Content).Children.OfType<GroupBox>().First(x => x.Name == "FictFantScienceFictionGroup");
            IEnumerable<CheckBox> chbList = ((Grid)sfGroupBox.Content).Children.OfType<CheckBox>();

            s.IsEarth = chbList.First(x => x.Name == "CheckFictFantFairyIsEarth").IsChecked.Value;
            return s;
        }

        public override dynamic BaseCreate(GroupBox g)
        {
            return new ScienceFiction(base.Create(g));
        }

        public override Grid Load(dynamic s)
        {
            Grid g = base.Load((FantasticTales)s);

            Grid grg = FormCreator.CreateGrid(new Thickness(0, 0, 0, 0));
            grg.Children.Add(FormCreator.CreateCheckBox("CheckFictFantFairyIsEarth", "is Earth", new Thickness(10, 10, 10, 0), s.IsEarth));

            GroupBox gr = FormCreator.CreateGroupBox("FictFantScienceFictionGroup", "ScienceFiction", new Thickness(332, 184, 0, 0), 165, 170);
            gr.Content = grg;

            g.Children.Add(gr);

            GroupBox ftGroupBox = g.Children.OfType<GroupBox>().First(x => x.Name == "FictFantasticTalesGroup");
            IEnumerable<ComboBox> cbList = ((Grid)ftGroupBox.Content).Children.OfType<ComboBox>();
            ComboBox genreComboBox = cbList.First(x => x.Name == "ChooseFictFantType");
            genreComboBox.SelectedIndex = 1;

            return g;
        }

        public override dynamic Deserialize(dynamic d)
        {
            return Serializer.Deserialize<ScienceFiction>(d);
        }
    }
}
