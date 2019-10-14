using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;




namespace Lastsampleserver
{
    class Server
    {



        static readonly object _lock = new object();
        static readonly Dictionary<string, TcpClient> list_clients = new Dictionary<string, TcpClient>();
         


        static void Main(string[] args)
        {
            Console.Title = "Server";
            int count = 1;
            TcpListener ServerSocket = new TcpListener(IPAddress.Any, 5000);
            ServerSocket.Start();
            Console.WriteLine("Welcome to Chat room!!");
            Console.WriteLine("How many clients are going to connect to this server?:");
            int numberOfClients = int.Parse(Console.ReadLine());
            
            for(count = 1; count <=numberOfClients; count++)
            {
                TcpClient client = ServerSocket.AcceptTcpClient();

                byte[] namebuffer = new byte[1024];
                int name_byte_count = client.Client.Receive(namebuffer);
                string client_name = Encoding.ASCII.GetString(namebuffer, 0, name_byte_count);
                lock (_lock) list_clients.Add(client_name, client);
                
                Console.WriteLine($"Client {client_name} connected!!");
              
                Thread t = new Thread(handle_clients);
                t.Start(client_name);
               
                Console.WriteLine($"Number of clients connected {count}");
            }
           
        }

        public static void display_clients()
        {
            foreach (TcpClient c in list_clients.Values)
            {
                
                NetworkStream stream = c.GetStream();
                foreach (string name in list_clients.Keys)
                {
                    byte[] displayByte = Encoding.ASCII.GetBytes(name);
                    byte[] displayBuffer = new byte[displayByte.Length];
                    displayByte.CopyTo(displayBuffer, 0);
                    stream.Write(displayBuffer, 0, displayBuffer.Length);
                    Array.Clear(displayBuffer, 0, displayBuffer.Length);
                }
            }
        }

        public static void handle_clients(object o)
        {
            // display_clients();
            string id = (string)o;
            TcpClient client;
            lock (_lock) client = list_clients[id];



            try
            {
                while (true)
                {



                    byte[] buffer = new byte[1024];
                    int byte_count = client.Client.Receive(buffer);
                    string messagedata = Encoding.ASCII.GetString(buffer, 0, byte_count);
                    // Console.WriteLine(messagedata);



                    if (messagedata == "message")
                    {
                        Array.Clear(buffer, 0, buffer.Length);
                        NetworkStream stream = client.GetStream();
                        byte[] buffernew = new byte[1024];
                        int byte_count_new = stream.Read(buffernew, 0, buffernew.Length);
                        if (byte_count_new == 0)
                        {
                            break;
                        }

                        bool isvalue = false;
                        string myKey;
                        myKey = list_clients.FirstOrDefault(x => x.Value == client).Key;
                        string data = Encoding.ASCII.GetString(buffernew, 0, byte_count_new);

                        
                        
                            foreach (KeyValuePair<string, TcpClient> entry in list_clients)
                            {

                                if (data.Contains(entry.Key + "/"))
                                {
                                    string[] split_data = data.Split('/');
                                    isvalue = true;
                                    string newstring = myKey + ":" + split_data[1];
                                    byte[] buffer1 = Encoding.ASCII.GetBytes(newstring + Environment.NewLine);

                                    string edata = "message";
                                    byte[] messageByte = Encoding.ASCII.GetBytes(edata);
                                    byte[] messageBuffer = new byte[messageByte.Length];
                                    messageByte.CopyTo(messageBuffer, 0);
                                    entry.Value.Client.Send(messageBuffer);
                                    Array.Clear(messageBuffer, 0, messageBuffer.Length);
                                    NetworkStream stream1 = entry.Value.GetStream();
                                    stream1.Write(buffer1, 0, buffer1.Length);
                                    stream1.Flush();
                                    
                                }
                       
                            }

                        if (isvalue == true)
                        {
                            
                            Console.WriteLine($"{myKey} sent a private message.");
                            continue;
                        }
                        else
                        {
                            
                            broadcast(data);
                            myKey = list_clients.FirstOrDefault(x => x.Value == client).Key;
                            Console.WriteLine($"{myKey} sent a message.");
                        }


                        
                        Array.Clear(buffernew, 0, buffernew.Length);
                        stream.Flush();
                    }



                    else if (messagedata == "file" || messagedata == "voice")
                    {
                        string myKey;
                        myKey = list_clients.FirstOrDefault(x => x.Value == client).Key;
                        Array.Clear(buffer, 0, buffer.Length);
                        if (messagedata == "file")
                        {
                            Console.WriteLine($"{myKey} sent a file.");
                        }
                        else
                        {
                            Console.WriteLine($"{myKey} sent a voice note.");
                        }
                        byte[] clientData = new byte[1024 * 5000];
                        int receivedBytesLen = client.Client.Receive(clientData);
                       
                        if (receivedBytesLen == 0)
                        {
                            break;
                        }



                        foreach (TcpClient c in list_clients.Values)
                        {
                            //stream.Write(clientData, 0, clientData.Length);
                            messagedata = "file";
                            byte[] messageByte = Encoding.ASCII.GetBytes(messagedata);
                            byte[] messageBuffer = new byte[messageByte.Length];
                            messageByte.CopyTo(messageBuffer, 0);
                            c.Client.Send(messageBuffer);
                            Array.Clear(messageBuffer, 0, messageBuffer.Length);
                            c.Client.Send(clientData);



                        }



                    }

                    else if (messagedata == "privatefile" || messagedata =="privatevoice")
                    {
                        string myKey;
                        myKey = list_clients.FirstOrDefault(x => x.Value == client).Key;
                        if (messagedata == "privatefile")
                        {
                            Console.WriteLine($"{myKey} sent a file privately.");
                        }
                        else
                        {
                            Console.WriteLine($"{myKey} sent a private voice note.");
                        }
                        Array.Clear(buffer, 0, buffer.Length);

                        byte[] splitbuffer = new byte[1024 * 5000];
                        int Len = client.Client.Receive(splitbuffer);
                        string client_name = Encoding.ASCII.GetString(splitbuffer, 0, Len);
                       


                       


                        foreach (KeyValuePair<string, TcpClient> entry in list_clients)
                        {

                            if (entry.Key == client_name)
                            {

                                byte[] clientData = new byte[1024 * 5000];
                                int receivedBytesLen = client.Client.Receive(clientData);

                                if (receivedBytesLen == 0)
                                {
                                    break;
                                }
                                //stream.Write(clientData, 0, clientData.Length);
                                messagedata = "file";
                                byte[] messageByte = Encoding.ASCII.GetBytes(messagedata);
                                byte[] messageBuffer = new byte[messageByte.Length];
                                messageByte.CopyTo(messageBuffer, 0);
                                entry.Value.Client.Send(messageBuffer);
                                Array.Clear(messageBuffer, 0, messageBuffer.Length);
                                entry.Value.Client.Send(clientData);
                            }

                        }
                        


                    }
                    /*
                    else if(messagedata == "all")
                    {
                     
                        foreach (KeyValuePair<string, TcpClient> entry in list_clients)
                        {

                            if (entry.Value == client)
                            {
                               
                                byte[] messageByte = Encoding.ASCII.GetBytes(messagedata);
                                byte[] messageBuffer = new byte[messageByte.Length];
                                messageByte.CopyTo(messageBuffer, 0);
                                client.Client.Send(messageBuffer);
                                NetworkStream stream = client.GetStream();
                                foreach (string name in list_clients.Keys)
                                {
                                    byte[] displayByte = Encoding.ASCII.GetBytes(name);
                                    byte[] displayBuffer = new byte[displayByte.Length];
                                    displayByte.CopyTo(displayBuffer, 0);
                                    stream.Write(displayBuffer, 0, displayBuffer.Length);
                                    Array.Clear(displayBuffer, 0, displayBuffer.Length);
                                }

                            }

                        }
                        
                    }

    */

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            lock (_lock) list_clients.Remove(id);
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();
        }


    

        public static void broadcast(string data)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);



            foreach (TcpClient c in list_clients.Values)
            {
                string messagedata = "message";
                byte[] messageByte = Encoding.ASCII.GetBytes(messagedata);
                byte[] messageBuffer = new byte[messageByte.Length];
                messageByte.CopyTo(messageBuffer, 0);
                c.Client.Send(messageBuffer);
                Array.Clear(messageBuffer, 0, messageBuffer.Length);
            }



            foreach (TcpClient c in list_clients.Values)
            {
                NetworkStream stream = c.GetStream();
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }




        }



    }
}