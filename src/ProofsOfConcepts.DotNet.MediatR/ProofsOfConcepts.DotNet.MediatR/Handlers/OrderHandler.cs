using MediatR;
using ProofsOfConcepts.DotNet.MediatR.Events;
using ProofsOfConcepts.DotNet.MediatR.ExtensionMethods;
using ProofsOfConcepts.DotNet.MediatR.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProofsOfConcepts.DotNet.MediatR.Handlers
{
    public class OrderHandler : 
        IRequestHandler<OrderCreatedEvent, Order>,
        IRequestHandler<ProductAddedEvent, Order>,
        IRequestHandler<CalculateTotalEvent, Order>
    {
        public async Task<Order> Handle(OrderCreatedEvent e, CancellationToken cancellationToken)
        {
            var newOrder = new Order(
                e.OrderId,
                e.Customer,
                e.ListOfProducts,
                0);

            return newOrder; 
        }

        public async Task<Order> Handle(ProductAddedEvent e, CancellationToken cancellationToken)
        {
            return e.Order.WithListOfProducts(new List<Product>(e.Order.ListOfProducts) { e.Product });
        }

        public async Task<Order> Handle(CalculateTotalEvent e, CancellationToken cancellationToken)
        {
            return e.Order.WithTotalCost(e.TotalCost);
        }
    }
}
