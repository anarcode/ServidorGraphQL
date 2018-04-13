using RestConGraph.Binders;
using System.Web.Http.ModelBinding;

namespace RestConGraph.Core
{
    [ModelBinder(typeof(ConsultaBinder))]
    public class Consulta
    {
        string _valor;

        Consulta(string valor)
        {
            _valor = valor;
        }

        public static implicit operator Consulta(string valor)
        {
            return new Consulta(valor);
        }

        public static implicit operator string(Consulta consulta)
        {
            return consulta._valor;
        }
    }
}