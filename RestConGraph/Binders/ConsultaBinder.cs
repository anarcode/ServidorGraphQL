namespace RestConGraph.Binders
{
    using Core;
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;

    public class ConsultaBinder : Base64Binder
    {
        public override bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Consulta))
            {
                return false;
            }

            if(base.BindModel(actionContext, bindingContext))
            {
                Consulta consulta = bindingContext.Model.ToString();
                bindingContext.Model = consulta;
                return true;
            }

            return false;
        }
    }
}