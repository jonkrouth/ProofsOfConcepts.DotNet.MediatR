# ProofsOfConcepts.DotNet.MediatR

This is a solution where I demonstrate updating an entity using notifications sent from an aggregate root.

MediatR can be found [here.](https://github.com/jbogard/MediatR/wiki)

The purpose of this solution is to show an example of an order value type being updated by handler methods. The handler
methods are split out in such a way that they handle responding to an event that is sent from the aggregate root.

This way, small pieces of business logic can be split out into handlers, while the aggregate root can be used to define
the actions of the bounded context.