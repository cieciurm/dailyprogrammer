using System;
using System.Net.Sockets;
using System.Text;

namespace Mateusz.DailyProgrammer._258
{
    public class IrcConnectionManager
    {
        public const string Server = "chat.freenode.net";
        public const int Port = 6667;

        public string Connect(ArgsDto args)
        {
            int expectedNumerOfLines = 5;
            var client = new TcpClient(Server, Port);
            var stream = client.GetStream();

            SendNick(args, stream);
            SendUser(args, stream);

            var responseBuilder = new StringBuilder();

            using (stream)
            {
                while (expectedNumerOfLines > 0)
                {
                    var data = new byte[256];
                    int bytes = stream.Read(data, 0, data.Length);
                    var partialResponse = Encoding.ASCII.GetString(data, 0, bytes);

                    responseBuilder.Append(partialResponse);

                    expectedNumerOfLines--;
                }
            }

            return responseBuilder.ToString();
        }

        private void SendUser(ArgsDto args, NetworkStream stream)
        {
            byte[] userNameBytes = Encoding.ASCII.GetBytes($"USER {args.NickName} 0 * :${args.RealName}" + Environment.NewLine);
            stream.Write(userNameBytes, 0, userNameBytes.Length);
        }

        private void SendNick(ArgsDto args, NetworkStream stream)
        {
            byte[] nickNameBytes = Encoding.ASCII.GetBytes($"NICK {args.NickName}" + Environment.NewLine);
            stream.Write(nickNameBytes, 0, nickNameBytes.Length);
        }
    }
}
