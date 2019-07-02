using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.API.Helpers;
using GraphQL.Core.Models;
using GraphQL.Types;

namespace GraphQL.API.Models
{
    public class GraphQLMutation: ObjectGraphType
    {
        public GraphQLMutation(ContextServiceLocator contextServiceLocator)
        {
            Name = "mutation";

            Field<PlayerType>(
                "createPlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerInputType>> { Name = "player" }
                ),
                resolve: context =>
                {
                    var player = context.GetArgument<Player>("player");
                    return contextServiceLocator.PlayerRepository.Add(player);
                });
        }
    }
}
