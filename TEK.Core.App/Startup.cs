using Audit.Core;
using Audit.PostgreSql.Configuration;
using Audit.WebApi;
using AutoMapper;
using CS.VM.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using TEK.Core.App.AutoMapper;
using TEK.Core.App.Domain.Services;
using TEK.Core.App.Job;
using TEK.Core.App.Job.JobScanDevice;
using TEK.Core.App.Job.Models;
using TEK.Core.App.Middleware;
using TEK.Core.App.Models;
using TEK.Core.Service.Interfaces;
using TEK.Email.Interfaces;
using static CS.Common.Common.Constants;

namespace TEK.Payment.Core.Admin
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="hostingEnvironment">The hosting environment.</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                    });
            });

            services.AddLogging();
            services.Configure<Dictionary<string, string>>(Configuration.GetSection("Mime"));

            services
           .Configure<Settings>(Configuration)
           .AddSingleton(sp => sp.GetRequiredService<IOptions<Settings>>().Value);

            services
           .Configure<EmailSettings>(Configuration)
           .AddSingleton(sp => sp.GetRequiredService<IOptions<EmailSettings>>().Value);

            var sqlConnectionString = Configuration.GetConnectionString(nameof(ApplicationDbContext));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseNpgsql(sqlConnectionString)).AddUnitOfWork<ApplicationDbContext>();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateFormatString = DateTimeFormatConstants.CustomDefault;
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddControllersWithViews(options =>
            {
                options.AddAuditFilter(config => config
                    .LogAllActions()
                    .WithEventType("{verb}.{controller}.{action}")
                    .IncludeHeaders(ctx => !ctx.ModelState.IsValid)
                    //.IncludeRequestBody()
                    .IncludeModelState()
                    .IncludeResponseBody(ctx => ctx.HttpContext.Response.StatusCode == 200));

                options.Filters.Add(typeof(ValidateModelAttribute));
                //options.Filters.Add(new AuditIgnoreActionFilter());
            });

            //Job
            services.AddHostedService<QuartzHostedService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<JobScanDeviceSchedule>();

            var isStartJob = Configuration.GetValue<bool>("JobSchedule:IsStart");

            if (isStartJob)
                services.AddSingleton(new JobSchedule(
                    jobType: typeof(JobScanDeviceSchedule),
                    cronExpression: Configuration.GetValue<string>("JobSchedule:JobScanDeviceSchedule")));

            // Add memory cache services
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            //services.AddServiceFactory();

            services.Configure<MvcOptions>(options =>
            {
                //options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = Configuration.GetValue<int>("LengthLimit:Value"); // Limit on individual form values
                x.MultipartBodyLengthLimit = Configuration.GetValue<long>("LengthLimit:BodyLength"); // Limit on form body size
                x.MultipartHeadersLengthLimit = Configuration.GetValue<int>("LengthLimit:HeadersLength"); // Limit on form header size
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = Configuration.GetValue<long>("LengthLimit:BodyLength"); // Limit on request body size
            });

            // Services
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IVersionService, VersionService>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IEmailSender, EmailSenderService>();
            services.AddTransient<IBundleService, BundleService>();
            services.AddTransient<ICommandService, CommandService>();
            services.AddTransient<IDeviceConfigService, DeviceConfigService>();

            // Automapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            services.AddHttpContextAccessor();

            // Services

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Control Device API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(middleware: typeof(ErrorWrappingMiddleware));

            app.Use(async (context, next) =>
            {  // <----
                context.Request.EnableBuffering(); // or .EnableRewind();
                await next();
            });

            var sqlConnectionString = Configuration.GetConnectionString(nameof(ApplicationDbContext));

            Audit.Core.Configuration.Setup()
                .UsePostgreSql(config => config
                .ConnectionString(sqlConnectionString)
                .TableName("audit_log")
                .IdColumnName("id")
                .DataColumn("data", DataType.JSONB)
                .LastUpdatedColumnName("updated_date"))
                .WithCreationPolicy(EventCreationPolicy.InsertOnStartReplaceOnEnd);

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider(new Dictionary<string, string>
                {
                    { ".apk", "application/vnd.android.package-archive" },
                    { ".nupkg", "application/zip" },
                    { ".txt", "text/plain" },
                    { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" }
                }) 
            });


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
