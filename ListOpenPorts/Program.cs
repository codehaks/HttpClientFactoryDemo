using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ListOpenPorts
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections;

            var logFile = @"d:\tcp_wait.txt";

            //var googleAddress = new IPAddress(new byte[] { 185.116.160.100 }); //172.217.18.142

            var index = 1;
            using var file = new System.IO.StreamWriter(logFile, true);

            while (true)
            {
                connections = ipGlobalProperties
                    .GetActiveTcpConnections()
                    .Where(c=>c.RemoteEndPoint.Port==443)
                    .Where(c => c.RemoteEndPoint.Address.ToString() == "185.116.160.100")
                    .ToArray();
                foreach (var item in connections.Where(c => c.State == TcpState.TimeWait))
                {
                    Console.WriteLine($"Local Port : {item.LocalEndPoint.Port} ->  {item.RemoteEndPoint.Address.ToString()} | state : {item.State}");
                }
                var count = connections.Where(c => c.State == TcpState.TimeWait).Count();
                Console.WriteLine($"{index} - TCP Time_Wait Count : {count}");
                await Task.Delay(1000);

                index++;

                file.WriteLine(count.ToString());
            }


        }
    }
}
