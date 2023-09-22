using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Appointments.Query.GetAppointmentTimes
{
	public class GetAppointmentTimesQuery :IRequest<IResponse<List<AppointmentTimesModel>>>
	{
		
	}
}

