using System;

namespace Factory
{
    // return concrete model
    public static class PointFactory
    {
        // to use this, ctors have to be public
        public static Point1 NewCartesianPoint(double x, double y)
        {
            return new Point1(y, x);
        }

        public static Point1 NewPolarPoint(double rho, double theta)
        {
            return new Point1(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }

    public class Point1
    {
        private double x, y;

        public Point1(double y = 0, double x = 0)
        {
            this.y = y;
            this.x = x;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}