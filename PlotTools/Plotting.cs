using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PlotTools {
    public static class Plotting {
        public static void PlotVals(params double[] vals) {
            Plotter p = new Plotter();
            p.AddVals(vals);
            p.ShowDialog();
        }

        public static void PlotVals(List<double> x, List<double> y) {
            if (x.Count != y.Count) {
                throw new Exception("We require the same number of x and y values");
            }
            Plotter p = new Plotter();
            p.AddVals(x, y);
            p.ShowDialog();
        }
    }
}
