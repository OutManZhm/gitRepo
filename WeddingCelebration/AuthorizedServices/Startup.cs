using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Configuration;

namespace Authorized_services
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {

            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //     services.AddIdentityServer()
            //         .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //// .AddInMemoryApiResources(Config.GetApiResources())  //������Դ
            //         .AddInMemoryClients(Config.GetClients())            //���ÿͻ���
            //        .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
            //        .AddDeveloperSigningCredential();
            //
            var builder = services.AddIdentityServer()
       .AddInMemoryIdentityResources(Config.GetIdentityResources())
       .AddInMemoryClients(Config.GetClients())
       //.AddTestUsers(Config.GetUsers());
       
       .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();
            
            builder.AddDeveloperSigningCredential();

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // ��������ӷ���ע��
            var config = new ConfigurationBuilder();

            config.AddJsonFile("autofac.json");
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            //app.UseAuthorization();
            app.UseIdentityServer();
            app.UseAuthorization();
            //  app.UseMvc();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
