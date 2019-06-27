using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Core.Models;

namespace GraphQL.Core.Data
{
    public interface IPlayerRepository
    {
        Task<Player> Get(int id);
        Task<Player> GetRandom();
        Task<List<Player>> All();
        Task<Player> Add(Player player);
    }
}
