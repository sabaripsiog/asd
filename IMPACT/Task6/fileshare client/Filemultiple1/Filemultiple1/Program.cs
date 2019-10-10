using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;



namespace Textclient
{
    class Client
    {
       // [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
       // private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);



        
        static void Main(string[] args)
        {



            IPAddress ip = IPAddress.Parse("192.168.153.57");
            int port = 5000;
            TcpClient client = new TcpClient();
            client.Connect(ip, port);
            Console.WriteLine("client connected!!");
            NetworkStream ns = client.GetStream();
            Thread thread = new Thread(o => ReceiveData((TcpClient)o));
            //Thread thread1 = new Thread(o => fileReceiveData((TcpClient)o));
            thread.Start(client);
            //thread1.Start(client);




            try
            {
                string s;
                string name;
                //string sender;
                string filePath = @"C:/Users/Sabarish.a/Desktop/";
                Console.WriteLine("Enter the username:");
                //Console.WriteLine("Enter the password:");



                name = Console.ReadLine();







                while (!string.IsNullOrEmpty((s = Console.ReadLine())))
                {




                    if (s.Contains(".pdf") || s.Contains(".wav") || s.Contains(".docx") || s.Contains(".mp3") || s.Contains(".mp4") || s.Contains(".jpg") || s.Contains(".txt") || s.Contains(".png") || s.Contains(".html") || s.Contains(".js") || s.Contains(".css") || s.Contains(".xml") || s.Contains(".json"))
                    {



                        callfilecode();
                    }
                    else
                    {



                        callmessagecode();
                    }



                }




                void callfilecode()
                {
                    string message = "file";
                    byte[] messageByte = Encoding.ASCII.GetBytes(message);
                    byte[] messageBuffer = new byte[messageByte.Length];
                    messageByte.CopyTo(messageBuffer, 0);
                    client.Client.Send(messageBuffer);



                    byte[] fileNameByte = Encoding.ASCII.GetBytes(s);





                    byte[] fileData = File.ReadAllBytes(filePath + s);
                    byte[] myData = new byte[4 + fileNameByte.Length + fileData.Length];
                    byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);





                    fileNameLen.CopyTo(myData, 0);
                    fileNameByte.CopyTo(myData, 4);
                    fileData.CopyTo(myData, 4 + fileNameByte.Length);





                    client.Client.Send(myData);
                    Console.WriteLine(myData.Length);
                    Console.WriteLine("File:{0} has been sent.", s);
                }




                void callmessagecode()
                {
                    string message = "message";
                    byte[] messageByte = Encoding.ASCII.GetBytes(message);
                    byte[] messageBuffer = new byte[messageByte.Length];
                    messageByte.CopyTo(messageBuffer, 0);
                    client.Client.Send(messageBuffer);




                    byte[] buffer1 = Encoding.ASCII.GetBytes(name + ":");
                    byte[] buffer = Encoding.ASCII.GetBytes(s);
                    byte[] buffer2 = new byte[buffer1.Length + buffer.Length];
                    buffer1.CopyTo(buffer2, 0);
                    buffer.CopyTo(buffer2, buffer1.Length);
                    ns.Write(buffer2, 0, buffer2.Length);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            client.Client.Shutdown(SocketShutdown.Send);
            thread.Join();
            ns.Close();
            client.Close();
            Console.WriteLine("disconnect from server!!");
            Console.ReadKey();
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
                    Console.WriteLine(messagedata);



                    NetworkStream ns = client.GetStream();



                    if (messagedata == "message")
                    {
                        byte[] receivedBytes = new byte[1024];
                        byte[] receivedbytes1 = new byte[1024 * 5000];



                        int byte_count;
                        while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                        {
                            Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
                        }
                    }



                    else if (messagedata == "file")
                    {
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
                        Console.ReadKey();
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