using ProofsOfConcepts.DotNet.MediatR.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofsOfConcepts.DotNet.MediatR.AggregateRoots
{
    public class OrderAggregateRoot
    {
        public static Order CreateNewOrder(Customer customer, IEnumerable<Product> listOfProducts)
        {
            var newOrderId = Guid.NewGuid();
            var newOrder = new Order(newOrderId, customer, listOfProducts);

            return newOrder;
        }
    }
}
