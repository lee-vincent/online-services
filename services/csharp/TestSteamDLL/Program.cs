using System;
using System.Runtime.InteropServices;
using System.Threading;


/*
 * sdkencryptedappticket64.dll
 * and
 * steam_api64.dll
 * must be in same folder as executeable (TestSteamDLL.dll)
 * 
 */

namespace TestSteamDLL
{

    public class SteamEncryptedAppTicketWrapper
    {
        
        // import the c++ wrapper
        [DllImport("C:/Users/Vinnie/source/repos/online-services/services/cpp/SteamEncryptedAppTicketWrapper/Debug/SteamEncryptedAppTicketWrapper.dll", EntryPoint = "decrypt_ticket")]
        public static extern Int64 decrypt_ticket();

    };


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Steam DLL");
            Int64 result = SteamEncryptedAppTicketWrapper.decrypt_ticket();
            Console.WriteLine(result.ToString());
            Thread.Sleep(2000);
        }
    }
}
