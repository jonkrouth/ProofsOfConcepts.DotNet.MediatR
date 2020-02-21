using ProofsOfConcepts.DotNet.MediatR.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProofsOfConcepts.DotNet.MediatR.Interfaces
{
    public interface IOrderAggregateRoot
    {
        Task<Order> CreateNewOrder(Customer customer, IEnumerable<Product> listOfProducts);
        Task<Order> AddProduct(Order order, Product product);
    }
}
