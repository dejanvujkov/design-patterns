using System;

namespace LiskovSubstitutionPrinciple
{
    public class Rectangle
    {
        // to obey principle & fix: make properties virtual
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle() { }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        // to obey principle & fix: put override instead of new
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        public new int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
    class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(3, 2);
            System.Console.WriteLine($"{rec} has area {Area(rec)}");

            // Can't change this to reactangle unsless fixed
            // it won't calculate correctly
            Rectangle square = new Square();
            square.Width = 4;
            System.Console.WriteLine($"{square} has area {Area(square)}");

            // Pinciple says: parent classes should be replaceable with child classes
        }
    }
}
