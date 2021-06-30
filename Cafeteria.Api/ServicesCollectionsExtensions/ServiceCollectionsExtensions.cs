using AutoMapper;
using Dapper;
using Cafeteria.Api.Business;
using Cafeteria.Api.Data.Repositories;
using Cafeteria.Api.Domain.Models.Request;
using Cafeteria.Api.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using static Cafeteria.Api.Filters.ValidateModelFilter;

namespace Cafeteria.Api.ServicesCollectionsExtensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddMvc(options => { options.Filters.Add(typeof(ValidateModelAttribute)); }).AddFluentValidation();
            services.AddScoped<IValidator<CafeRequest>, CafeValidator>();
            services.AddScoped<IValidator<CafeUpdateRequest>, CafeUpdateValidator>();

            return services;
        }

        public static IServiceCollection SwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(configuration =>      // arrowfunction
            {
                configuration.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Cafeteria API",
                    Version = "v1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML"; //
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                configuration.IncludeXmlComments(xmlPath);// configuration ou options
            });
            return services;
        }

        public static IServiceCollection DapperServices(this IServiceCollection services)
        {
            services.AddScoped<CafeRepository>(); //DAPPER responsavel pelo mapeapento dos insert 
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            return services;
        }

        public static IServiceCollection BusinesServices(this IServiceCollection services)
        {
            services.AddTransient<CafeBL>();
            return services;
        }

        public static IServiceCollection RepositoryServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(new Action<IMapperConfigurationExpression>(x => { }), typeof(Startup));
            return services;
        }
    }
}
