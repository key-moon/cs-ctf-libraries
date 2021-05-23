using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace CTFLibrary
{
    public partial class StreamWrapper : IDisposable
    {
        public static StreamWrapper FromTCP(IPEndPoint endpoint) => FromTCP(new TcpClient(endpoint));
        public static StreamWrapper FromTCP(string hostname, int port) => FromTCP(new TcpClient(hostname, port));
        public static StreamWrapper FromTCP(TcpClient client) => new StreamWrapper(client.GetStream());

        public static StreamWrapper FromFile(string fileName) => new StreamWrapper(new FileStream(fileName, FileMode.Append, FileAccess.ReadWrite));

        public static StreamWrapper FromExecutable(string path) => new StreamWrapper(ProcessUtil.Start(path).GetStream());

        public static StreamWrapper FromLinuxExecutable(string path) => new StreamWrapper(ProcessUtil.StartOnWSL(path).GetStream());
        public static StreamWrapper FromProcess(Process process) => new StreamWrapper(process.GetStream());
    }
}
