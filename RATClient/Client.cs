using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Http;




internal class Program
{
    private static Stream fullPath;

    public static void DoGetHostEntry(IPAddress address)
    {
        IPHostEntry host = Dns.GetHostEntry(address);

        Console.WriteLine($"GetHostEntry({address}) returns HostName: {host.HostName}");
        Console.ReadLine();
    }


    private static void Main(string[] args)
    {
        //Create new TCP/IP request for remote access
        IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //Connect to remote server
        socket.Connect(iPEndPoint);

        //Send commands to the remote server
        string command = "Server connection made.";
        byte[] commandBuffer = Encoding.ASCII.GetBytes(command);
        socket.Send(commandBuffer);

        //Display response
        Console.WriteLine("Client connected.");


        //Generatss the text file in root folder
        using (var file = File.Create("genericfile.txt")) ;

        //Gets the IP from the connection socket and writes to string
        string localIP;
        using (Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
        {
            IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
            localIP = endPoint.Address.ToString();
        }

        //Copies IP to the text file in root folder
        using (StreamWriter writer = new StreamWriter("genericfile.txt"))
        {
            writer.WriteLine(localIP);
        }

        //Get response from server
        byte[] responseBuffer = new byte[1024];
        int receivedBytes = socket.Receive(responseBuffer);
        string response = Encoding.ASCII.GetString(responseBuffer, 0, receivedBytes);

        //Get machine name and post to client
         Console.WriteLine("MachineName: {0}", Environment.MachineName);

        //Gets and prints all IP addresses linked to machine
        //  IPHostEntry hostInfo = Dns.GetHostByName("google.com");
        //  Console.WriteLine("Client name : " + hostInfo.HostName);
        //  Console.WriteLine("IP address List : ");
        //  for (int index = 0; index < hostInfo.AddressList.Length; index++)
        //  {
        //      Console.WriteLine(hostInfo.AddressList[index]);
        //   }


        //Close socket
        Console.ReadLine();
        socket.Close();
    }
}
//this is a test, because kevin is a mook