using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Application.Category.Query.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicAPi.Presentation.Api.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> GetUserDetails([FromQuery] GetCategoriesQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}

