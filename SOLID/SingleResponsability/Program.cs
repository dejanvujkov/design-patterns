using System;
using System.Collections.Generic;

namespace SingleResponsability
{
    // class is responsable for 1 thing and
    // should have one reason to change
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistance
    {
        // ... Don't put this into Journal class 
        public void SaveToFile()
        {

        }

        public void LoadFromFile()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            journal.AddEntry("asd");
            journal.AddEntry("Coding today");
            Console.WriteLine(journal);

            var p = new Persistance();
            p.SaveToFile();
        }
    }
}
