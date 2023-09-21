using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClinicAPI.Application.Base;
using ClinicAPI.Application.Users.Command.CreateClient;
using ClinicAPI.Application.Users.Command.CreateDoctor;
using ClinicAPI.Application.Users.Command.ResetPassword;
using ClinicAPI.Application.Users.Command.SendTempCode;
using ClinicAPI.Application.Users.Query.GetUserDetails;
using ClinicAPI.Application.Users.Query.LogInUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ClinicAPi.Presentation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
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
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserForm  model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }
    }
}

