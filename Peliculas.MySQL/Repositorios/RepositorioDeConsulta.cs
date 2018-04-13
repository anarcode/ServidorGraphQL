namespace Peliculas.MySQL.Repositorios
{
    using Modelo;
    using GraphQL.Net;
    using System.Linq;
    using Core.Interfaces;

    public class RepositorioDeConsulta : IRepositorioDeConsulta
    {
        GraphQLSchema<ModeloPeliculas> _schema;

        public RepositorioDeConsulta() //ModeloPeliculas modelo)
        {
            var modelo = new ModeloPeliculas(); // = modelo;
            var pel = modelo.Peliculas.FirstOrDefault();

            _schema = GraphQL<ModeloPeliculas>.CreateDefaultSchema(() => modelo);

            var pelicula = _schema.AddType<Pelicula>();
            pelicula.AddField(p => p.Id);
            pelicula.AddField(p => p.Nombre);

            _schema.AddListField("peliculas", db => db.Peliculas);
            _schema.AddField("pelicula", new { id = 0 }, (db, args) => db.Peliculas.Where(p => p.Id == args.id).FirstOrDefault());
            _schema.Complete();
        }

        public void Buscar(string consulta)
        {
            consulta = @"{ pelicula(id: 1) { id nombre }}";
            var gql = new GraphQL<ModeloPeliculas>(_schema);
            var q = gql.ExecuteQuery(consulta);
        }
    }
}