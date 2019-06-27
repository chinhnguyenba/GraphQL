using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.API.Helpers;
using GraphQL.Types;

namespace GraphQL.API.Models
{
    public class GraphQLQuery: ObjectGraphType
    {
        public GraphQLQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<PlayerType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => contextServiceLocator.PlayerRepository.Get(context.GetArgument<int>("id")));

            Field<PlayerType>(
                "randomPlayer",
                resolve: context => contextServiceLocator.PlayerRepository.GetRandom());

            Field<ListGraphType<PlayerType>>(
                "players",
                resolve: context => contextServiceLocator.PlayerRepository.All());
        }
    }
}
