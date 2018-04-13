namespace RestConGraph.Graph
{
    using GraphQL.Types;
    using Peliculas.Core.Interfaces;

    public class GraphQLQuery : ObjectGraphType
    {
        IRepositorio<IPelicula> _películas;
        IRepositorio<IActor> _actores;

        public GraphQLQuery(IRepositorio<IPelicula> peliculas, IRepositorio<IActor> actores)
        {
            _películas = peliculas;
            _actores = actores;

            Field<ListGraphType<PeliculaType>>("peliculas",
                resolve: context =>
                {
                    return _películas.Todas();
                }
            );

            Field<PeliculaType>("pelicula",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "id", ResolvedType = new IntGraphType() }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return _películas.Buscar(id);
                }
            );

            Field<ListGraphType<ActorType>>("actores",
                resolve: context =>
                {
                    return _actores.Todas();
                }
            );

            Field<ActorType>("actor",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "id", ResolvedType = new IntGraphType() }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return _actores.Buscar(id);
                }
            );
        }
    }
}