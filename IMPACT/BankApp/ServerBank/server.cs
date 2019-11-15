using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace BankApplication
{
    class server
    {
        private static List<Client> clients = new List<Client>();
        private static TcpListener listener = null;
        private static StreamReader reader = null;
        private static StreamWriter writer = null;
        private static List<Task> clientTasks = new List<Task>();
        //private static List<string> messages = new List<string>();
        private static List<string> loan = new List<string>();
        private static List<string> creditcard = new List<string>();
        private static List<string> providentfund = new List<string>();

        public static void Main()
        {
            loan.Add("Loan offer 12%");
            loan.Add("Loan offer 22%!!! avail soon");
            creditcard.Add("credit card offer!!!! 15% discount on abc bank account holders");
            creditcard.Add("credit card offer 70%");
            providentfund.Add("PF offer!!! for you");
            providentfund.Add("This is a pf offer");

            var messages = loan
            .Concat(creditcard)
            .Concat(providentfund)
            .ToList();
            Console.Title = "Server";
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                listener.Start();
                Console.WriteLine("Server started...");
                var connectTask = Task.Run(() => ConnectClients(messages));
                //var listenTask = Task.Run(() => ListenClients());
                Task.WaitAll(connectTask);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
        }

        private static void ConnectClients(List<string> messages)
        {
            Console.WriteLine("Waiting for incoming client connections...");
            while (true)
            {
                if (listener.Pending()) //if someone want to connect
                {
                    clients.Add(new Client(listener.AcceptTcpClient(), "Client: " + (clients.Count + 1)));
                    Console.WriteLine(clients[clients.Count - 1].clientName + " connected to server.");
                    var handle_client = Task.Run(() => HandleClient(clients[clients.Count - 1], messages)); //start new task for new client
                    var sendTask = Task.Run(() => SendScheme(clients[clients.Count - 1], messages));
                }
            }
        }


        private static void HandleClient(Client TCPClient, List<string> messages)
        {
            Client client = TCPClient;
            string option = string.Empty;
            string scheme = string.Empty;
            writer = new StreamWriter(TCPClient.client.GetStream());
            reader = new StreamReader(TCPClient.client.GetStream());
            Console.WriteLine("entered server");

            try
            {
                while (!(option = reader.ReadLine()).Equals("Exit") || (option == null))
                {
                    if (!TCPClient.client.Connected)
                    {
                        Console.WriteLine("Client disconnected.");
                        clients.Remove(TCPClient);
                    }

                   // messages.Add(TCPClient.clientName + ": " + s); //save new message
                                                                   //Console.WriteLine(s);
                    Console.WriteLine("From client: " + TCPClient.clientName + " opted for " + option);


                    if (option == "M")
                    {
                        Console.WriteLine("inside");
                        if ((scheme = reader.ReadLine()).Equals("1"))
                        {
                            Console.WriteLine(option);
                            var sendTask = Task.Run(() => SendScheme(clients[clients.Count - 1], loan));
                            client.writer.WriteLine("Welcome to loan scheme");
                            client.writer.Flush();
                        }
                            //while (true)
                            //{
                            //    foreach (string loanmsg in loan)
                            //    {
                            //        client.writer.WriteLine(loanmsg);
                            //        client.writer.Flush();
                            //        Thread.Sleep(5000);
                            //    }
                            //}
                        
                    }

                    /*foreach (Client c in clients) //refresh all connected clients
                    {
                        foreach (string msg in messages)
                        {
                            c.writer.WriteLine(msg);
                            c.writer.Flush();
                            Task.Delay(5000);
                        }
                    }*/
                }
                CloseServer();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

       
        private static void SendScheme(Client TCPClient, List<string> messages)
        {
            Client client = TCPClient;

            try
            {
                while (true)
                {
                    foreach (string msg in messages)
                    {
                        client.writer.WriteLine(msg);
                        client.writer.Flush();
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
          
        }


        private static void CloseServer()
        {
            reader.Close();
            writer.Close();
            clients.ForEach(tcpClient => tcpClient.client.Close());
        }
    }
    class Client
    {
        public TcpClient client;
        public StreamReader reader;//Read from client
        public StreamWriter writer; //write to client
        public string clientName;

        public Client(TcpClient client, string clientName)
        {
            this.client = client;
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
            this.clientName = clientName;
        }
    }
}