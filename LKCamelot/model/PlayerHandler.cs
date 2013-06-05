using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;
using LKCamelot.io;
using System.Collections.Concurrent;

namespace LKCamelot.model
{
    public class PlayerHandler
    {
        public ConcurrentDictionary<string, Player> add = new ConcurrentDictionary<string, Player>();

        private static PlayerHandler singleton = null;
        public static PlayerHandler getSingleton()
        {
            if (singleton == null)
                singleton = new PlayerHandler();

            return singleton;
        }

        public void newPlayerClient(IOClient client)
        {
            try
            {
                client.handler = this;
            }
            catch (Exception e)
            {
                Console.WriteLine("E at newplayerclient", e.ToString());
            }

       //     add.TryAdd(client, null);
            Console.WriteLine("Players Online: " + add.Count);
        }

        public void removePlayerClient(IOClient client)
        {
            Player cli;
      //      add.TryRemove(client, out cli);
            if (client.player != null)
                World.SendToAll(new QueDele(client.player.Map, new DeleteObject(client.player.Serial).Compile()));
            
            Console.WriteLine("Players Online: " + add.Count);
        }

        public bool HasPlayer(string name)
        {
            if (add.Where(xe => xe.Key == name && xe.Value.loggedIn).FirstOrDefault().Key != null)
                return true;
            return false;
        }


    }
}
