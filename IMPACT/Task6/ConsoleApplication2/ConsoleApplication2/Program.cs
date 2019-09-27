using System;
using System.Net.Sockets;
using System.Threading;
public class AsynchIOServer
{
    static TcpListener tcpListener = new TcpListener(10);

    

    static void Listeners()
    {

        Socket socketForClient = tcpListener.AcceptSocket();
        if (socketForClient.Connected)
        {
            Console.WriteLine("Client:"+socketForClient.RemoteEndPoint+" now connected to server.");
            NetworkStream networkStream = new NetworkStream(socketForClient);
            System.IO.StreamWriter streamWriter =
            new System.IO.StreamWriter(networkStream);
            System.IO.StreamReader streamReader =
            new System.IO.StreamReader(networkStream);

            while (true)
            {
                string theString = streamReader.ReadLine();
                Console.WriteLine("Message recieved by client: "+ socketForClient.RemoteEndPoint + theString);
                if (theString == "exit")
                    break;
            }
            streamReader.Close();
            networkStream.Close();
            streamWriter.Close();
           
        }
        socketForClient.Close();
        Console.WriteLine("Press any key to exit from server program");
        Console.ReadKey();
    }
   
    public static void Main()
    {
        //TcpListener tcpListener = new TcpListener(10);
        tcpListener.Start();
        Console.WriteLine("************This is Server program************");
        Console.WriteLine("How many clients are going to connect to this server?:");
        int numberOfClientsYouNeedToConnect =int.Parse( Console.ReadLine());
        for (int i = 0; i < numberOfClientsYouNeedToConnect; i++)
        {
            Thread newThread = new Thread(new ThreadStart(Listeners));
            newThread.Start();
        }
  
    }
}
