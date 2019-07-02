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
                "allplayers",
                resolve: context => contextServiceLocator.PlayerRepository.All());

            Field<PagingType>(
                "players",                
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "num" }, new QueryArgument<IntGraphType> { Name = "limit" }),
                resolve: context => contextServiceLocator.PlayerRepository.Paging(context.GetArgument<int>("num"), context.GetArgument<int>("limit")));
        }
    }
}
