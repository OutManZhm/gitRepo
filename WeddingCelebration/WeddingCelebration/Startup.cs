using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeddingCelebration.ApiGroup;
using WeddingCelebration.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace WeddingCelebration
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

            services.AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", options =>
        {
            options.Authority = "http://http://192.168.0.102:2001";
            options.RequireHttpsMetadata = false;
            options.Audience = "clientservice";
        });


            services.AddSwaggerGen(options =>
            {
                typeof(ApiGroupNames).GetFields().Skip(1).ToList().ForEach(f =>
                {
                    //��ȡö��ֵ�ϵ�����
                    var info = f.GetCustomAttributes(typeof(GroupInfoAttribute), false).OfType<GroupInfoAttribute>().FirstOrDefault();
                    options.SwaggerDoc(f.Name, new OpenApiInfo
                    {
                        Title = info?.Title,
                        Version = info?.Version,
                        Description = info?.Description
                    });
                });
                //û�м����Եķֵ����NoGroup��
                options.SwaggerDoc("NoGroup", new OpenApiInfo
                {
                    Title = "�޷���"
                });


                //�жϽӿڹ����ĸ�����
                options.DocInclusionPredicate((docName, apiDescription) =>
                {
                    if (docName == "NoGroup")
                    {
                        ApiGroupAttribute atts = apiDescription.CustomAttributes().Where(c => c.GetType().ToString().EndsWith("ApiGroupAttribute")).FirstOrDefault() as ApiGroupAttribute;
                        //������ΪNoGroupʱ��ֻҪû�����ԵĶ����������
                        return atts == null || atts.listName.Count == 0;
                    }
                    else
                    {
                        ApiGroupAttribute atts = apiDescription.CustomAttributes().Where(c => c.GetType().ToString().EndsWith("ApiGroupAttribute")).FirstOrDefault() as ApiGroupAttribute;
                        if (atts != null && atts.listName.Count > 0)
                        {
                            return atts.listName.Contains(docName);
                        }

                        return false;
                    }
                });

                //Determine base path for the application.  
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //Set the comments path for the swagger json and ui.  
                var xmlPath = Path.Combine(basePath, "MsSystem.API.xml");
                options.IncludeXmlComments(xmlPath);
            });


            services.AddControllersWithViews().AddControllersAsServices();
            services.AddMvc(t => { t.Filters.Add<ActionFilter>(); });
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

            app.UseHttpsRedirection();

            app.UseRouting();
        
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //����ApiGroupNames����ö��ֵ���ɽӿ��ĵ���Skip(1)����ΪEnum��һ��FieldInfo�����õ�һ��Intֵ
                typeof(ApiGroupNames).GetFields().Skip(1).ToList().ForEach(f =>
                {
                    //��ȡö��ֵ�ϵ�����
                    var info = f.GetCustomAttributes(typeof(GroupInfoAttribute), false).OfType<GroupInfoAttribute>().FirstOrDefault();
                    options.SwaggerEndpoint($"/swagger/{f.Name}/swagger.json", info != null ? info.Title : f.Name);

                });
                options.SwaggerEndpoint("/swagger/NoGroup/swagger.json", "�޷���");
            });



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
