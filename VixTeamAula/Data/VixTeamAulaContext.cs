using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VixTeamAula.Models;

namespace VixTeamAula.Data
{
    public class VixTeamAulaContext : DbContext
    {
        public VixTeamAulaContext (DbContextOptions<VixTeamAulaContext> options)
            : base(options)
        {
        }

        public DbSet<VixTeamAula.Models.PessoaModel> PessoaModel { get; set; }
    }
}
