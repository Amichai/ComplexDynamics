using log4net;
using PlotTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MathParser.IterativeMap {
    abstract class IterativeMapBase : IIterativeMap {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IEnumerable<double> Iterate(double initialVal, int iterationCount = int.MaxValue) {
            double currentVal = initialVal;
            for (int i = 0; i < iterationCount; i++) {
                currentVal = this.Map(currentVal);
                yield return currentVal;
            }
            
        }

        public void PrintN(int iterationCount, double initialVal) {
            var result = this.Iterate(initialVal, iterationCount).ToList();
            log.Debug(string.Join(", ", result));
        }

        public void PlotTimeDependence(int iterationCount, double initialVal) {
            Plotting.PlotVals(Iterate(initialVal, iterationCount).ToArray());
        }

        public void TraceValueDependenceOverTime(double initialVal, int count) {
            var vals = this.Iterate(initialVal, count).ToList();
            
            int min = Math.Min(vals.Min(), initialVal).Round();
            int max = Math.Max(vals.Max(), initialVal).Round();
            max = Math.Max(max, min * -1);
            double previousVal = 0;
            int offset = 1;
            int range = max + offset;
            CartesianCanvas canvas = new CartesianCanvas(-range, -range, range * 2, range * 2, 1000, 1000);
            double currentVal = initialVal;
            canvas.DrawLine(-100, -100, 100, 100, Colors.Black);
            foreach (var v in vals) {
                previousVal = currentVal;
                currentVal = v;
                canvas.FillSquare(previousVal, currentVal, 5, Colors.Red);
                canvas.DrawLine(previousVal, currentVal, currentVal, currentVal, Colors.Blue);
                canvas.DrawLine(previousVal, currentVal, previousVal, previousVal, Colors.Blue);
            }
            canvas.ShowDialog();
        }

        public void PlotPreviousValueDependence(int startVal, int count) {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            int endVal= startVal + count;
            for (int i = startVal; i < endVal; i++) {
                x.Add(i);
                y.Add(this.Map(i));
            }
            Plotter p = new Plotter();
            p.AddVals(x, y);
            p.AddLine(i => i, startVal, endVal, .01);
            p.ShowDialog();
        }

        public abstract double Map(double lastVal);
    }
}
