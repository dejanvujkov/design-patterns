using System;

namespace InterfaceSegregation
{
    // interfaces should be segregated so that everyone who implements interface shouldn't have a function that they don't need

    public class Document
    {

    }

    // bad example
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);

    }

    // this printer do need every function
    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    // this printer cannot Fax or Scan
    public class OldFashionedPrinter : IMachine
    {
        public void Fax(Document d)
        {
            // cannot fax
        }

        public void Print(Document d)
        {
            // can print
        }

        public void Scan(Document d)
        {
            // cannot scan
        }
    }

    // solution => break big interface into smaller interfaces
    public interface IScan
    {
        void Scan(Document d);
    }

    public interface IPrint
    {
        void Print(Document d);
    }
    public interface IFax
    {
        void Fax(Document d);
    }

    // in case someone needs every function we can create this
    public interface IBetterMachine : IScan, IPrint, IFax
    {

    }

    // in case someone needs only particular function, just inherent that one
    public class OldFashionedPrinter1 : IPrint
    {
        public void Print(Document d)
        {
            //
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
