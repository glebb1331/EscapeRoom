using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpEchoServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 54000;
            UdpClient server = new UdpClient(port);
            Console.WriteLine($"UDP echo server started on port {port}");
            Console.WriteLine("Waiting for packets...\n");

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] data = server.Receive(ref remoteEP);
                string message = Encoding.UTF8.GetString(data);

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Received from {remoteEP}: {message}");

                server.Send(data, data.Length, remoteEP);
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Echo sent back to {remoteEP}\n");
            }
        }
    }
}