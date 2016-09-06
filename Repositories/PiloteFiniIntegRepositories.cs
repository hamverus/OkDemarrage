using Data;
using Entities;

namespace Repositories
{
    public class PiloteFiniIntegRepositories: BasicRepository<PiloteFiniInteg>,IBasicRepository<PiloteFiniInteg>
    {
        public PiloteFiniIntegRepositories(testEntities context) : base(context)
        {
            
        }   
    }   
}