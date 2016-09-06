using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;
namespace Repositories
{
    public class PiloteFiniRepositories : BasicRepository<Pilote_Fini>, IBasicRepository<Pilote_Fini>
    {
        public PiloteFiniRepositories(testEntities context) : base(context)
        {
        }
    }
}
