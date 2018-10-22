using BooksApplication.data.Postgres;
using BooksApplication.data.Elastic;
using BooksApplication.Middleware;
using BooksApplication.Providers;
using BooksApplication.Services;
using BooksApplication.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BooksApplication.data.Mongo;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace BooksApplication
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
            services.AddDbContext<AuthorContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddOptions();
            services.Configure<ElasticConnectionSettings>(Configuration.GetSection("ElasticConnectionSettings"));

            services.Configure<RedisConnectionSettings>(Configuration.GetSection("RedisConnectionSettings"));

            // Register the client provider as a singleton
            services.AddSingleton(typeof(ElasticClientProvider));

            services.AddSingleton(MongoClientProvider =>
            {
                return new MongoClientProvider(Configuration.GetConnectionString("MongoDB"));
            });

            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddSingleton<IElasticRepository, ElasticRepository>();
            services.AddTransient(typeof(SearchService));
            services.AddSingleton(typeof(RedisClientProvider));
            services.AddScoped<ICoversRepository, CoversRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader());
            });
			
			services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/clientapp/dist";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
			.AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            //call redis middleware to log number of requests
            app.UseMiddleware<RedisMiddleware>();
            app.UseCors("AllowAll");
            app.UseMvc();
			
			app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
