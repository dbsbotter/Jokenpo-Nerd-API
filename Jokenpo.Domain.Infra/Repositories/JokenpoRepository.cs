using System.Collections.Generic;
using System.Threading.Tasks;
using Jokenpo.Domain.Entities;
using Jokenpo.Domain.Infra.Contexts;
using Jokenpo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jokenpo.Domain.Infra.Repositories
{
    public class JokenpoRepository : IJokenpoRepository
    {
        private readonly DataContext _context;

        public JokenpoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(JokenpoItem jokenpo)
        {
            _context.Jokenpos.Add(jokenpo);
            _context.SaveChanges();
        }

        public IEnumerable<JokenpoItem> GetAll()
        {
            return _context
                .Jokenpos
                .AsNoTracking();
        }
    }
}