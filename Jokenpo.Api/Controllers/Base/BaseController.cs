using Microsoft.AspNetCore.Mvc;

namespace Jokenpo.Api.Controllers.Base
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public virtual OkObjectResult DataResult<TValue>(TValue value)
        {
            return new OkObjectResult(new DataResult<TValue>(value));
        }
    }

    public class DataResult<TResult>
    {
        public DataResult() { }

        public DataResult(TResult data)
        {
            Data = data;
        }

        public TResult Data { get; set; }
    }
}