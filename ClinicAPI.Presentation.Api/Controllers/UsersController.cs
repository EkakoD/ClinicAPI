using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClinicAPI.Application.Users.Command.CreateClient;
using ClinicAPI.Application.Users.Command.CreateDoctor;
using ClinicAPI.Application.Users.Command.SendTempCode;
using ClinicAPI.Application.Users.Query.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ClinicAPi.Presentation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateClient([FromBody] CreateClientCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateDoctor([FromBody] CreateDoctorCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> SendTempCode([FromBody] SendTempCodeCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetUserDetails([FromQuery] GetUserDetailsQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

    }
}

