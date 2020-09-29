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

    internal static class SteamEncryptedAppTicketWrapper
    {
        
        // import the c++ wrapper
        [DllImport("C:/Users/Vinnie/source/repos/online-services/services/cpp/SteamEncryptedAppTicketWrapper/Debug/SteamEncryptedAppTicketWrapper.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "decrypt_ticket")]
        internal static extern System.UInt64 decrypt_ticket([In, Out] System.Byte[] p_ticket, System.UInt32 ticket_size_in_bytes, System.UInt32 app_id, System.Byte[] rgubKey);

    };


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Steam DLL");

            string steamEncryptedAppTicket = "080110A6FCC3BA0C180820422A703A7DECDB42980394131B687000041B3F94D708E0034F8B166A164C25E73A926DA2EB19D021ECCE464F12D77568087B4651612961556D82F98559023E59E1ED44F661B20BB86C57B9DA38AF9C2393C2526AAA5171C2A26439377F8DB1F406469E394A8DBFD3EEE52686DAF4B37E1BCD38";
            Console.WriteLine("steamEncryptedAppTicket.Length = " + steamEncryptedAppTicket.Length);
            byte[] p_ticket = new byte[126];

            int j = 0;
            for (int i = 0; i < steamEncryptedAppTicket.Length; i += 2)
            {
                string hex_byte = steamEncryptedAppTicket.Substring(i, 2);
                byte value = Convert.ToByte(hex_byte, 16);
                p_ticket[j] = value;
                j++;
            }


            //make k8s secret
            System.Byte[] rgubKey = new System.Byte[]
                     {
					//	Battle
;
                    };

            System.UInt32 app_id = 1355520;
            //System.Byte[] p_ticket = new System.Byte[] {  0x08,0x01,0x10,0xfb,0xdf,0x8e,0x83,0x0a,
            //                0x18,0x04,0x20,0x3e,0x2a,0x70,0x8d,0x6f,
            //                0xc8,0x48,0x30,0x38,0xd8,0xa5,0x9e,0xd9,
            //                0x23,0xec,0xcc,0x83,0x84,0xc7,0x79,0xc6,
            //                0xdf,0xf2,0x6a,0x1e,0xfa,0xe5,0x1f,0x9b,
            //                0xc2,0xb4,0xd5,0x10,0x44,0x47,0xc0,0x7f,
            //                0x0e,0x66,0x8f,0x3e,0x22,0x23,0x20,0x90,
            //                0xf5,0xa9,0xed,0xab,0xdd,0x40,0x90,0xfd,
            //                0x76,0x77,0x35,0x69,0x13,0x10,0xd3,0xbc,
            //                0x7a,0xd2,0x11,0xe1,0x24,0x62,0x53,0x4c,
            //                0x84,0x74,0xd3,0x71,0x10,0xa0,0xe5,0x89,
            //                0x38,0x58,0x57,0x35,0xfb,0x50,0x74,0x50,
            //                0xb2,0xe7,0xdf,0xe3,0x44,0x3b,0xe9,0x06,
            //                0xa1,0x09,0xcc,0xd7,0x31,0x6d,0xe7,0x7e,
            //                0x66,0xdf,0x6b,0xb0,0x61,0x7b,0x75,0x60,
            //                0x21,0x32,0xd7,0x32,0xe8,0x6e};
            System.UInt32 ticket_size_in_bytes = (System.UInt32)p_ticket.Length;


            System.UInt64 result = SteamEncryptedAppTicketWrapper.decrypt_ticket(p_ticket, ticket_size_in_bytes, app_id, rgubKey);
            Console.WriteLine("result = " + result.ToString());

            Console.WriteLine("p_ticket[0] = " + p_ticket[0].ToString());
            while (true) {; }
        }
    }
}
