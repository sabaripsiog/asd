using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;


namespace Lastsampleclient
{
    class Client
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("192.168.153.57");
            int port = 5000;

            TcpClient client = new TcpClient();
            client.Connect(ip, port);
            
            NetworkStream ns = client.GetStream();
            Thread thread = new Thread(o => ReceiveData((TcpClient)o));
            thread.Start(client);
            //Thread thread1 = new Thread(o => Conversation.clientnames((TcpClient)o));

            Console.WriteLine("client connected!!");
            //thread1.Start(client);
            
            string s;
            string name;
            
            //string sender;
            Console.WriteLine("Enter the user name:");
            name = Console.ReadLine();
            while (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty! Input name once more");
                name = Console.ReadLine();
            }

            byte[] nameByte = Encoding.ASCII.GetBytes(name);
            byte[] nameBuffer = new byte[nameByte.Length];
            nameByte.CopyTo(nameBuffer, 0);
            client.Client.Send(nameBuffer);
            Array.Clear(nameBuffer, 0, nameBuffer.Length);

            

            while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            {

                if (s.Contains(".pdf") || s.Contains(".wav") || s.Contains(".docx") || s.Contains(".mp3") || s.Contains(".mp4") || s.Contains(".jpg") || s.Contains(".txt") || s.Contains(".png") || s.Contains(".html") || s.Contains(".js") || s.Contains(".css") || s.Contains(".xml") || s.Contains(".json"))
                {
                    Conversation.callfilecode(client, name, s);
                }

                else if (s == "voicechat")
                {
                    Conversation.callvoicechat(client, name, s);
                }

                else
                {
                    Conversation.callmessagecode(client, name, ns, s);
                }
            }
            client.Client.Shutdown(SocketShutdown.Send);
            ns.Close();
            client.Close();
            Console.WriteLine("disconnect from server!!");
            Console.ReadKey();
        }


       



        public class Conversation
        {
            public static void callfilecode(TcpClient client, string name, string s)
            {
                //string sender;
                string filePath = @"C:/Users/Sabarish.a/Desktop/";
                string message = "file";
                byte[] messageByte = Encoding.ASCII.GetBytes(message);
                byte[] messageBuffer = new byte[messageByte.Length];
                messageByte.CopyTo(messageBuffer, 0);
                client.Client.Send(messageBuffer);
                Array.Clear(messageBuffer, 0, messageBuffer.Length);
                byte[] fileNameByte = Encoding.ASCII.GetBytes(s);
                byte[] fileData = File.ReadAllBytes(filePath + s);
                byte[] myData = new byte[4 + fileNameByte.Length + fileData.Length];
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                fileNameLen.CopyTo(myData, 0);
                fileNameByte.CopyTo(myData, 4);
                fileData.CopyTo(myData, 4 + fileNameByte.Length);
                client.Client.Send(myData);
                Array.Clear(fileData, 0, fileData.Length);
                Console.WriteLine(myData.Length);
                Console.WriteLine("File:{0} has been sent.", s);
            }

            public static void callmessagecode(TcpClient client, string name, NetworkStream ns, string s)
            {

                string message = "message";
                byte[] messageByte = Encoding.ASCII.GetBytes(message);
                byte[] messageBuffer = new byte[messageByte.Length];
                messageByte.CopyTo(messageBuffer, 0);
                client.Client.Send(messageBuffer);
                Array.Clear(messageBuffer, 0, messageBuffer.Length);
                byte[] buffer1 = Encoding.ASCII.GetBytes(name + ":");
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                byte[] buffer2 = new byte[4 + buffer1.Length + buffer.Length];
                buffer1.CopyTo(buffer2, 0);
                buffer.CopyTo(buffer2, buffer1.Length);
                ns.Write(buffer2, 0, buffer2.Length);
                Array.Clear(buffer, 0, buffer.Length);
                ns.Flush();
            }

            public static void callvoicechat(TcpClient client, string name, string s)
            {
                mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
                mciSendString("record recsound", "", 0, 0);
                Console.WriteLine("recording, press Enter to stop and save ...");
                Console.ReadLine();
                mciSendString("save recsound C:\\Users\\Sabarish.a\\Desktop\\result.wav", "", 0, 0);
                mciSendString("close recsound ", "", 0, 0);
                //string sender;
                string filePath = @"C:/Users/Sabarish.a/Desktop//";
                string message = "file";
                byte[] messageByte = Encoding.ASCII.GetBytes(message);
                byte[] messageBuffer = new byte[messageByte.Length];
                messageByte.CopyTo(messageBuffer, 0);
                client.Client.Send(messageBuffer);
                Array.Clear(messageBuffer, 0, messageBuffer.Length);
                //int count = 1;
                
                //count++;
                byte[] fileNameByte = Encoding.ASCII.GetBytes("result.wav");
                byte[] fileData = File.ReadAllBytes(filePath + "result.wav");
                byte[] myData = new byte[4 + fileNameByte.Length + fileData.Length];
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                fileNameLen.CopyTo(myData, 0);
                fileNameByte.CopyTo(myData, 4);
                fileData.CopyTo(myData, 4 + fileNameByte.Length);
                client.Client.Send(myData);
                Array.Clear(fileData, 0, fileData.Length);
                Console.WriteLine(myData.Length);
                Console.WriteLine("Audio has been recorded");
                Console.WriteLine("File:{0} has been sent.", "result.wav");


            }
            public static void clientnames(TcpClient client)
            {
               
                while (true)
                {
                   
                    NetworkStream ns = client.GetStream();
                    byte[] receivedBytes = new byte[1024];
                    //byte[] receivedbytes1 = new byte[1024 * 5000];
                    int byte_count;
                    if ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                    {
       
                        Console.WriteLine(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
                    }
                    Array.Clear(receivedBytes,0,receivedBytes.Length);
                }
            }
        }

        static void ReceiveData(TcpClient client)
        {
            

            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int byte_count1 = client.Client.Receive(buffer);
                    string messagedata = Encoding.ASCII.GetString(buffer, 0, byte_count1);
                    //Console.WriteLine(messagedata);

                    if (messagedata == "message")
                    {
                        Array.Clear(buffer, 0, buffer.Length);
                        NetworkStream ns = client.GetStream();
                        byte[] receivedBytes = new byte[1024];
                        //byte[] receivedbytes1 = new byte[1024 * 5000];
                        int byte_count;
                        if ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                        {
                            Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
                        }
                        ns.Flush();
                    }

                    else if (messagedata == "file")
                    {
                        Array.Clear(buffer, 0, buffer.Length);
                        byte[] receivedBytes = new byte[1024 * 5000];
                        string receivedPath = @"C:/Users/Sabarish.a/Desktop/New/";
                        int receivedBytesLen = client.Client.Receive(receivedBytes);
                        int fileNameLen = BitConverter.ToInt32(receivedBytes, 0);
                        string fileName = Encoding.ASCII.GetString(receivedBytes, 4, fileNameLen);
                        Console.WriteLine("Client:{0} connected & File {1} sharing started.", client.Client.RemoteEndPoint, fileName);
                        //var charfile = System.Text.Encoding.UTF8.GetString(receivedBytes).ToCharArray();
                        BinaryWriter bwrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Append));
                        bwrite.Write(receivedBytes, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
                        Console.WriteLine("File: {0} received & saved at path: {1}", fileName, receivedPath);
                        bwrite.Close();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }

    }

}