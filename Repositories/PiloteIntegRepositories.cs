using Data;
using Entities;

namespace Repositories
{
    public class PiloteIntegRepositories:BasicRepository<PiloteInteg>,IBasicRepository<PiloteInteg>
    {
        public PiloteIntegRepositories(AQLM2Entities context) : base(context)
        {
        }

           
    }
}