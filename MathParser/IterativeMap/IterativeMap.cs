using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.IterativeMap {
    class IterativeMap : IterativeMapBase {
        public IterativeMap(Func<double, double> map) {
            this.map = map;
        }

        private Func<double, double> map;

        public override double Map(double lastVal) {
            return map(lastVal);
        }
    }
}
