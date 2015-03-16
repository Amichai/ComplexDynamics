using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.IterativeMap {
    class BinaryIterativeMap : IterativeMapBase {
        public BinaryIterativeMap(Func<bool, bool> map) {
            this.map = map;
        }

        private Func<bool, bool> map;

        
        public override double Map(double lastVal) {
            if (lastVal != 0 && lastVal != 1) {
                throw new ArgumentException("Input val must be 0 or 1");
            }
            return (double)(map((int)lastVal == 1) ? 1.0 : 0.0);
        }
    }
}
