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
    public class SkaterStatisticRepository : ISkaterStatisticRepository
    {
        private readonly GraphQLDbContext _db;

        public SkaterStatisticRepository(GraphQLDbContext db)
        {
            _db = db;
        }

        public async Task<List<SkaterStatistic>> Get(int playerId)
        {
            var data = await _db.SkaterStatistics.Include(ss => ss.Season).Include(ss => ss.League).Include(ss => ss.Team).Where(ss => ss.PlayerId == playerId).ToListAsync();
            return data;
        }
    }
}
