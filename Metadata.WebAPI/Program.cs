using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using MetaData.WebAPI.GraphQL;
using MetaData.WebAPI.Models;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Filters;

namespace MetaData.WebAPI
{
  [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region GraphQL
            builder.Services
              .AddGraphQLServer()
              .AddQueryType<RootQuery>();
            #endregion
            builder.Configuration.AddJsonFile("appsettings.json", true, true);
            builder.Configuration.AddEnvironmentVariables();
         

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            })
            //added to use EnumMember in response for Permissions Enum(Refer Read me)
            .AddNewtonsoftJson(
                opt =>
                {
                    opt.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
            ;

            builder.Services.Configure<AppSettingsOptions>(builder.Configuration.GetSection("AppSettings"));
            #region Swashbuckle setup
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Metadata Service",
                    Version = "v1"
                });
                c.ExampleFilters();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme(Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        Array.Empty<string>()
                    }
                });
            });
            builder.Services.AddSwaggerExamples();
            #endregion

            //builder.Services.AddDefaultFactories();
            builder.Services.AddHttpContextAccessor();
            builder.Services.ConfigureInternalService(builder.Configuration);
            builder.Services.AddHttpClient();
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
            });
            app.MapGraphQL("/api/metadata");
            app.Run();
        }
    }
}
