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
            //var w = Wallet.FromWif("L1AV6yxwRV4xRXnM9CGdLnmjjrCtBXNHaDiscZSnLtoyHUwwHhHM");
            //var addr = w.PrivateKeyWifCompressed;

            var f = Generation.GenerateUpperWif();

            string key = null;
            while (key == null)
            {
                Parallel.For(0, long.MaxValue, (i, p) =>
                {
                    key = Generation.GenerateUpperWif();
                    p.Stop();
                });
            }
            Console.WriteLine("success: " + key);
            Console.ReadLine();
        }
    }
}
