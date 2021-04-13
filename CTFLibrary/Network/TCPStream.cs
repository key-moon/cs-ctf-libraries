using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    //https://dobon.net/vb/dotnet/internet/tcpclientserver.html を参考に
    /// <summary>TCPの書き込み/読み込みをする(実質nc)</summary>
    public class TCPStream : IDisposable
    {
        public static bool logging = false;
        public static bool doOut = true;
        /// <summary>一回に読み込む長さ</summary>
        int readSize = 16777216;

        TcpClient client;
        NetworkStream stream;
        Encoding encoding;

        public string ReadToEnd()
        {
            string message;
            using (MemoryStream dataStoreStream = new MemoryStream())
            {
                int readCount = 1;
                int size = -1;
                byte[] resBuffer = new byte[readSize];
                WriteLog("読込開始");
                do
                {
                    size = stream.Read(resBuffer, 0, readSize);
                    if (size == 0)
                    {
                        throw new IOException("接続が切断されました。");
                        Task.Delay(100).Wait();
                    }
                    dataStoreStream.Write(resBuffer, 0, size);
                    WriteLog($"{readCount}回目の読込完了 : {size}bytes. total : {dataStoreStream.Length}");
                    readCount++;
                } while (stream.DataAvailable || size == readSize /*|| resBuffer[size - 1] != '\n'*/);

                WriteLog("読込完了");
                message = encoding.GetString(dataStoreStream.GetBuffer(), 0, (int)dataStoreStream.Length);
            }
            message = message.TrimEnd('\n');
            WriteInfo($"{message}");
            return message;
        }

        public void WriteLine(string value = "") => Write(value + "\n");

        public void Write(string value)
        {
            WriteLog("送信開始");
            byte[] data = encoding.GetBytes(value);
            WriteBytes(data);
            WriteInfo($" > {value}");
        }

        public void WriteBytes(byte[] data)
        {
            stream.Write(data, 0, data.Length);
            WriteLog($"送信完了: {data.Length} byte(s)");
            stream.Flush();
        }

        public void Dispose()
        {
            client.Dispose();
        }

        private void WriteLog(string str)
        {
            if (logging) Debug.WriteLine(str);
        }
        private void WriteInfo(string str)
        {
            if (doOut) Debug.WriteLine(str);
        }

        #region constructor

        public TCPStream(IPEndPoint endPoint, Encoding encoding = null) : this(new TcpClient(endPoint), encoding ?? Encoding.Default) { }

        public TCPStream(string ip, int port, Encoding encoding = null) : this(new TcpClient(ip, port), encoding ?? Encoding.Default) { }

        private TCPStream(TcpClient client, Encoding encoding)
        {
            client.NoDelay = false;
            client.SendBufferSize = 4096;
            client.ReceiveBufferSize = 4096;
            this.encoding = encoding;
            if (logging) Debug.WriteLine("接続開始");
            this.client = client;
            if (logging) Debug.WriteLine("接続完了");
            stream = client.GetStream();
        }

        #endregion
    }
}
