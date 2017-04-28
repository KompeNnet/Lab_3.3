using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab_3._3.Helpers
{
    class FormCreator
    {
        public static Button CreateButton(string name, string content, Thickness margin, Action<object, RoutedEventArgs> btnClick)
        {
            Button b = new Button();
            b.Margin = margin;
            b.Name = name;
            b.Content = content;
            b.HorizontalAlignment = HorizontalAlignment.Left;
            b.VerticalAlignment = VerticalAlignment.Top;
            b.Width = 60;
            b.Click += new RoutedEventHandler(btnClick);
            return b;
        }

        public static CheckBox CreateCheckBox(string name, string content, Thickness margin, bool val)
        {
            CheckBox ch = new CheckBox();
            ch.Margin = margin;
            ch.Name = name;
            ch.Content = content;
            ch.VerticalAlignment = VerticalAlignment.Top;
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

        public static GroupBox CreateGroupBox(string name, string header, Thickness margin, int width, int height)
        {
            GroupBox g = new GroupBox();
            g.Name = name;
            g.Header = header;
            g.Height = height;
            g.HorizontalAlignment = HorizontalAlignment.Left;
            g.VerticalAlignment = VerticalAlignment.Top;
            g.Width = width;
            g.Margin = margin;
            return g;
        }

        public static ComboBox CreateComboBox(string name, Thickness margin, string[] items)
        {
            ComboBox c = new ComboBox();
            c.Name = name;
            c.HorizontalAlignment = HorizontalAlignment.Left;
            c.VerticalAlignment = VerticalAlignment.Top;
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
            l.HorizontalAlignment = HorizontalAlignment.Left;
            l.VerticalAlignment = VerticalAlignment.Top;
            l.Height = 28;
            l.Width = 134;
            l.Margin = margin;
            return l;
        }

        public static TextBox CreateTextBox(string name, string text, Thickness margin)
        {
            TextBox t = new TextBox();
            t.Name = name;
            t.HorizontalAlignment = HorizontalAlignment.Left;
            t.VerticalAlignment = VerticalAlignment.Top;
            t.Height = 22;
            t.Width = 134;
            t.Margin = margin;
            t.TextWrapping = TextWrapping.Wrap;
            t.MaxLines = 1;
            t.MaxLength = 36;
            t.Text = text;
            return t;
        }
    }
}
