﻿using System;
using ClinicAPI.Application.Users.Query.GetUserDetails;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Command.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, string>
    {
        private IBaseRepository _repository;
        public CreateClientCommandHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {

            var tempCodeParam = new TempCodeModel
            {
                Email = request.Email,
                Code = request.ActivateCode
            };

            var tempCodeCreateDate = _repository.GetSingle<ResponseModel>("[dbo].[GetTempCode]", tempCodeParam);
            if (tempCodeCreateDate != null)
            {
                if (tempCodeCreateDate.CreateDate.AddMinutes(30) >= DateTime.Now)
                {
                    var model = new CreateClientModel
                    {
                        Firstname = request.Firstname,
                        Lastname = request.Lastname,
                        Email = request.Email,
                        Password = request.Password,
                        PersonalNumber = request.PersonalNumber,
                        RoleId = 3

                    };
                    await _repository.Create<CreateClientModel>("[dbo].[CreateUser]", model);
                    return "მოქმედება წარმატებით შესრულდა";
                }
                else
                {
                    return "აქტივაციის კოდი ვადაგასულია";

                }
            }
            else
            {
                return "აქტივაციის კოდი ან მეილი არასწორია";
            }

        }
    }

}