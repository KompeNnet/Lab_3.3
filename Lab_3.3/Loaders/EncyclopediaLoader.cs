using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Lab_3._3.Books;
using Lab_3._3.Helpers;

namespace Lab_3._3.Loaders
{
    class EncyclopediaLoader : BookLoader
    {
        public override dynamic Create(GroupBox g)
        {
            Encyclopedia e = new Encyclopedia(base.Create(g));

            GroupBox encGroupBox = ((Grid)g.Content).Children.OfType<GroupBox>().First(x => x.Name == "EncycloGroup");
            IEnumerable<TextBox> tbList = ((Grid)encGroupBox.Content).Children.OfType<TextBox>();

            e.Genre = "Encyclopedia";
            e.Subject = tbList.First(x => x.Name == "InpEnSubject").Text;
            return e;
        }

        public override dynamic BaseCreate(GroupBox g)
        {
            return new Encyclopedia(base.Create(g));
        }

        public override Grid Load(dynamic e)
        {
            Grid g = base.Load((Book)e);

            Grid grg = FormCreator.CreateGrid(new Thickness(0, 0, 0, 0));
            grg.Children.Add(FormCreator.CreateLabel("Subject", new Thickness(10, 10, 0, 0)));
            grg.Children.Add(FormCreator.CreateTextBox("InpEnSubject", e.Subject, new Thickness(10, 38, 0, 0)));

            GroupBox gr = FormCreator.CreateGroupBox("EncycloGroup", "Encyclopedia", new Thickness(155, 0, 0, 0), 174, 361);
            gr.Content = grg;

            g.Children.Add(gr);

            IEnumerable<ComboBox> cbList = g.Children.OfType<ComboBox>();
            ComboBox genreComboBox = cbList.First(x => x.Name == "ChooseGenre");
            genreComboBox.SelectedIndex = 0;

            return g;
        }

        public override dynamic Deserialize(dynamic d)
        {
            return Serializer.Deserialize<Encyclopedia>(d);
        }
    }
}
