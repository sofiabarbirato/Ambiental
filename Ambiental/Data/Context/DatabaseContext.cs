using Ambiental.Models;
using Microsoft.EntityFrameworkCore;

namespace Ambiental.Data.Context
{
    public class DatabaseContext : DbContext
    {

        public DbSet <QualidadeArModel> QualidadeArModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QualidadeArModel>( e => {

                e.ToTable("QUALIDADEAR");

                e.HasKey(e => e.Id);

                e.Property(e => e.Localizacao);
                e.Property(e => e.IndiceQualidade ).IsRequired();
                e.Property(e => e.DataLeitura );

                e.HasIndex(e => e.Id);


            } );
            
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
    }
}
