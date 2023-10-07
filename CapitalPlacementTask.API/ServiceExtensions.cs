using CapitalPlacementTask.Application.Interfaces;
using CapitalPlacementTask.Infrastructure.Implementation;
using CapitalPlacementTask.Infrastructure.Implementations;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacementTask.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureCosmosDb(this IServiceCollection services, IConfiguration configuration)
        {
            // Add CosmosClient and configure logging
            services.AddSingleton((provider) =>
            {
                var endpointUri = configuration["CosmosDbSettings:EndpointUri"];
                var primaryKey = configuration["CosmosDbSettings:PrimaryKey"];
                var databaseName = configuration["CosmosDbSettings:DatabaseName"];

                var cosmosClientOptions = new CosmosClientOptions
                {
                    ApplicationName = databaseName,
                    ConnectionMode = ConnectionMode.Gateway,
                };

                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                });

                var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);


                return cosmosClient;
            });
        }

        public static void AddServices(this IServiceCollection services, IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            services.AddScoped<IProgramDetailService, ProgramDetailService>();  
            services.AddScoped<IApplicationFormService, ApplicationFormService>();  
            services.AddScoped<IWorkFlowService, WorkFlowService>();  
            services.AddScoped<IPreviewService, PreviewService>();  
        }
    }
}
