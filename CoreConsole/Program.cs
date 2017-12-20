using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BitcoinTools;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var upperCaseKey = Generation.GenerateWif();
            var wallet = Wallet.FromWif(upperCaseKey);
            Console.WriteLine(wallet);
            Console.ReadLine();
            // 5JVR9JXJCTP4RP2PH287JYJ1AQEVS5NML1LX5MF3ECQUYUDZMRL
        }
    }
}
