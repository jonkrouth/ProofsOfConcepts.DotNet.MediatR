using ProofsOfConcepts.DotNet.MediatR.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofsOfConcepts.DotNet.MediatR.ExtensionMethods
{
    public static class OrderExtensions
    {
        public static Order WithCustomer(this Order order, Customer customer)
        {
            return new Order(
                order.Id,
                customer,
                order.ListOfProducts,
                order.TotalCost);
        }

        public static Order WithListOfProducts(this Order order, IEnumerable<Product> listOfProducts)
        {
            return new Order(
                order.Id, 
                order.Customer, 
                listOfProducts,
                order.TotalCost);
        }

        public static Order WithTotalCost(this Order order, decimal totalCost)
        {
            return new Order(
                order.Id,
                order.Customer,
                order.ListOfProducts,
                totalCost);
        }
    }
}
