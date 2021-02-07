using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Text;
using WebApi.Domain.BLL;
using WebApi.Infra.Data.Data;
using WebApi.Infra.Entidade;
using WebApi.Infra.Entity.Contact;
using WebApi.Infra.Interface;
using WebApi.Model;
using WebApi.Repository.Data;
using WebApi.Uow;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "CorsPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200/")
                                                 .AllowAnyHeader()
                                                 .AllowAnyMethod();
                });
            });



            services.AddControllers();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            //services.AddEntityFrameworkNpgsql()
            // .AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DataBase")));

            services.AddEntityFrameworkInMemoryDatabase().AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Database"));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactModel,ContactEntity>().ReverseMap();
                cfg.CreateMap<AddressModel, AddressEntity>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            #region Context

            services.AddScoped<DataContext, DataContext>();

            #endregion

            #region Repository
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            #endregion

            #region BLL

            services.AddScoped<IContact, ContactBLL>();
            services.AddScoped<IAddress, AddressBLL>();
            #endregion

            #region Uow

            services.AddScoped<ContactUow>();

            #endregion

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
