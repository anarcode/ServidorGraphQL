namespace RestConGraph.Core
{
    using Binders;
    using Models;
    using Peliculas.Core.Interfaces;
    using Peliculas.MySQL.Repositorios;
    using System;
    using System.Collections.Generic;
    using Unity;

    public class Contenedor
    {
        public static IUnityContainer Registrar(IUnityContainer contenedor)
        {
            contenedor.RegisterInstance
            (
                new ModeloBinder(new List<Type> { typeof(Pelicula) })
            );

            contenedor.RegisterType<IRepositorio<IPelicula>, RepositorioDePeliculas>();
            contenedor.RegisterType<IRepositorio<IActor>, RepositorioDeActores>();

            return contenedor;
        }
    }
}