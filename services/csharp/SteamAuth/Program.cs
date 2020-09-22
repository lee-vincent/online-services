using System;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using Improbable.OnlineServices.Base.Server; // the gRPC base server
using Improbable.OnlineServices.Common;
using Improbable.OnlineServices.Common.Analytics;
using Improbable.OnlineServices.Common.Analytics.ExceptionHandlers;
using Improbable.OnlineServices.Proto.Auth.Steam;  // this is generated from the proto file i created for types of steam authentication messages
using Improbable.SpatialOS.Platform.Common;
using Improbable.SpatialOS.PlayerAuth.V2Alpha1;
using Mono.Unix;
using Mono.Unix.Native;
using Serilog;
using Serilog.Formatting.Compact;

namespace SteamAuth
{
    public class SteamAuthArguments : CommandLineArgs, IAnalyticsCommandLineArgs
    {
        
        [Option("project_name", HelpText = "Project name", Required = true)]
        public string ProjectName { get; set; }

        [Option("STEAM_APP_ID", HelpText = "Steam App ID", Required = true)]
        public string STEAM_APP_ID { get; set; }


        public bool AllowInsecureEndpoints { get; set; }
        // dont need to enter any of these in command line because im not passing
        // an AnalyticsSender to SteamAuthImpl constructor
        public string Endpoint { get; set; }
        public string ConfigPath { get; set; }
        public string GcpKeyPath { get; set; }
        public string Environment { get; set; }
        public string EventSchema { get; set; }
    }

    class Program
    {
        private const string SteamSymmetricKeyEnvironmentVariable = "STEAM_SYMMETRIC_KEY";


        public static void Main(string[] args)
        {
            // See https://support.microsoft.com/en-gb/help/821268/contention-poor-performance-and-deadlocks-when-you-make-calls-to-web-s
            // Experimentation shows we need the ThreadPool to always spin up threads for good performance under load
            ThreadPool.GetMaxThreads(out var workerThreads, out var ioThreads);
            ThreadPool.SetMinThreads(workerThreads, ioThreads);

            Parser.Default.ParseArguments<SteamAuthArguments>(args)
                .WithParsed(parsedArgs =>
                {
                    Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console(new RenderedCompactJsonFormatter())
                        .Enrich.FromLogContext()
                        .CreateLogger();

                    var steamDeveloperKey = Secrets.GetEnvSecret(SteamSymmetricKeyEnvironmentVariable).Trim();
                  

                    var server = GrpcBaseServer.Build(parsedArgs);
                    server.AddService(AuthService.BindService(
                        new SteamAuthImpl(
                            parsedArgs.ProjectName,
                            PlayerAuthServiceClient.Create(
                            // TODO: this is an example i need to change this later
                            // PlatformApiEndpoint uses google.api.gax which is GCP native so i need to change this
                            new PlatformApiEndpoint("steamauth.api.com", 443, true))
                            /*endpoint: new PlatformApiEndpoint("playerauth.api.improbable.io", 443),*/
                            //credentials: new PlatformRefreshTokenCredential(spatialRefreshToken)),
                            //analyticsSender
                            )
                    ));

                    var serverTask = Task.Run(() => server.Start());
                    var signalTask = Task.Run(() => UnixSignal.WaitAny(new[] { new UnixSignal(Signum.SIGINT), new UnixSignal(Signum.SIGTERM) }));
                    Log.Information("Steam authentication server started up");
                    Task.WaitAny(serverTask, signalTask);

                    if (signalTask.IsCompleted)
                    {
                        Log.Information($"Received UNIX signal {signalTask.Result}");
                        Log.Information("Server shutting down...");
                        server.Shutdown();
                        serverTask.Wait();
                        Log.Information("Server stopped cleanly");
                    }
                    else
                    {
                        /* The server task has completed; we can just exit. */
                        Log.Information("The PlayFab authentication server has stopped itself or encountered an unhandled exception.");
                    }

                    Environment.Exit(0);
                });
        }
    }
}
