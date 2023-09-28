using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Application.Appointments.Command.CreateAppointment;
using ClinicAPI.Application.Appointments.Command.DeleteAppointment;
using ClinicAPI.Application.Appointments.Query.GetAppointments;
using ClinicAPI.Application.Appointments.Query.GetAppointmentTimes;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace ClinicAPi.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [EnableCors("ClinicOrigins")]
    public class AppointmentsController : BaseController
    {
        private readonly IMediator _mediator;
        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAppointment([FromQuery] DeleteAppointmentCommand model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAppointmentTimes([FromQuery] GetAppointmentTimesQuery model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAppointments([FromQuery] GetAppointmentQuery model)
        {
            var result = await _mediator.Send(model);
            return Execute(result);
        }
    }
}

