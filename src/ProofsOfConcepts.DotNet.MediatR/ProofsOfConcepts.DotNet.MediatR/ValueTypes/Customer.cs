using System;
using System.Collections.Generic;
using System.Text;

namespace ProofsOfConcepts.DotNet.MediatR.ValueTypes
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Customer(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
