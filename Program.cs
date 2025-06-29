using System.Text.Json;
using BudgetApp.Services.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using Photino.Blazor;

namespace BudgetApp;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var builder = PhotinoBlazorAppBuilder.CreateDefault(args);
        
        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.VisibleStateDuration = 2000;
            config.SnackbarConfiguration.HideTransitionDuration = 200;
            config.SnackbarConfiguration.ShowTransitionDuration = 200;
            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.ShowCloseIcon = false;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            config.SnackbarConfiguration.MaximumOpacity = 255;
        });

        var config = new ConfigurationBuilder().AddUserSecrets<Program>().AddJsonFile("appsettings.json").Build();
        var cosmosClient = new CosmosClient(config["CosmosConnectionString"],
            new CosmosClientOptions
            {
                UseSystemTextJsonSerializerWithOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            });
        
        builder.Services.AddSingleton(new BudgetsRepository(cosmosClient, config));
        builder.Services.AddSingleton(new FixedBudgetRepository(cosmosClient, config));
        builder.Services.AddSingleton(new CategoriesRepository(cosmosClient, config));

        builder.RootComponents.Add<App>("#app");

        var app = builder.Build();

        app.MainWindow
            .SetMaximized(true)
            .SetDevToolsEnabled(true)
            .SetLogVerbosity(0)
            .SetIconFile("favicon.ico")
            .SetTitle("Our Two Cents");

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());

        app.Run();
    }
}