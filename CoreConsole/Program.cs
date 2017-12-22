using System;
using System.Collections;
using System.Linq;
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

            var id = wallet.GetHashCodeLong();
            var hash = wallet.GetHashCode();

            Console.WriteLine(wallet);
            Console.ReadLine();
        }


    }
}
