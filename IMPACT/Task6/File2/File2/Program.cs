using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Chat1Svr
{
    class Program
    {
        static readonly object _lock = new object();
        static readonly Dictionary<int, TcpClient> list_clients = new Dictionary<int, TcpClient>();

        static void Main(string[] args)
        {
            int count = 1;

            TcpListener ServerSocket = new TcpListener(IPAddress.Any, 5000);
            ServerSocket.Start();


            while (true)
            {
                TcpClient client = ServerSocket.AcceptTcpClient();
                lock (_lock) list_clients.Add(count, client);
                Console.WriteLine($"Client {count} connected!!");

                Thread t = new Thread(handle_clients);
                t.Start(count);

                Console.WriteLine($"Number of clients connected {count}");
                count++;
            }
        }
        public static void handle_clients(object o)
        {
            int id = (int)o;
            TcpClient client;


            lock (_lock) client = list_clients[id];


            while (true)
            {
                try
                {
                      
                        
                        byte[] clientData = new byte[1024*5000];

                        int receivedBytesLen = client.Client.Receive(clientData);
                        Console.WriteLine(receivedBytesLen);
                        if (receivedBytesLen == 0)
                        {
                            break;
                        }
                        foreach (TcpClient c in list_clients.Values)
                        {
                            c.Client.Send(clientData);
                        }
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine("File Sending fail." + ex.Message);
                }
            }

            lock (_lock) list_clients.Remove(id);
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}


