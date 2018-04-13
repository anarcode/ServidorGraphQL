namespace Peliculas.MySQL
{
    using Unity;

    public class Contenedor
    {
        //public static IUnityContainer Registrar(IUnityContainer contenedor, string cadenaConexion)

        public static IUnityContainer Registrar(IUnityContainer contenedor)
        {
            var modelo = new Modelo.ModeloPeliculas();
            //contenedor.RegisterInstance(modelo);
            contenedor.RegisterInstance(new Repositorios.RepositorioDePeliculas(modelo));
            contenedor.RegisterInstance(new Repositorios.RepositorioDeActores(modelo));

            contenedor.RegisterInstance(new Servicios.ServiciosPelículas(modelo));
            return contenedor;
        }
    }
}