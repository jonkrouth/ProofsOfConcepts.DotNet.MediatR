using System;
using System.Collections.Generic;

namespace ProofsOfConcepts.DotNet.MediatR.ValueTypes
{
    public class Order
    {
        public Guid Id { get; private set; }
        public IEnumerable<Product> ListOfProducts { get; private set; }
        public Customer Customer { get; private set; }
        public decimal TotalCost { get; private set; }

        public Order(
            Guid id,
            Customer customer,
            IEnumerable<Product> listOfProducts,
            decimal totalCost)
        {
            Id = id;
            ListOfProducts = listOfProducts;
            Customer = customer;
            TotalCost = totalCost;
        }
    }
}
