using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetDoctors
{
    public class GetDoctorsQuery : IRequest<IResponse<List<DoctorsModel>>>
    {
        // კატეგორიის ფილტრისთვის
        public int? CategoryId { get; set; }
    }
}

