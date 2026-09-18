using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UdpEchoClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string serverIp = 127.0.0.1;
            int port = 54000;

            UdpClient client = new UdpClient();
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(serverIp), port);

            Console.WriteLine($UDP echo client.Server { serverIp}
            { port}
            n);

            int counter = 1;
            while (true)
            {
                string message = $Hello UDP #{counter} at {DateTime.NowHHmmss};
                byte[] data = Encoding.UTF8.GetBytes(message);

                client.Send(data, data.Length, serverEP);
                Console.WriteLine($[{ DateTime.NowHHmmss}] Sent { message});

                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] received = client.Receive(ref remoteEP);
                string response = Encoding.UTF8.GetString(received);

                Console.WriteLine($[{ DateTime.NowHHmmss}] Received { response}
                n);

                counter++;
                Thread.Sleep(1000);
            }
        }
    }
}