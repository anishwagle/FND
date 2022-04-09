using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FND.DAO;
using FND.DAO.Impl;
using FND.Helpers;
using FND.Middlewares;
using FND.Services;
using FND.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FND.Helpers;

namespace FND
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FND", Version = "v1" });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddTransient<IJwtUtils, JwtUtils>()
            .AddTransient<IVideoService, VideoService>()
            .AddTransient<IVideoDao, VideoDao>()
            .AddTransient<IStoryService, StoryService>()
            .AddTransient<IStoryDao, StoryDao>()
            .AddTransient<IPostService, PostService>()
            .AddTransient<IPostDao, PostDao>()
            .AddTransient<IFAQService, FAQService>()
            .AddTransient<IFAQDao, FAQDao>()
            .AddTransient<ISymptomMonitoringRecordService, SymptomMonitoringRecordService>()
            .AddTransient<ISymptomMonitoringRecordDao, SymptomMonitoringRecordDao>()
            .AddTransient<ISeizureMonitoringRecordService, SeizureMonitoringRecordService>()
            .AddTransient<ISeizureMonitoringRecordDao, SeizureMonitoringRecordDao>()
            .AddTransient<IDailyLogService, DailyLogService>()
            .AddTransient<IDailyLogDao, DailyLogDao>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<IUserDao, UserDao>()
            .AddTransient<IUserInfoService, UserInfoService>()
            .AddTransient<IUserInfoDao, UserInfoDao>()
            .AddTransient<ISMRFormService, SMRFormService>()
            .AddTransient<ISMRFormDao, SMRFormDao>()
            .AddTransient<ISMPFormService, SMPFormService>()
            .AddTransient<ISMPFormDao, SMPFormDao>()
            .AddTransient<IMailService, MailService>();
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FND v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
