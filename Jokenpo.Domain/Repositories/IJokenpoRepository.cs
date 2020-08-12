using Jokenpo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jokenpo.Domain.Repositories
{
    public interface IJokenpoRepository
    {
        Task Create(JokenpoItem jokenpo);
        Task<IEnumerable<JokenpoItem>> GetAll();
    }
}