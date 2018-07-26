using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BenDan
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #region swaggerui
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "BenDan API",
                        Version = "v1",
                        Description = "笨蛋博客API该版本为V1，还有很多不足之处，如有问题可以通过邮箱联系本人。",
                        License = new License
                        {
                            Name = "MIT",
                            Url = "https://mit-license.org/"
                        },
                        Contact = new Contact
                        {
                            Name = "抓住那只羊驼",
                            Email = "admin@3gjn.com"
                        },

                    }
                 );

                var filePath = Path.Combine(AppContext.BaseDirectory, "BenDan.xml");
                c.IncludeXmlComments(filePath,true);//添加控制器层注释（true表示显示控制器注释）
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            #region SwaggerUI

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/bendan.json";           
            });


            app.UseSwaggerUI(c =>
            {
                c.IndexStream = () => GetType().GetTypeInfo().Assembly
                   .GetManifestResourceStream("BenDan.index.html");

                c.SwaggerEndpoint("/api-docs/v1/bendan.json", "BenDan API V1");
                c.RoutePrefix = "";
                c.DocumentTitle = "BenDan API";
            });

            #endregion 
        }
    }
}
