using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Core.Data;
using GraphQL.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly GraphQLDbContext _db;

        public PlayerRepository(GraphQLDbContext db)
        {
            _db = db;
        }

        public async Task<Player> Get(int id)
        {
            return await _db.Players.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Player> GetRandom()
        {
            return await _db.Players.OrderBy(o => Guid.NewGuid()).FirstOrDefaultAsync();
        }

        public async Task<List<Player>> All()
        {
            return await _db.Players.ToListAsync();
        }

        public async Task<Player> Add(Player player)
        {
            await _db.Players.AddAsync(player);
            await _db.SaveChangesAsync();
            return player;
        }
    }
}
