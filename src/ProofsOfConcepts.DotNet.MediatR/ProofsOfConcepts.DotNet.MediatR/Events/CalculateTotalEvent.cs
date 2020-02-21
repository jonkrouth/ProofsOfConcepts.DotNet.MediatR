using MediatR;
using ProofsOfConcepts.DotNet.MediatR.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofsOfConcepts.DotNet.MediatR.Events
{
    public class CalculateTotalEvent : IRequest<Order>
    {
        public Order Order { get; private set; }
        public decimal TotalCost { get; private set; }

        public CalculateTotalEvent(Order order, decimal totalCost)
        {
            Order = order;
            TotalCost = totalCost;
        }
    }
}
