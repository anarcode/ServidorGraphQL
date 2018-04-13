namespace RestConGraph.Graph
{
    using GraphQL.Types;
    using Peliculas.MySQL.Modelo;

    public class PeliculaType : ObjectGraphType<Pelicula>
    {
        public PeliculaType()
        {
            Field(p => p.Id).Description("Identificador de película");
            Field(p => p.Nombre).Description("Nombre de la pelicula");
            Field(p => p.Actores, type: typeof(ListGraphType<ActorType>)).Description("Actores que participan");
        }
    }
}