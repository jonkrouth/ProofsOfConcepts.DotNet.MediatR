using MediatR;
using ProofsOfConcepts.DotNet.MediatR.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofsOfConcepts.DotNet.MediatR.Events
{
    public class OrderCreatedEvent : IRequest<Order>
    {
        public Guid OrderId { get; private set; }
        public Customer Customer { get; private set; }
        public IEnumerable<Product> ListOfProducts { get; private set; }

        public OrderCreatedEvent(
            Guid orderId, 
            Customer customer,
            IEnumerable<Product> listOfProducts)
        {
            OrderId = orderId;
            Customer = customer;
            ListOfProducts = listOfProducts;
        }
    }
}
