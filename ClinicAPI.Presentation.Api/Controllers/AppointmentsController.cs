using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Application.Appointments.Command.CreateAppointment;
using ClinicAPI.Application.Appointments.Command.DeleteAppointment;
using ClinicAPI.Application.Appointments.Query.GetAppointmentTimes;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ClinicAPi.Presentation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AppointmentsController : BaseController
    {
        private readonly IMediator _mediator;
        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateClient([FromBody] CreateAppointmentCommand model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAppointment([FromBody] DeleteAppointmentCommand model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserDetails([FromQuery] GetAppointmentTimesQuery model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }
    }
}

