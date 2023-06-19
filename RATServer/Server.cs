using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

//Accept any IP address running on Port 8080, and new create new TCP/IP socket for remote access
IPEndPoint IPEndpoint = new IPEndPoint(IPAddress.Any, 8080);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(IPEndpoint);

//Listen for any incoming client requests - Listen number is how many clients can connect
socket.Listen(5);
Socket clientSocket = socket .Accept();

//Recieve data automatically from remote user

byte[] buffer = new byte[1024];
int recieveBytes = clientSocket.Receive(buffer);

//Process and decode recieved data
string recieveData = Encoding.ASCII.GetString(buffer, 0, recieveBytes);

//Execute any recieved command
Console.WriteLine(recieveData);

//Send response to remote user
String response = "command Successfully Executed";
byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
clientSocket.Send(responseBuffer);

Console.ReadLine();

//Close server
socket.Close();
