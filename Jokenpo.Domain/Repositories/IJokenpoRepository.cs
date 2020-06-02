using System.Collections.Generic;
using System.Threading.Tasks;
using Jokenpo.Domain.Entities;

namespace Jokenpo.Domain.Repositories
{
    public interface IJokenpoRepository
    {
         void Create(JokenpoItem jokenpo);
         IEnumerable<JokenpoItem> GetAll();
    }
}