
using Day2.Models;
using Day2.Repository;
using Day2.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string txt = "";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(
                options=>options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
                );
            //builder.Services.AddControllers().AddNewtonsoftJson(s => s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                o=>
                {
                    o.SwaggerDoc("v1", new OpenApiInfo()
                    {
                        Title = "pd api",
                        Description = " api to manage iti data",
                        Version = "v1",
                        TermsOfService = new Uri("http://tempuri.org/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "itian",
                            Email = "aaaa@org.org",

                        },
                    });
                    o.IncludeXmlComments(".\\myfile.xml");
                    o.EnableAnnotations();
                }
                );

            builder.Services.AddDbContext<ITIContext>(o=>o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("iticon")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(txt,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            //builder.Services.AddScoped<GenericRepository<Student>>();
            //builder.Services.AddScoped<GenericRepository<Department>>();
            builder.Services.AddScoped<UnitOfWOrks>();

            builder.Services.AddAuthentication(option => option.DefaultAuthenticateScheme = "myscheme")
                .AddJwtBearer("myscheme",
                //validate token
                op =>
                {
                    #region secret key
                    string key = "welcome to my secret key iti Alex";
                    var secertkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                    #endregion
                    op.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = secertkey,
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                    
                }



                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                //app.MapSwagger().RequireAuthorization();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(txt);

            app.MapControllers();

            app.Run();
        }
    }
}
