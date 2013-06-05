using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace devTool
{
    public class Connection
    {
        public Socket Socket { get; set; }
        public IOClient Client { get; set; }
        public Server _server;

        public static readonly int BufferSize = 4 * 1024;
        private readonly byte[] _recvBuffer = new byte[BufferSize];

        public int Receive(int start, int count)
        {
            return this.Socket.Receive(_recvBuffer, start, count, SocketFlags.None);
        }

        public byte[] RecvBuffer
        {
            get { return _recvBuffer; }
        }

        public int _Send(byte[] buffer, int start, int count, SocketFlags flags)
        {
            int ret = 0;
            try
            {
                ret = this.Socket.Send(buffer, start, count, flags);
            }
            catch (Exception e)
            {
                if (_server != null)
                    _server.Disconnect(this);
                Console.WriteLine("Failed to send: " + e.Message + "  " + e.StackTrace);
            }
            return ret;
        }

        public int Send(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            return Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public int Send(byte[] buffer, int start, int count, SocketFlags flags)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (_server == null)
            {
                Console.WriteLine("_server is null");
                return 0;
               // throw new Exception(" _server is null in Send");   
            }
            int ret = 0;
            try
            {
                ret = _server.Send(this, buffer, start, count, flags);
            }
            catch
            {
                _server.Disconnect(this);
            }

            return ret;
        }

        public Connection(Server server, Socket socket)
        {
            if (server == null)
                throw new ArgumentNullException("server");

            if (socket == null)
                throw new ArgumentNullException("socket");

            this._server = server;
            this.Socket = socket;
        }

        public bool IsConnected
        {
            get { return (Socket == null) ? false : Socket.Connected; }
        }

        public IPEndPoint RemoteEndPoint
        {
            get { return (Socket == null) ? null : Socket.RemoteEndPoint as IPEndPoint; }
        }

        public IPEndPoint LocalEndPoint
        {
            get { return Socket.LocalEndPoint as IPEndPoint; }
        }

        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            return this.Socket.BeginReceive(_recvBuffer, 0, BufferSize, SocketFlags.None, callback, state);
        }

        public int EndReceive(IAsyncResult result)
        {
            return this.Socket.EndReceive(result);
        }

        public void Disconnect()
        {
            //      Logger.Trace("Disconnect() | server: " + _server);
            try
            {
            }
            catch { }
            if (_server != null)
            {
                // Use temp assignment to preven recursion.
                Server tempServer = _server;
                _server = null;
                tempServer.Disconnect(this);
            }

            if (this.Socket != null)
            {
                try
                {
                    this.Socket.Shutdown(SocketShutdown.Both);
                    this.Socket.Close();
                }
                catch (Exception)
                {
                    // Ignore any exceptions that might occur during attempt to close the Socket.
                }
                finally
                {
                    try
                    {
                        this.Socket.Dispose();
                        this.Socket = null;
                    }
                    catch { }
                }
            }
        }
    }
}
