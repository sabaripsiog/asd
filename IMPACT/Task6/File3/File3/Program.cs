using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Image = System.Drawing.Image;

namespace Chatclient
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                IPAddress ip = IPAddress.Parse("192.168.153.57");
                int port = 5000;
                TcpClient client = new TcpClient();
                client.Connect(ip, port);
                Console.WriteLine("client connected!!");
                NetworkStream ns = client.GetStream();
                Thread thread = new Thread(o => ReceiveData((TcpClient)o));

                thread.Start(client);

                Console.WriteLine("Enter the file name to be sent:");
                string fileName;
                string filePath = @"C:/Users/Sabarish.a/Desktop/";

                while (!string.IsNullOrEmpty((fileName = Console.ReadLine())))
                {


                    byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);
                    
                    byte[] fileData = File.ReadAllBytes(filePath + fileName);
                    byte[] myData = new byte[4 + fileNameByte.Length + fileData.Length];
                    byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                   
                    fileNameLen.CopyTo(myData, 0);
                    fileNameByte.CopyTo(myData, 4);
                    fileData.CopyTo(myData, 4 + fileNameByte.Length);

                    client.Client.Send(myData);
                    Console.WriteLine(myData.Length);
                    Console.WriteLine("File:{0} has been sent.", fileName);
                }
                client.Client.Shutdown(SocketShutdown.Send);
                thread.Join();
                ns.Close();
                client.Close();
                Console.WriteLine("disconnect from server!!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed in sending " + ex.Message);
            }
        }
       

        static void ReceiveData(TcpClient client)
        {

            try
            {
                byte[] receivedBytes = new byte[1024*5000];
                

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
            catch (Exception ex)
            {
                Console.WriteLine("Failed in receiving " + ex.Message);
            }
        }
    }
}
