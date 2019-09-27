using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace beginSocketServer
{
    //FILE TRANSFER USING C#.NET SOCKET - SERVER
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 8100);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                sock.Bind(ipEnd);
                sock.Listen(100);
                //clientSock is the socket object of client, so we can use it now to transfer data to client
                Socket clientSock = sock.Accept();

                byte[] clientData = new byte[1024 * 5000];
                string receivedPath = "C:/Users/Sabarish.a/Desktop/";

                int receivedBytesLen = clientSock.Receive(clientData);

                int fileNameLen = BitConverter.ToInt32(clientData, 0);
                string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);

                Console.WriteLine("Client:{0} connected & File {1} started received.", clientSock.RemoteEndPoint, fileName);

                BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Append));
                bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);

                Console.WriteLine("File: {0} received & saved at path: {1}", fileName, receivedPath);

                bWrite.Close();

                clientSock.Close();
                Console.ReadLine();

            }
            catch (Exception ex)
            {

                Console.WriteLine("File Sending fail." + ex.Message);
            }
        }
    }
}
