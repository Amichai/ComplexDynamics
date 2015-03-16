using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotTools {
    internal static class SeriesGenerator {
        public static Series GetScatterSeries(params double[] vals) {
            ScatterSeries ss = new ScatterSeries();
            int count = 0;
            foreach (var v in vals) {
                ss.Points.Add(new ScatterPoint(count++, v) { Size = defaultSize });
            }
            return ss;
        }

        private static double defaultSize = 3.0;

        public static ScatterSeries GetScatterSeries(List<double> x, List<double> y) {
            ScatterSeries ss = new ScatterSeries();
            for (int i = 0; i < x.Count; i++) {
                ss.Points.Add(new ScatterPoint(x[i], y[i]) {  Size = defaultSize });
            }
            return ss;
        }
    }
}
