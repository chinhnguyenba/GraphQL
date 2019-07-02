using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Core.Data;
using GraphQL.Core.Models;

namespace GraphQL.Data.Es
{
    public class PlayerRepository: IPlayerRepository
    {
        public Task<Player> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetRandom()
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> All()
        {
            throw new NotImplementedException();
        }

        public Task<ResponceData<Player>> Paging(int num, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count()
        {
            throw new NotImplementedException();
        }

        public Task<Player> Add(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
