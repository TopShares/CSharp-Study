using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _023_socket编程_UDP协议_服务器端 {
    class Program
    {
        private static Socket udpServer;
        static void Main(string[] args) {
            //1,创建socket
             udpServer = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
            //2,绑定ip跟端口号
            udpServer.Bind( new IPEndPoint( IPAddress.Parse("192.168.0.112"),7788 ) );

            //3，接收数据
            new Thread(ReceiveMessage){ IsBackground = true}.Start();

            //udpServer.Close();
            Console.ReadKey();
        }

        static void ReceiveMessage()
        {
            while (true)
            {
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = new byte[1024];
                int length = udpServer.ReceiveFrom(data, ref remoteEndPoint);//这个方法会把数据的来源(ip:port)放到第二个参数上
                string message = Encoding.UTF8.GetString(data, 0, length);
                Console.WriteLine("从ip：" + (remoteEndPoint as IPEndPoint).Address.ToString() + "：" + (remoteEndPoint as IPEndPoint).Port + "收到了数据：" + message);
            }

        }
    }
}
