using System;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Improbable.OnlineServices.Proto.Auth.Steam;
using Grpc.Core;
using Improbable.OnlineServices.Common.Analytics;
using Serilog;
using Improbable.SpatialOS.PlayerAuth.V2Alpha1;



/*
 * sdkencryptedappticket64.dll
 * and
 * steam_api64.dll
 * must be in same folder as executeable (SteamAuth.dll)
 * 
 */

// server side implementation of the SteamAuth service

namespace SteamAuth
{
    public class SteamEncryptedAppTicketWrapper
    {



        // import the c++ wrapper
        [DllImport("C:/Users/Vinnie/source/repos/online-services/services/cpp/SteamEncryptedAppTicketWrapper/Debug/SteamEncryptedAppTicketWrapper.dll", EntryPoint = "decrypt_ticket")]
        public static extern Int64 decrypt_ticket();

    };

    public class SteamAuthImpl : AuthService.AuthServiceBase
    {

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        private readonly string _project;
        private readonly PlayerAuthServiceClient _authServiceClient;
        private readonly AnalyticsSenderClassWrapper _analytics;

        // This service is instantiated by Program.cs (base server)
        public SteamAuthImpl(string project, PlayerAuthServiceClient authServiceClient, IAnalyticsSender analytics = null)
        {
            _authServiceClient = authServiceClient;
            _analytics = (analytics ?? new NullAnalyticsSender()).WithEventClass("authentication");
        }

        public override Task<ExchangeSteamTokenResponse> ExchangeSteamToken(ExchangeSteamTokenRequest request,
            ServerCallContext context)
        {

            try
            {
                //validate SteamEncryptedAppTicket with SteamEncryptedAppTicketWrapper
                Console.WriteLine("make sure sdkencryptedappticket64.dll and steam_api64.dll are in same folder as SteamAuth.dll");

                
                string steamEncryptedAppTicket = request.SteamToken;


                Int64 result = SteamEncryptedAppTicketWrapper.decrypt_ticket();
                Console.WriteLine(result.ToString());

            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to authenticate SteamEncryptedAppTicket ticket");
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Failed to authenticate SteamEncryptedAppTicket ticket"));
            }

            /*
                some player table mapping
                SteamID | UUID
                var uniquePlayerId = new GetUniquePlayerIdentifierRequest....talk to redis
            */
            var uniquePlayerId = RandomString(15);

            try
            {

                //why use async?
                var playerIdentityToken = _authServiceClient.CreatePlayerIdentityToken(
                    new CreatePlayerIdentityTokenRequest
                    {
                        PlayerIdentifier = uniquePlayerId,
                        Provider = "steam",
                        ProjectName = _project
                    }
                );

                return Task.FromResult(new ExchangeSteamTokenResponse
                { PlayerIdentityToken = playerIdentityToken.PlayerIdentityToken });
            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to create player identity token for {uniquePlayerId}");
                throw new RpcException(new Status(StatusCode.Internal,
                    $"Failed to create player identity token for {uniquePlayerId}"));
            }
        }
    }
}




