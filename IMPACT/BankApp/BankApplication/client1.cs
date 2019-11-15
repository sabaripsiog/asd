using System.Net.Sockets;
using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BankApplication
{
    class client1
    {
        private static TcpClient client = new TcpClient();
        private static StreamReader reader;
        private static StreamWriter writer;
        private static bool refresh;
        private static List<string> messages = new List<string>();
        public static int UserOption;
        public static string GetOption;
        public static bool Confirm = false;
        public static Task sendTask;
        public static Task recieveTask;
        public static Task updateConvTask;

        public static void Main()
        {
            Console.Title = "Client";
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            do //try to connect
            {
                Console.WriteLine("Connecting to server...");

                try
                {
                    client.Connect(IPAddress.Parse("127.0.0.1"), 8080);
                }
                catch (SocketException)
                {
                }
               
                Thread.Sleep(10);
            } while (!client.Connected);

            // \/ CONNECTED \/

            Console.WriteLine("Connected.");
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
            //Running task for cancellation
            sendTask = Task.Run(() => SendMessage(tokenSource, client));      //task for sending messages
            recieveTask = Task.Run(() => RecieveMessage(token), token);       //task for recieving messages
            updateConvTask = Task.Run(() => UpdateConversation(token), token);   //task for update console window
            Task.WaitAll(sendTask, recieveTask); //wait for end of all tasks
        }



        private static void SendMessage(CancellationTokenSource tokenSource, TcpClient client)
        {
            while (true)
            {
                string msgToSend = string.Empty;
                msgToSend = Console.ReadLine();
                switch (msgToSend)
                {
                    case "E":
                        EndConnection();
                        break;
                    case "M":
                        tokenSource.Cancel();
                        writer.WriteLine("M");
                        writer.Flush();
                        Menu(client);
                        break;
                    case "hi":
                        writer.WriteLine(msgToSend);
                        writer.Flush();
                        break;
                    default:
                        writer.WriteLine(msgToSend);
                        writer.Flush();
                        break;
                }
            }
        }

        private static void Menu(TcpClient client)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            do
            {
                Console.WriteLine("Please choose a particular scheme");
                Console.WriteLine();
                Console.WriteLine("1. Loan ");
                Console.WriteLine("2. Credit card ");
                Console.WriteLine("3. Provident fund ");
                Console.WriteLine();

                GetOption = Console.ReadLine();

                while (!int.TryParse(GetOption, out UserOption))
                {
                    Console.WriteLine("This is not a number!");
                    GetOption = Console.ReadLine();
                }

               // writer.WriteLine(UserOption);
                writer.Flush();
                if ((UserOption > 0) && (UserOption < 4))
                {
                    Confirm = false;
                    
                    switch (UserOption)
                    {
                        case 1:
                            //Console.Clear();
                            Console.WriteLine("You opted for Loan");
                            writer.WriteLine(UserOption);
                            recieveTask = Task.Run(() => RecieveMessage(token), token);
                            updateConvTask = Task.Run(() => UpdateConversation(token), token);
                            writer.Flush();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("You pressed 2");
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("You pressed 3");
                            break;

                        default:
                            Console.WriteLine("No match found");
                            break;
                    }
                  

                    Task.WaitAll(updateConvTask, recieveTask);
                }
                else
                {
                    Confirm = true;
                    Console.Clear();
                    Console.WriteLine("Re-enter the options");
                }

            } while (Confirm == true);
        }
        private static void RecieveMessage(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Task was cancelled before it got started.");
                token.ThrowIfCancellationRequested();
            }

            // recieveTask = Task.Run(() => RecieveMessage());

            try
            {
                while (client.Connected)
                {
                    //Console.Clear();
                    string msg = reader.ReadLine();
                    if (msg != string.Empty)
                    {
                        if (msg == "%C") //special message from server, clear messages if recieve it
                        {
                            messages.Clear();
                        }
                        else
                        {
                            messages.Add(msg);
                            refresh = true; //refresh console window
                        }
                    }
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task was cancelled.");
                        token.ThrowIfCancellationRequested();
                    }

                    //if(msg==Console.ReadLine())
                    // {

                    //     var sendTask = Task.Run(() => SendMessage());

                    // }
                    //Console.Clear();
                    //Console.WriteLine(msgFromServer);
                }
            }
            catch (OperationCanceledException)
            {
                //Console.WriteLine($"\n{nameof(OperationCanceledException)} thrown\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
         
        }
        private static void UpdateConversation(CancellationToken token)
        {
            //string conversationTmp = string.Empty;
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Task was cancelled before it got started.");
                token.ThrowIfCancellationRequested();
            }
            try
            {
                while (true)
                {
                    if (refresh) //only if refresh
                    {
                        refresh = false;
                        Console.Clear();
                        messages.ForEach(msg => Console.WriteLine(msg)); //write all messages
                        Console.WriteLine();
                    }
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task was cancelled.");
                        token.ThrowIfCancellationRequested();
                    }
                }
            }
            catch (Exception) { }
          

        }
        private static void EndConnection()
        {
            reader.Close();
            writer.Close();
            client.Close();
        }



    }
}