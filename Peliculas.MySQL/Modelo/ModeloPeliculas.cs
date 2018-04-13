namespace Peliculas.MySQL.Modelo
{
    using MySql.Data.Entity;
    using System.Data.Entity;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal class ModeloPeliculas : DbContext
    {
        public ModeloPeliculas()
            : base("name=ModeloPeliculas")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Pelicula>()
                .HasMany(p => p.Actores)
                .WithMany(a => a.Peliculas)
                .Map(m =>
                {
                    m.MapLeftKey("idPelicula");
                    m.MapRightKey("idActor");
                    m.ToTable("ActoresPorPelicula");
                });
        }

        public virtual DbSet<Pelicula> Peliculas { get; set; }

        public virtual DbSet<Actor> Actores { get; set; }
    }
}