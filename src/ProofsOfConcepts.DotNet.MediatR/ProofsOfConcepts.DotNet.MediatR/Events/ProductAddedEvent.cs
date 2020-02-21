using MediatR;
using ProofsOfConcepts.DotNet.MediatR.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofsOfConcepts.DotNet.MediatR.Events
{
    public class ProductAddedEvent : IRequest<Order>
    {
        public Product Product { get; private set; }
        public Order Order { get; private set; }

        public ProductAddedEvent(Product product, Order order)
        {
            Product = product;
            Order = order;
        }
    }
}
