namespace RestConGraph.Graph
{
    using GraphQL.Types;
    using Peliculas.MySQL.Modelo;

    public class ActorType : ObjectGraphType<Actor>
    {
        public ActorType()
        {
            Field(p => p.Id).Description("Identificador de actor");
            Field(p => p.Nombre).Description("Nombre del actor");
            Field(p => p.Peliculas, type: typeof(ListGraphType<PeliculaType>)).Description("Películas en las que participa");
        }
    }
}