using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Lab_3._3.Books.Fictions;
using Lab_3._3.Helpers;

namespace Lab_3._3.Loaders.FictionsLoaders
{
    class FairyTalesLoader : FantasticTalesLoader
    {
        public override dynamic Create(GroupBox g)
        {
            FairyTales f = new FairyTales(base.Create(g));

            GroupBox fairyGroupBox = ((Grid)g.Content).Children.OfType<GroupBox>().First(x => x.Name == "FictFantFairyTalesGroup");
            IEnumerable<CheckBox> chbList = ((Grid)fairyGroupBox.Content).Children.OfType<CheckBox>();

            f.IsIllustrated = chbList.First(x => x.Name == "CheckFictFantFairyIsIllustrated").IsChecked.Value;
            return f;
        }

        public override dynamic BaseCreate(GroupBox g)
        {
            return new FairyTales(base.Create(g));
        }

        public override Grid Load(dynamic f)
        {
            Grid g = base.Load((FantasticTales)f);

            Grid grg = FormCreator.CreateGrid(new Thickness(0, 0, 0, 0));
            grg.Children.Add(FormCreator.CreateCheckBox("CheckFictFantFairyIsIllustrated", "is illustrated", new Thickness(10, 9, 0, 0), f.IsIllustrated));

            GroupBox gr = FormCreator.CreateGroupBox("FictFantFairyTalesGroup", "FairyTales", new Thickness(332, 184, 0, 0), 165, 170);
            gr.Content = grg;

            g.Children.Add(gr);

            GroupBox ftGroupBox = g.Children.OfType<GroupBox>().First(x => x.Name == "FictFantasticTalesGroup");
            IEnumerable<ComboBox> cbList = ((Grid)ftGroupBox.Content).Children.OfType<ComboBox>();
            ComboBox genreComboBox = cbList.First(x => x.Name == "ChooseFictFantType");
            genreComboBox.SelectedIndex = 0;

            return g;
        }

        public override dynamic Deserialize(dynamic d)
        {
            return Serializer.Deserialize<FairyTales>(d);
        }
    }
}
