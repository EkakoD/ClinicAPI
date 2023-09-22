using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Application.Category.Query.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ClinicAPi.Presentation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoriesController : BaseController
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserDetails([FromQuery] GetCategoriesQuery model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }
    }
}

