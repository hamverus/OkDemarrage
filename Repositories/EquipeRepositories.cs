using Data;
using Entities;

namespace Repositories
{
    public class EquipeRepositories:BasicRepository<Equipe>
    {
        public EquipeRepositories(AQLM2Entities context) : base(context)
        {
        }
    }
}