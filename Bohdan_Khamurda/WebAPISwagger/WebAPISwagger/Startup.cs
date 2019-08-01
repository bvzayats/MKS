﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebAPISwagger.Mapping;
using WebAPISwagger.Services;

namespace WebAPISwagger {
    public class Startup {
        public Startup( IConfiguration configuration ) {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services ) {

            services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );
            services.AddSwaggerGen( c => {

                c.SwaggerDoc( "v1", new Info {

                    Version = "v1",
                    Title = "API",
                    Description = "ASP.NET Core 2.2 Web API"
                } );
            } );

            string connection = Configuration.GetConnectionString( "DefaultConnection" );
            services.AddDbContext<UniversityContext>( options => options.UseSqlServer( connection ) );
            services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );

            services.AddScoped<IStudentService, StudentService>();

            var mappingConfig = new MapperConfiguration( mc => {

                mc.AddProfile( new MappingProfile() );
            } );

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton( mapper );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env ) {

            if ( env.IsDevelopment() ) {

                app.UseDeveloperExceptionPage();
            }
            else {

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var swaggerOptions = new Options.SwaggerOptions();
            Configuration.GetSection( nameof( Swashbuckle.AspNetCore.Swagger.SwaggerOptions ) ).Bind( swaggerOptions );

            app.UseSwagger( option => {
                option.RouteTemplate = swaggerOptions.JsonRoute;
            } );

            app.UseSwaggerUI( option => {
                option.SwaggerEndpoint( swaggerOptions.UIEndpoint, swaggerOptions.Description );
            } );

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
