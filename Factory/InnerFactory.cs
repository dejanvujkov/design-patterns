using System;

namespace Factory
{

    public class Point2
    {
        private double x, y;

        private Point2(double y = 0, double x = 0)
        {
            this.y = y;
            this.x = x;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        // to fix problem with public ctor make inner factory
        public static class InnerFactory
        {
            public static Point2 NewCartesianPoint(double x, double y)
            {
                return new Point2(y, x);
            }

            public static Point2 NewPolarPoint(double rho, double theta)
            {
                return new Point2(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
}