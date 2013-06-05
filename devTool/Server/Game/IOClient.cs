using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devTool
{
    public class IOClient
    {
        public Connection connection;
        private long connectedAt;
        public PacketWriter mm_stream;
        private readonly Stream incomingStream = new Stream();

        private object _bufferLock = new object();
        public long keepalive = 0;

        public IOClient(Connection c)
        {
            this.connection = c;
            this.connectedAt = Server.CurrentTimeMillis();
            this.mm_stream = new PacketWriter(255);
        }

        public void Parse(ConnectionDataEventArgs e)
        {
            incomingStream.AppendData(e.Data.ToArray());
            while (incomingStream.IsPacketAvailable())
            {
                var packet = incomingStream.PopPacket();

                try
                {
                    //   Logger.LogIncomingPacket(message); 
                    Console.WriteLine(string.Format("Recv {0} - {1}:  {2}",
                        packet.Length, DateTime.Now.ToLocalTime().TimeOfDay.ToString().Remove(10, 4), packet.ToFormatedHexString()));
                    HandleIncoming(packet);
                }
                catch (NotImplementedException) { }
                catch (Exception ee)
                {
                    Console.WriteLine(string.Format("Unknown incoming Packet exception: {0}", ee.StackTrace));
                }
            }
            incomingStream.Flush();
        }

        public void SendPacket(Byte[] packet)
        {
            lock (this._bufferLock)
                connection.Send(packet);
        }

        public void HandleIncoming(Byte[] data)
        {
            PacketReader p = null;
            switch (data[0])
            {
                case 0x34: // Keep Alive
                    keepalive = Program.tickcount.ElapsedMilliseconds;
                    break;
                case 0x03:
              //  case 0xFF:
                    SendPacket(new CloseLogin().Compile());
                    SendPacket(new LoadWorld().Compile());
                    break;
            }
        }
    }
}
