using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;
namespace Repositories
{
    public class PiloteRepositories : BasicRepository<Pilote>, IBasicRepository<Pilote>
    {
        public PiloteRepositories(AQLM2Entities context) : base(context)
        {
        }
    }
   
}
