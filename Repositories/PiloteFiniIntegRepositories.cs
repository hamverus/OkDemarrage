using Data;
using Entities;

namespace Repositories
{
    public class PiloteFiniIntegRepositories: BasicRepository<PiloteFiniIntegration>,IBasicRepository<PiloteFiniIntegration>
    {
        public PiloteFiniIntegRepositories(AQLM2Entities context) : base(context)
        {
            
        }   
    }
}