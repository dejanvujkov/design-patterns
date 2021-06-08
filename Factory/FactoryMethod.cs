using System;
namespace Factory
{
    public class Point
    {
        private double x, y;

        private Point(double y = 0, double x = 0)
        {
            this.y = y;
            this.x = x;
        }

        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(y, x);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}