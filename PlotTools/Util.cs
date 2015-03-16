using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PlotTools {
    public static class Util {
        public static void ShowDialog(this UIElement window) {
            Window w = new Window();
            Grid g = new Grid();
            g.Children.Add(window);
            w.Content = g;
            w.ShowDialog();
        }

        public static int Round(this double r) {
            return (int)Math.Round(r);
        }
    }
}
