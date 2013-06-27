using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Timers;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.Globalization;
using System.Net;
using System.IO;
using System.Diagnostics;

using LKCamelot.util;
using LKCamelot.model;
using LKCamelot.io;

namespace LKCamelot
{
    public class Server
    {
#if DEBUG
        private static bool s_bDoDebugOnlyCode = true;
#endif

        public static Stopwatch tickcount;
        // [STAThread]
        static void Main(string[] args)
        {
            //        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            tickcount = new Stopwatch();
            tickcount.Start();

            InitRoutine();

            string cline = "";
            while (cline != "exit" && cline != "x")
                cline = Console.ReadLine();

            Console.WriteLine("Server Exitted");
            World.SaveAll();
            Console.ReadLine();
        }

        static void domain_ProcessExit(object sender, EventArgs e)
        {
            LKCamelot.model.World.SaveAll();
        }

        public static void App_ThreadException(object sender, UnhandledExceptionEventArgs e)
        {
            World.SaveAll();

            Console.WriteLine((e.ExceptionObject as Exception).StackTrace);

            var trace = new System.Diagnostics.StackTrace();
            using (StreamWriter sw = new StreamWriter("lastexep.txt", true))
            {
                sw.WriteLine((e.ExceptionObject as Exception).StackTrace);
            }

        } 

        ~Server()
        {
            Console.WriteLine(string.Format("Server destroyed at: {0}", DateTime.Now));
        }

        static void InitRoutine()
        {
      //      Extractor.ExtractMonsters();
            AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(App_ThreadException);
            AppDomain.CurrentDomain.ProcessExit += new System.EventHandler(domain_ProcessExit);

            Console.WriteLine("Server " + "Loading " + Config.ServerName + "...");
            ClientHandler = new Server();
            IOThread = new IOThread();
            WebServer = new WebSocketListener();
            playerHandler = PlayerHandler.getSingleton();
            world = World.getSingleton();
            world.handler = playerHandler;
            World.w_server = ClientHandler;
            //        instanceManager = InstanceManager.getSingleton();
            Map.Init();
          /*  Task.Factory.StartNew(() =>
                {
                    IOThread.run();
                });*/
            (new Thread(IOThread.run)).Start();
            (new Thread(ClientHandler.run)).Start();
            (new Thread(WebServer.run)).Start();
            Console.WriteLine("Loading tapping list");
            LKCamelot.model.Modules.NSA.LoadTapList();

            int waitFails = 0;
            long lastTicks = CurrentTimeMillis();
            long totalTimeSpentProcessing = 0;
            int cycle = 0;
#if DEBUG
            if (!s_bDoDebugOnlyCode)
            {
                while (!shutdownServer)
                {
                   // playerHandler.process();
                    //EventManager.getSingleton().shutdown();
                    //        instanceManager.process();
                    long timeSpent = CurrentTimeMillis() - lastTicks;
                    totalTimeSpentProcessing += timeSpent;
                    if (timeSpent >= Config.CycleTime)
                    {
                        timeSpent = Config.CycleTime;
                     //   if (++waitFails > 100)
                            //shutdownServer = true;
                    }

                    try
                    {
                        Thread.Sleep((int)(Config.CycleTime - timeSpent));
                    }
                    catch { }

                    lastTicks = CurrentTimeMillis();
                    cycle++;
                    if (cycle % 100 == 0)
                    {
                        //@SuppressWarnings("unused")
                        float time = ((float)totalTimeSpentProcessing) / cycle;
                        Console.WriteLine("KERNEL", ((time * 100) / Config.CycleTime) + "% processing time");
                    }
                }

                //    playerHandler.destruct();
                ClientHandler.killServer();
                ClientHandler = null;
            }
#endif
        }

        public void OnConnecte(object sender, ConnectionEventArgs e)
        {
            //      Logger.Trace("Game-Client connected: {0}", e.Connection.ToString());

            var gameClient = new IOClient(e.Connection);
            e.Connection.Client = gameClient;
            e.Connection.Client.keepalive = Server.tickcount.ElapsedMilliseconds;
            gameClient.handler = playerHandler;
            Console.WriteLine("Connections O: " + Connections.Count);
          //  playerHandler.newPlayerClient(gameClient);
        }

        public void OnDisconnecte(object sender, ConnectionEventArgs e)
        {
            //      Logger.Trace("Client disconnected: {0}", e.Connection.ToString());
            //   playerHandler.RemovePlayerFromGame((IOClient)e.Connection.Client);
            if (e.Connection.Client.player != null)
            {
                e.Connection.Client.player.loggedIn = false;
                lock (ConnectionLock)
                    Connections.Remove(e.Connection);
                
                World.SendToAll(new QueDele(e.Connection.Client.player.Map, new DeleteObject(e.Connection.Client.player.Serial).Compile()));
            }
            Console.WriteLine("Connections C: " + Connections.Count);
          //  playerHandler.removePlayerClient(e.Connection.Client);
        }

        public void run()
        {
            AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(App_ThreadException);
            this.OnConnect += OnConnecte;
            this.OnDisconnect += OnDisconnecte;
            this.DataReceived += GameServer_DataReceived;
            this.DataSent += (sender, e) => { };

            shutdownClientHandler = false;

            var bindIP = "0.0.0.0";
            int Port = 43333;

            if (!this.Listen(bindIP, Port)) return;
            Console.WriteLine("Server is listening on {0}:{1}...", bindIP, Port);
        }

        void GameServer_DataReceived(object sender, ConnectionDataEventArgs e)
        {
            var connection = (Connection)e.Connection;
            ((IOClient)connection.Client).Parse(e);
        }

        public virtual bool Listen(string bindIP, int port)
        {
            // Create new TCP socket and set socket options.
            Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Setup our options:
            // * NoDelay - true - don't use packet coalescing
            // * DontLinger - true - don't keep sockets around once they've been disconnected
            Listener.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
            Listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);

            try
            {
                Listener.Bind(new IPEndPoint(IPAddress.Parse(bindIP), port));
                this.Port = port;
            }
            catch (SocketException)
            {
                Console.WriteLine(string.Format("Could not bind on {0}", bindIP));
                Console.ReadLine();
            }

            Listener.Listen(10);
            IsListening = true;

            // Begin accepting any incoming connections asynchronously.
            Listener.BeginAccept(acceptCallback, null);

            return true;
        }

        private void acceptCallback(IAsyncResult result)
        {
            if (Listener == null) return;

            try
            {
                var socket = Listener.EndAccept(result); // Finish accepting the incoming connection.
                var connection = new Connection(this, socket); // Add the new connection to the dictionary.

                lock (ConnectionLock) Connections.Add(connection); // add the connection to list.

                OnClientConnection(new ConnectionEventArgs(connection)); // Raise the OnConnect event.

                connection.BeginReceive(readCallback, connection); // Begin receiving on the new connection connection.
                Console.WriteLine("new connection: "+socket.RemoteEndPoint);
            }
            catch (NullReferenceException) { } // we recive this after issuing server-shutdown, just ignore it.
            catch (SocketException) { }//We recieve this if client disconnects too quickly, ignore it
            catch (Exception e)
            {
                Console.WriteLine(string.Format("{0} {1}", e, "AcceptCallback"));
            }

            Listener.BeginAccept(acceptCallback, null); // Continue receiving other incoming connection asynchronously.
        }

        private void readCallback(IAsyncResult result)
        {
            var connection = result.AsyncState as Connection; // Get the connection connection passed to the callback.
            if (connection == null) return;

            try
            {
                var bytesRecv = connection.EndReceive(result); // Finish receiving data from the socket.

                if (bytesRecv > 0)
                {
                    OnDataReceived(new ConnectionDataEventArgs(connection, connection.RecvBuffer.Enumerate(0, bytesRecv))); // Raise the DataReceived event.
                    //     Console.WriteLine(connection.RecvBuffer.ToFormatedHexString().Remove(bytesRecv*3));

                    // Begin receiving again on the socket, if it is connected.
                    if (connection.IsConnected)
                        connection.BeginReceive(readCallback, connection);
                    else
                        Console.WriteLine("Connection closed:" + connection);//.Client);

                }
                else RemoveConnection(connection, true); // Connection was lost.
            }
            catch (SocketException e)
            {
                RemoveConnection(connection, true); // An error occured while receiving, connection has disconnected.
                Console.WriteLine(string.Format("{0} {1}", e, "ReceiveCallback"));
            }
            catch (Exception e)
            {
                RemoveConnection(connection, true); // An error occured while receiving, the connection may have been disconnected.
                Console.WriteLine(string.Format("{0} {1}", e, "ReceiveCallback"));
            }
        }

        public virtual int Send(Connection connection, byte[] buffer, int start, int count, SocketFlags flags)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (buffer == null) throw new ArgumentNullException("buffer");

            var totalBytesSent = 0;
            var bytesRemaining = buffer.Length;

            try
            {
                while (bytesRemaining > 0) // Ensure we send every byte.
                {
                    // [D3Inferno]
                    // Use Connection wrapper to send the data so that it can be sent either over
                    // the normal NetworkStream (prior to Tls Authentication) or over the encrypted
                    // SslStream.
                    // Send the remaining data.
                    //int bytesSent = connection.Socket.Send(buffer, totalBytesSent, bytesRemaining, flags);

                    if (connection == null || connection.Socket == null || connection._server == null)
                    {
                        Disconnect(connection);
                        return 0;
                    }

                    int bytesSent = connection._Send(buffer, totalBytesSent, bytesRemaining, flags);

                    if (bytesSent > 0)
                        OnDataSent(new ConnectionDataEventArgs(connection, buffer.Enumerate(totalBytesSent, bytesSent))); // Raise the Data Sent event.

                    // Decrement bytes remaining and increment bytes sent.
                    bytesRemaining -= bytesSent;
                    totalBytesSent += bytesSent;
                }
            }
            catch (SocketException)
            {
                RemoveConnection(connection, true); // An error occured while sending, connection has disconnected.
            }
            catch (Exception e)
            {
                RemoveConnection(connection, true); // An error occured while sending, it is possible that the connection has a problem.
                //   Logger.DebugException(e, "Send");
            }

            return totalBytesSent;
        }

        public virtual void Disconnect(Connection connection)
        {
            if (connection == null)
                return;

            RemoveConnection(connection, true);
        }

        private void RemoveConnection(Connection connection, bool raiseEvent)
        {
            if (connection == null)
                return;
            connection.Disconnect();

            if (connection.Client != null
                && connection.Client.player != null)
            {
                connection.Client.player.InstancedObjects.Clear();
                connection.Client.player.m_Buffs.Clear();
            }

            // Remove the connection from the dictionary and raise the OnDisconnection event.
            lock (ConnectionLock)
            {
                if (Connections.Contains(connection))
                    Connections.Remove(connection);
            }

            if (raiseEvent)
                NotifyRemoveConnection(connection);
        }

        protected virtual void OnClientConnection(ConnectionEventArgs e)
        {
            var handler = OnConnect;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnDataReceived(ConnectionDataEventArgs e)
        {
            var handler = DataReceived;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnDataSent(ConnectionDataEventArgs e)
        {
            var handler = DataSent;
            if (handler != null) handler(this, e);
        }

        private void NotifyRemoveConnection(Connection connection)
        {
            OnClientDisconnect(new ConnectionEventArgs(connection));
        }

        protected virtual void OnClientDisconnect(ConnectionEventArgs e)
        {
            var handler = OnDisconnect;
            if (handler != null) handler(this, e);
        }

        public void killServer()
        {
            try
            {
                shutdownClientHandler = true;

                LKCamelot.model.World.SaveAll();
            }
            catch { }
        }
        static readonly DateTime Epoch = new DateTime(1970, 1, 1);
        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Epoch).TotalMilliseconds;
        }

        public Connection[] OnlineConnections
        {
            get
            {
                Connection[] ret;
                lock (ConnectionLock)
                {
                    ret = new Connection[Connections.Count];
                    Connections.CopyTo(ret, 0);
                }
                return ret;
            }
        }

        protected List<Connection> Connections = new List<Connection>();
        protected object ConnectionLock = new object();

        public delegate void ConnectionEventHandler(object sender, ConnectionEventArgs e);
        public delegate void ConnectionDataEventHandler(object sender, ConnectionDataEventArgs e);

        public event ConnectionEventHandler OnConnect;
        public event ConnectionEventHandler OnDisconnect;
        public event ConnectionDataEventHandler DataReceived;
        public event ConnectionDataEventHandler DataSent;
        private bool _disposed;

        public bool IsListening { get; private set; }
        protected Socket Listener;
        public int Port { get; private set; }
        public static Server ClientHandler;
        public static WebSocketListener WebServer; 
        public static World world = null;
        public static PlayerHandler playerHandler = null;
        // public static InstanceManager instanceManager = null;
        public static bool shutdownServer = false;
        public static bool shutdownClientHandler;
        public static IOThread IOThread = null;
    }
}
