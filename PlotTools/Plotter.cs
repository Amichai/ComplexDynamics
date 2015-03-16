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
    public class Plotter {
        public void AddVals(params double[] vals) {
            this.series.Add(SeriesGenerator.GetScatterSeries(vals));
        }

        public void AddVals(List<double> x, List<double> y) {
            this.series.Add(SeriesGenerator.GetScatterSeries(x, y));
        }

        private const double eps = .01;

        public void AddLine(double x0, double y0, double x1, double y1) {
            if (x1 == x0) {
                var ls = new LineSeries() {
                    StrokeThickness = 4,
                    MarkerStroke = OxyColors.Red
                };
                double minY = y0 < y1 ? y0 : y1;
                double maxY = y0 < y1 ? y1 : y0;

                ls.Points.Add(new DataPoint());
                for (double yVal = minY; yVal < maxY; yVal += eps) {
                    ls.Points.Add(new DataPoint(x0, yVal));
                }
                this.series.Add(ls);
                return;
            }
            double slope = (y1 - y0) / (x1 - x0);
            Func<double, double> f = x => slope * (x - x1) + y1;
            double minX = x0 < x1 ? x0 : x1; 
            double maxX = x0 < x1 ? x1 : x0;
            this.AddLine(f, minX, maxX, eps);
        }

        public void AddLine(Func<double, double> fx, double x0, double xf, double dx) {
            this.series.Add(new FunctionSeries(fx, x0, xf, dx));
        }

        private List<Series> series = new List<Series>();

        public void ShowDialog() {
            OxyPlot.Wpf.PlotView plot = new OxyPlot.Wpf.PlotView();
            var p = new PlotModel();
            plot.Model = p;
            foreach (var s in series) {
                p.Series.Add(s);
            }
            plot.ShowDialog();
            p.InvalidatePlot(true);
        }
    }
}
