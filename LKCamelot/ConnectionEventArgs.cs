using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot
{
    public class ConnectionEventArgs : EventArgs
    {
        public Connection Connection { get; private set; }

        public ConnectionEventArgs(Connection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");
            this.Connection = connection;
        }

        public override string ToString()
        {
            return Connection.RemoteEndPoint != null
                ? Connection.RemoteEndPoint.ToString()
                : "Not Connected";
        }
    }
}
