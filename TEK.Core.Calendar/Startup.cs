using Audit.Core;
using Audit.PostgreSql.Configuration;
using Audit.WebApi;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TEK.Core.App.Middleware;
using TEK.Core.Calendar.AutoMapper;
using TEK.Core.Calendar.Domain.Services;
using TEK.Core.Calendar.Models;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.Calendar
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

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddLogging();

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

            var sqlConnectionString = Configuration.GetConnectionString(nameof(ApplicationDbContext));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseNpgsql(sqlConnectionString)).AddUnitOfWork<ApplicationDbContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Users Demo", Version = "v1" });
            });

            services.AddTransient<IShiftService, ShiftService>();
            services.AddTransient<ICardService, CardService>();

            // Automapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
              //  app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Users Demo V1");
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
