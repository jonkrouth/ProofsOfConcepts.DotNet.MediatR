using MediatR;
using ProofsOfConcepts.DotNet.MediatR.Events;
using ProofsOfConcepts.DotNet.MediatR.Interfaces;
using ProofsOfConcepts.DotNet.MediatR.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofsOfConcepts.DotNet.MediatR.AggregateRoots
{
    public class OrderAggregateRoot : IOrderAggregateRoot
    {
        private readonly IMediator _mediator;

        public OrderAggregateRoot(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Order> CreateNewOrder(Customer customer, IEnumerable<Product> listOfProducts)
        {
            var order = await _mediator.Send(
                new OrderCreatedEvent(
                    Guid.NewGuid(),
                    customer,
                    listOfProducts))
                .ConfigureAwait(false);

            order = await _mediator.Send(
                new CalculateTotalEvent(
                    order,
                    order.ListOfProducts.Sum(x => x.Cost)))
                .ConfigureAwait(false);

            return order;
        }

        public async Task<Order> AddProduct(Order order, Product product)
        {
            order = await _mediator.Send(
                new ProductAddedEvent(
                    product, 
                    order))
                .ConfigureAwait(false);

            order = await _mediator.Send(
                    new CalculateTotalEvent(
                    order,
                    order.ListOfProducts.Sum(x => x.Cost)))
                .ConfigureAwait(false);

            return order;
        }
    }
}
