using System.Security;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DependencyInversion
{
    // high level parts of the system should not depend on low level parts, both instead should depend of abstraction

    public enum Relationship { Parent, Child, Sibling }

    public class Person
    {
        public string Name;
    }

    // low - level part of the system
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var item in relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent))
            {
                yield return item.Item3;
            }
        }
        // this provides access to low level modules which is bad
        // public List<(Person, Relationship, Person)> Relations => relations;
    }

    #region solution
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    #endregion

    class Research
    {
        // bad example
        // public Research(Relationships relationships)
        // {
        //     // this allows high level module (Research) to access low level one
        //     var relations = relationships.Relations;

        //     foreach (var item in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
        //     {
        //         System.Console.WriteLine($"John has a child called {item.Item3.Name}");
        //     }
        // }
        public Research(IRelationshipBrowser browser)
        {
            foreach (var v in browser.FindAllChildrenOf("John"))
            {
                System.Console.WriteLine($"John has a child called {v.Name}"); 
            }
        }
        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}
