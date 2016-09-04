using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;
namespace Repositories
{
    public class OkDescriptRepositorie : BasicRepository<OKDesription>, IBasicRepository<OKDesription>
    {
        public OkDescriptRepositorie(AQLM2Entities context) : base(context)
        {
        }
    }
}
