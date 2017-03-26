namespace Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelsDbContext : DbContext
    {
        public ModelsDbContext()
            : base("name=Models")
        {
        }

        public virtual DbSet<Peticione> Peticiones { get; set; }
        public virtual DbSet<PeticionesNoProcesada> PeticionesNoProcesadas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
