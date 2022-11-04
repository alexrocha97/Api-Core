using Aplication.Model;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class DevContext : DbContext
    {
        public DevContext(DbContextOptions<DevContext> options) : base(options)
        {}

        public DbSet<UsuarioModel> Usuarios { get; set;}
        public DbSet<TarefaModel> Tarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }
    }
}
