using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Cursos.Helper
{
    public class ErrorHelper
    {
        public static ResponseObject Response(int StatusCode, string Message)
        {
            return new ResponseObject()
            {
                Type = "C", //Custom
                StatusCode = StatusCode,
                Message = Message
            };
        }

        public static List<ModelErrors> GetModelStateErrors(ModelStateDictionary Model)
        {
            return Model.Select(x => new ModelErrors() { Type = "M", Key = x.Key, Messages = x.Value.Errors.Select(y => y.ErrorMessage).ToList() }).ToList();
        }
    }
}
