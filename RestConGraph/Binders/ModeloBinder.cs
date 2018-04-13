namespace RestConGraph.Binders
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;

    public class ModeloBinder : Base64Binder
    {
        ICollection<Type> _tiposDelModelo;

        public ModeloBinder(ICollection<Type> tiposDelModelo)
        {
            _tiposDelModelo = tiposDelModelo;
        }

        public override bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (!_tiposDelModelo.Contains(bindingContext.ModelType))
            {
                return false;
            }

            if(base.BindModel(actionContext, bindingContext))
            {
                bindingContext.Model = JsonConvert.DeserializeObject(bindingContext.Model.ToString(), bindingContext.ModelType);
                return true;
            }

            return false;
        }
    }
}