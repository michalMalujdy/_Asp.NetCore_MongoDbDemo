using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    public abstract class MediatorController : ControllerBase
    {
        private IMediator _mediator;

        protected virtual IMediator Mediator
        {
            get
            {
                return _mediator ??= (IMediator) HttpContext.RequestServices.GetService(typeof (IMediator));
            }
        }
    }
}