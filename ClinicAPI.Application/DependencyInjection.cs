﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClinicAPI.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        //services.AddScoped<ISmsHelper, SmsHelper>();

        return services;
    }
}