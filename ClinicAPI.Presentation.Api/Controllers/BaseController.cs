using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClinicAPI.Application.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicAPi.Presentation.Api.Controllers
{
    public class BaseController : ControllerBase
    {

        private IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseController()
        {
        }

        /// <summary>
        /// Global Mediator Helper 
        /// </summary>
        protected IMediator Mediator => _mediator ?? (_mediator = (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator)));

        public IActionResult Execute<T>( IResponse<T> response)
        {
            return response.Code switch
            {
                ClinicAPI.Application.Base.StatusCode.BadRequest => new BadRequestObjectResult(response),
                ClinicAPI.Application.Base.StatusCode.NotFound => new BadRequestObjectResult(response),
                _ => new OkObjectResult(response)
            };
        }

    }
}

