using System.Text.Json;
using BudgetApp.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Photino.Blazor;

namespace BudgetApp;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var builder = PhotinoBlazorAppBuilder.CreateDefault(args);
        
        builder.Services.AddMudServices();

        var config = new ConfigurationBuilder().AddUserSecrets<Program>().AddJsonFile("appsettings.json").Build();
        var cosmosClient = new CosmosClient(
            config.GetValue<string>("CosmosEndpoint"), 
            config.GetValue<string>("CosmosAuthKey"),
            new CosmosClientOptions
            {
                UseSystemTextJsonSerializerWithOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            });
        builder.Services.AddSingleton(new BudgetsService(cosmosClient));

        builder.RootComponents.Add<App>("#app");

        var app = builder.Build();

        app.MainWindow
            .SetSize(1400, 800)
            .SetDevToolsEnabled(true)
            .SetLogVerbosity(0)
            .SetIconFile("favicon.ico")
            .SetTitle("Our Two Cents");

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());

        app.Run();
    }
}