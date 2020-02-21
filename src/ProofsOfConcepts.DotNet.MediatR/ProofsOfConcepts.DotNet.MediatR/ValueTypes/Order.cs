using System;
using System.Collections.Generic;
using System.Text;

namespace ProofsOfConcepts.DotNet.MediatR.ValueTypes
{
    public class Order
    {
        public Guid Id { get; private set; }
        public IEnumerable<Product> ListOfProducts { get; private set; }
        public Customer Customer { get; private set; }
        public Order(
            Guid id,
            Customer customer,
            IEnumerable<Product> listOfProducts)
        {
            Id = id;
            ListOfProducts = listOfProducts;
            Customer = customer;
        }
    }
}
