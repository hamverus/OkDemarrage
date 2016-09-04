using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;
namespace Repositories
{
    public class PiloteFiniRepositories : BasicRepository<PiloteFini>, IBasicRepository<PiloteFini>
    {
        public PiloteFiniRepositories(AQLM2Entities context) : base(context)
        {
        }
    }
}
