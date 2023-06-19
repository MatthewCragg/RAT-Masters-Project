using System.Net;
using System.Net.Sockets;
using System.Text;

//Create new TCP/IP request for remote access
IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//Connect to remote server
socket.Connect(iPEndPoint);

//Send commands to the remote server
string command = "Connected to first server";
byte[] commandBuffer = Encoding.ASCII.GetBytes(command);
socket.Send(commandBuffer);

//Get response from server
byte[] responseBuffer = new byte[1024];
int receivedBytes = socket.Receive(responseBuffer);
string response = Encoding.ASCII.GetString(responseBuffer, 0, receivedBytes);

//Display response
Console.WriteLine("response");
Console.ReadLine();

//Close socket
socket.Close();
