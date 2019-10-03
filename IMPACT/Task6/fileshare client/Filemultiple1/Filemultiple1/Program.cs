using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Client_Socket
{
    //FILE TRANSFER USING C#.NET SOCKET - CLIENT
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("That program can transfer small file. I've test up to 850kb file");
                IPAddress[] ipAddress = Dns.GetHostAddresses("192.168.153.57");
                IPEndPoint ipEnd = new IPEndPoint(ipAddress[0], 5656);
                Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                clientSock.Connect(ipEnd);

                byte[] clientData = new byte[1024 * 50000];
                string receivedPath = "C:/Users/Sabarish.a/Desktop/New/";
                int receivedBytesLen = clientSock.Receive(clientData);
                int fileNameLen = BitConverter.ToInt32(clientData, 0);
                string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);
                Console.WriteLine("Client:{0} connected & File {1} started received.", clientSock.RemoteEndPoint, fileName);
                BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Append)); ;
                bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
                Console.WriteLine("File: {0} received & saved at path: {1}", fileName, receivedPath);
                bWrite.Close();
                clientSock.Close();
                Console.ReadLine();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Sending fail." + ex.Message);
            }
        }
    }
}