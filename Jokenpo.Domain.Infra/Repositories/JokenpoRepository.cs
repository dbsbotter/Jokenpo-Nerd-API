using Jokenpo.Domain.Entities;
using Jokenpo.Domain.Infra.Contexts;
using Jokenpo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jokenpo.Domain.Infra.Repositories
{
    public class JokenpoRepository : IJokenpoRepository
    {
        private readonly DataContext _context;

        public JokenpoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(JokenpoItem jokenpo)
        {
            using (_context)
            {
                _context.Jokenpos.Add(jokenpo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<JokenpoItem>> GetAll()
        {
            using (_context)
            {
                var result = await _context.Jokenpos.AsNoTracking().ToListAsync();

                return result;
            }
        }
    }
}