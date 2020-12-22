using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgendCont.Models
{
    public class AgentContContext : DbContext
    {
        public AgentContContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<AgendCont.Models.Profissional> Profissionals { get; set; }

        public System.Data.Entity.DbSet<AgendCont.Models.Estabeleciment> Estabeleciments { get; set; }
    }
}