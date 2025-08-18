using hexagonTabela.Entity;
using Microsoft.EntityFrameworkCore;

namespace hexagonTabela.Context
{
    public class HexagonContext : DbContext
    {
        public HexagonContext(DbContextOptions<HexagonContext>options) : base(options) { }
        public HexagonContext(){}

        public DbSet<Registro> Registros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
