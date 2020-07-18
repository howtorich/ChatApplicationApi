namespace SocialCommunicationsApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SocialCommunicationsApi.Controllers;

    public class Startup
    {
        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940.
        /// </summary>
        /// <param name="services">services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Added By Pavan.Somineni Due to error(Unknown error 0) while Browsing(Rest Call in Chrome) in Chrome.
            services.AddCors();
            services.AddSignalR();
            services.AddMvc().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /// <summary>
        /// Add Controllers.
        /// </summary>
        /// <param name="app"> Applications.</param>
        /// <param name="env"> Enviroments.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Added By Pavan.Somineni Due to error(Unknown error 0) while Browsing(Rest Call in Chrome) in Chrome.
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endPoint =>
            {
                endPoint.MapHub<ChatController>("/chatHub");
            });

            // app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
