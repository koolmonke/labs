using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafik
{
    public class PlotF
    {
        public static double r(double phi, double a = 1) => a * Math.Sqrt(phi);

        public static (double, double) pol2cart(double rho, double phi)
        {
            double x = rho * Math.Cos(phi);
            double y = rho * Math.Sin(phi);

            return (x, y);
        }
    }
}
