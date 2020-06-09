using System.Collections.Generic;
using System.Threading.Tasks;
using Jokenpo.Domain.Entities;

namespace Jokenpo.Domain.Repositories
{
    public interface IJokenpoRepository
    {
         Task Create(JokenpoItem jokenpo);
         Task<IEnumerable<JokenpoItem>> GetAll();
    }
}