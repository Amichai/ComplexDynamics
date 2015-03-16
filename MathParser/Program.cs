using log4net;
using log4net.Config;
using MathParser.IterativeMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser {
    class Program {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        [STAThread]
        static void Main(string[] args) {
            XmlConfigurator.Configure();

            //IterativeMapBase m = new BinaryIterativeMap(i => i);
            //m.PrintN(20, 0);

            //IterativeMapBase m2 = new BinaryIterativeMap(i => !i);
            //m2.PrintN(20, 0);

            //IterativeMapBase m3 = new IterativeMap.IterativeMap(i => i);
            //m3.PrintN(20, 5.0);


            //IterativeMapBase m4 = new IterativeMap.IterativeMap(i => i + 3);
            //m4.Plot(20, 3);

            //IterativeMapBase m5 = new IterativeMap.IterativeMap(i => i * -1.4);
            //m5.Plot(17, 3);

            //IterativeMapBase m6 = new IterativeMap.IterativeMap(i => i * -1.4);
            //m6.PlotTimeDependence(17, 3);

            //IterativeMapBase m7 = new IterativeMap.IterativeMap(i => i * 2.4);
            //m7.PlotPreviousValueDependence(0, 20);

            //IterativeMapBase m8 = new IterativeMap.IterativeMap(i => i * 1.2);
            //m8.TraceValueDependenceOverTime(2, 20);

            //IterativeMapBase m9 = new IterativeMap.IterativeMap(i => i * -.6);
            //m9.TraceValueDependenceOverTime(2, 20);


            IterativeMapBase m10 = new IterativeMap.IterativeMap(i => 3.8 * i * (1 - i));
            m10.TraceValueDependenceOverTime(.9, 20);

            Console.ReadKey();
        }
    }
}
