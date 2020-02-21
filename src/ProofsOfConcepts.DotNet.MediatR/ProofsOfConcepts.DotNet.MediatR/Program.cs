using Autofac;
using Autofac.Core;
using AutoFixture;
using MediatR;
using ProofsOfConcepts.DotNet.MediatR.AggregateRoots;
using ProofsOfConcepts.DotNet.MediatR.Handlers;
using ProofsOfConcepts.DotNet.MediatR.Interfaces;
using ProofsOfConcepts.DotNet.MediatR.ValueTypes;
using System;
using System.Threading.Tasks;

namespace ProofsOfConcepts.DotNet.MediatR
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /***************************************************
             * SETUP - This would typically be in your IoC setup
             **************************************************/
            var container = RegisterContainerDependencies();
            var fixture = container.Resolve<IFixture>();
            var orderAggregateRoot = container.Resolve<IOrderAggregateRoot>();
            
            /***************************************************
             * Storage - This variable will serve as the 
             * in-memory data store. This would normally be 
             * stored in Kafka.
             **************************************************/
            Order order = null;

            /***************************************************
             * SITUATION 1 - Order Created
             **************************************************/

            // Request data comes in via Kafka consumer message.
            var customer = fixture.Create<Customer>();
            var listOfProducts = fixture.CreateMany<Product>();
                
            // Create a new order.
            // Aggregate calls mediator, which sends request out to handler.
            // Handler sends back new Order.
            order = await orderAggregateRoot.CreateNewOrder(customer, listOfProducts)
                .ConfigureAwait(false);

            /***************************************************
             * SITUATION 2 - Order Updated, Product Added
             **************************************************/
            var newProduct = fixture.Create<Product>();
            order = await orderAggregateRoot.AddProduct(order, newProduct);
            
            
        }

        private static IContainer RegisterContainerDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(typeof(OrderHandler).Assembly).AsImplementedInterfaces();

            builder.RegisterType<OrderAggregateRoot>()
                .As<IOrderAggregateRoot>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Fixture>()
                .As<IFixture>()
                .InstancePerLifetimeScope();

            var container = builder.Build();

            return container;
        }
    }
}
