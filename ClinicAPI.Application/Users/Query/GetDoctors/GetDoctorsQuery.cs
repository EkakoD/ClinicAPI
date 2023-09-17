using System;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetDoctors
{
    public class GetDoctorsQuery : IRequest<List<DoctorsModel>>
    {
        // კატეგორიის ფილტრისთვის
        public int? CategoryId { get; set; }
    }
}

