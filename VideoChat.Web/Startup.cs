using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoChat.Data;
using MediatR;
using VideoChat.EF;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VideoChat.Core.Requests;

namespace VideoChat.Web
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
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VideoChat.Web", Version = "v1" });
            });
            services.AddMediatR(typeof(Startup));
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            services.AddScoped<IDatabaseFactory, DatabaseFactory>((provider) => {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                return new DatabaseFactory(connectionString);
            });
            services.AddCors();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRequestHandler<CreateRoom, string>, CreateRoomHandler>();
            services.TryAddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VideoChat.Web v1"));
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration["Cors:Origin"])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Content-Disposition");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
