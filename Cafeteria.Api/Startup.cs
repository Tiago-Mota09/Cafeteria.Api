using Angis.CTe.API.Filters;
using Cafeteria.Api.ServicesCollectionsExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region :: Services ::
            services.AddFluentValidationServices();
            services.SwaggerServices();
            services.DapperServices();
            services.BusinesServices();
            services.RepositoryServices();
            #endregion

            #region :: FluentValidation ::
            //services.AddMvc(options => { options.Filters.Add(typeof(ValidateModelAttribute)); }).AddFluentValidation();

            //services.AddScoped<IValidator<CafeRequest>, CafeValidator>();
            //services.AddScoped<IValidator<CafeUpdateRequest>, CafeUpdateValidator>();
            #endregion

            #region :: Automapper ::
            //services.AddAutoMapper(typeof(Startup));
            ////services.AddAutoMapper(new Action<IMapperConfigurationExpression>(x => { }), typeof(Startup));
            #endregion

            #region :: Swagger ::
            //services.AddSwaggerGen(configuration =>      // arrowfunction
            //{
            //    configuration.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "Escola API",
            //        Version = "v1"
            //    });

            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML"; //
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            //    configuration.IncludeXmlComments(xmlPath);// configuration ou options
            //});
            #endregion

            #region :: Dapper :: 
            //services.AddScoped<CafeRepository>(); //DAPPER responsavel pelo mapeapento dos insert 
            //DefaultTypeMap.MatchNamesWithUnderscores = true;
            #endregion

            #region :: Business ::
            //services.AddTransient<CafeBL>();
            #endregion

            services.AddMvc();
            services.AddControllers();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(conf =>
            {
                conf.SwaggerEndpoint("/swagger/v1/swagger.json", "Cafeteria API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseHttpsRedirection();
            //app.UserStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
