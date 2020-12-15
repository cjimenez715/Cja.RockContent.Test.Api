using Cja.RockContent.Test.Api.Models;
using Cja.RockContent.Test.Api.Services;
using Cja.RockContent.Test.Api.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MediatR;
using Cja.RockContent.Test.Api.Communication;
using Cja.RockContent.Test.Api.Handlers;

namespace Cja.RockContent.Test.Api
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

            services.Configure<PostLikedataseSettings>(
                Configuration.GetSection(nameof(PostLikedataseSettings)));
            services.AddSingleton<IPostLikedataseSettings>(provider =>
                provider.GetRequiredService<IOptions<PostLikedataseSettings>>().Value);

            services.AddSingleton<IRepository, Repository>();
            
            services.AddScoped<IPostLikeService, PostLikeService>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddCors();
            services.AddControllers();

            services.AddMediatR(typeof(Startup));

            services.AddSignalR();

            services.AddScoped<INotificationHandler<PostLikedEvent>, PostLikeEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<LikedHub>("/_hubs/likedhub");
            });
        }
    }
}
