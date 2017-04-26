using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab_3._3.Helpers
{
    class FormCreator
    {
        public static CheckBox CreateCheckBox(string name, string content, Thickness margin, bool val)
        {
            CheckBox ch = new CheckBox();
            ch.Margin = margin;
            ch.Name = name;
            ch.Content = content;
            ch.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            ch.Height = 18;
            ch.IsChecked = val;
            return ch;
        }

        public static Grid CreateGrid(Thickness margin)
        {
            Grid g = new Grid();
            g.Margin = margin;
            return g;
        }

        public static GroupBox CreateGroupBox(string name, string header, Thickness margin, int width)
        {
            GroupBox g = new GroupBox();
            g.Name = name;
            g.Header = header;
            g.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            g.Width = width;
            g.Margin = margin;
            return g;
        }

        public static ComboBox CreateComboBox(string name, Thickness margin, string[] items)
        {
            ComboBox c = new ComboBox();
            c.Name = name;
            c.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            c.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            c.Height = 22;
            c.Width = 134;
            c.Margin = margin;
            c.ItemsSource = items;
            c.SelectedIndex = -1;
            return c;
        }
        public static Label CreateLabel(string content, Thickness margin)
        {
            Label l = new Label();
            l.Content = content;
            l.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            l.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            l.Height = 28;
            l.Width = 98;
            l.Margin = margin;
            return l;
        }

        public static TextBox CreateTextBox(string name, string text, Thickness margin)
        {
            TextBox t = new TextBox();
            t.Name = name;
            t.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            t.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            t.Height = 22;
            t.Width = 134;
            t.Margin = margin;
            t.TextWrapping = System.Windows.TextWrapping.Wrap;
            t.MaxLines = 1;
            t.MaxLength = 36;
            t.Text = text;
            return t;
        }
    }
}
