using MediatR;
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
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using SocialNetworkWebApp.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp
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
            services.AddMediatR(typeof(Startup));

            services.AddScoped<IRepository<ChatroomEntity>, ChatroomRepository>();
            services.AddScoped<IRepository<CommentEntity>, CommentRepository>();
            services.AddScoped<IRepository<ContentEntity>, ContentRepository>();
            services.AddScoped<IRepository<FriendshipEntity>, FriendshipRepository>();
            services.AddScoped<IRepository<MessageEntity>, MessageRepository>();
            services.AddScoped<IRepository<PostEntity>, PostRepository>();
            services.AddScoped<IRepository<ReactEntity>, ReactRepository>();
            services.AddScoped<IRepository<UserEntity>, UserRepository>();

            services.AddDbContext<SocialNetworkContext>(
                option =>
                option.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialNetworkWebApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialNetworkWebApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
