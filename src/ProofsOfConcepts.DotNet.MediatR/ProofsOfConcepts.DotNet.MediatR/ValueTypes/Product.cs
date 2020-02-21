using System;

namespace ProofsOfConcepts.DotNet.MediatR.ValueTypes
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Product(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
