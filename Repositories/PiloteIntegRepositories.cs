using Data;
using Entities;

namespace Repositories
{
    public class PiloteIntegRepositories:BasicRepository<PiloteInteg>,IBasicRepository<PiloteInteg>
    {
        public PiloteIntegRepositories(testEntities context) : base(context)
        {
        }    

           
    }
}