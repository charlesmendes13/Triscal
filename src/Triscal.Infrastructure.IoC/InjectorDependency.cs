﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Application.Interfaces;
using Triscal.Application.Services;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Repository;
using Triscal.Domain.Interfaces.Services;
using Triscal.Domain.Services;
using Triscal.Domain.Validation;
using Triscal.Infrastructure.Data.Repository;

namespace Triscal.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Application

            container.AddScoped(typeof(IBaseAppService<>), typeof(BaseAppService<>));
            container.AddScoped<IClienteAppService, ClienteAppService>();
            container.AddScoped<IEnderecoAppService, EnderecoAppService>();

            // Service

            container.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            container.AddScoped<IClienteService, ClienteService>();
            container.AddScoped<IEnderecoService, EnderecoService>();

            // Repository

            container.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.AddScoped<IClienteRepository, ClienteRepository>();
            container.AddScoped<IEnderecoRepository, EnderecoRepository>();

            // Validator

            container.AddTransient<IValidator<Cliente>, ClienteValidation>();
            container.AddTransient<IValidator<Endereco>, EnderecoValidation>();
        }
    }
}
