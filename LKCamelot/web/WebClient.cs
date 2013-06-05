using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fleck;
using ProtoBuf;

namespace LKCamelot
{
    [ProtoContract]
    public class LoginProto
    {
        [ProtoMember(1)]
        public Login LoginP { get; set; }
        [ProtoMember(2)]
        public LoginResponse LoginReponseP { get; set; }
        [ProtoMember(3)]
        public CharCurrency CharCurrencyP { get; set; }
        [ProtoMember(4)]
        public CharCurrencyReponse CharCurrencyResponseP { get; set; }
        [ProtoMember(5)]
        public GetItems GetItemsP { get; set; }
        [ProtoMember(6)]
        public GetItemsResponse GetItemsResponseP { get; set; }
        [ProtoMember(7)]
        public CreateAuction CreateAuctionP { get; set; }
        [ProtoMember(8)]
        public GetAuctions GetAuctionsP { get; set; }
        [ProtoMember(9)]
        public GetAuctionsResponse GetAuctionsResponseP { get; set; }
        [ProtoMember(10)]
        public BuyAuction BuyAuctionP { get; set; }
        [ProtoMember(11)]
        public ClaimAuction ClaimAuctionP { get; set; }
        [ProtoMember(12)]
        public ClaimAuctionResponse ClaimAuctionResponseP { get; set; }
        [ProtoMember(13)]
        public BuyAuctionResponse BuyAuctionResponseP { get; set; }
        [ProtoMember(14)]
        public KeepAlive KeepAliveP { get; set; }
        [ProtoMember(15)]
        public KeepAliveResponse KeepAliveResponseP { get; set; }

    }

    [ProtoContract]
    public class BuyAuctionResponse
    {
        [ProtoMember(1)]
        public string result { get; set; }
    }

    [ProtoContract]
    public class KeepAlive
    {
        [ProtoMember(1)]
        public string result { get; set; }
    }

    [ProtoContract]
    public class KeepAliveResponse
    {
        [ProtoMember(1)]
        public string result { get; set; }
    }

    [ProtoContract]
    public class Login
    {
        [ProtoMember(1)]
        public string user { get; set; }
        [ProtoMember(2)]
        public string shapassword { get; set; }
    }

    [ProtoContract]
    public class LoginResponse
    {
        public enum LoginStatus
        {
            SUCCESS = 1,
            WRONGPASS = 2,
            LOGGEDIN = 3,
        }

        [ProtoMember(1)]
        public LoginStatus loginresp { get; set; }
        [ProtoMember(2)]
        public string classtype { get; set; }
    }

    [ProtoContract]
    public class CharCurrency
    {
        public string get { get; set; }
    }

    [ProtoContract]
    public class CharCurrencyReponse
    {
        [ProtoMember(1)]
        public string Gold { get; set; }
        [ProtoMember(2)]
        public string AGold { get; set; }
    }

    [ProtoContract]
    public class CreateAuction
    {
        [ProtoMember(1)]
        public string ItemSerial { get; set; }
        [ProtoMember(2)]
        public string Gold { get; set; }
        [ProtoMember(3)]
        public string AGold { get; set; }
    }

    [ProtoContract]
    public class GetItems
    {
        public string get { get; set; }
    }

    [ProtoContract]
    public class GetAuctions
    {
        public string get { get; set; }
    }

    [ProtoContract]
    public class BuyAuction
    {
        [ProtoMember(1)]
        public string ItemSerial { get; set; }
        [ProtoMember(2)]
        public bool useagold { get; set; }
    }

    [ProtoContract]
    public class ClaimAuction
    {
        [ProtoMember(1)]
        public string Serial { get; set; }
    }

    [ProtoContract]
    public class ClaimAuctionResponse
    {
        [ProtoMember(1)]
        public string slot { get; set; }
    }

    [ProtoContract]
    public class TraderItem
    {
        [ProtoMember(1)]
        public string Serial { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Sprite { get; set; }
        [ProtoMember(4)]
        public string Stage { get; set; }
        [ProtoMember(5)]
        public string Quantity { get; set; }
    }

    [ProtoContract]
    public class AuctionTraderItem
    {
        [ProtoMember(1)]
        public TraderItem BItem { get; set; }
        [ProtoMember(2)]
        public string Gold { get; set; }
        [ProtoMember(3)]
        public string AGold { get; set; }
        [ProtoMember(4)]
        public string flags { get; set; }
        [ProtoMember(5)]
        public int count { get; set; }
    }

    [ProtoContract]
    public class GetItemsResponse
    {
        [ProtoMember(1)]
        public List<TraderItem> traderItem { get; set; }
    }

    [ProtoContract]
    public class GetAuctionsResponse
    {
        [ProtoMember(1)]
        public List<AuctionTraderItem> auctiontraderItem { get; set; }
    }

    public class WebClient
    {
        public WebSocketListener cws_listener;
        public IWebSocketConnection iweb;
        public LKCamelot.model.Player player = null;

        public WebClient(IWebSocketConnection client, WebSocketListener cws_listener)
        {
            iweb = client;
            this.cws_listener = cws_listener;     
        }

        public void ProcessMessage(byte[] message)
        {
            //CListing.Builder newListing = CListing.CreateBuilder();
            //  var s = ProtoBuf.Serializer.Deserialize<Messaging.Message>(new MemoryStream(zmqMsg.Body));
            var msg = ProtoBuf.Serializer.Deserialize<LoginProto>(new System.IO.MemoryStream(message));

            if (msg.LoginP != null)
                LoginMessage(msg);

            if (!player.loggedIn || player.apistate != 1)
                return;

            if (msg.CharCurrencyP != null)
                CharCurMessage(player);

            if (msg.GetItemsP != null)
                GetItemsMessage(msg, player);

            if (msg.CreateAuctionP != null)
                CreateAuction(msg, player);

            if (msg.GetAuctionsP != null)
                GetAuctions(player);

            if (msg.BuyAuctionP != null)
                BuyAuction(msg);

            if (msg.ClaimAuctionP != null)
                ClaimAuction(msg);

            if (msg.KeepAliveP != null)
                KeepAlive(player);

        }

        public void LoginMessage(LKCamelot.LoginProto msg)
        {
            var accs = LKCamelot.model.PlayerHandler.getSingleton().add.Values;
            player = accs.Where(xe => xe.Name == msg.LoginP.user).FirstOrDefault();
            bool result;

            if (player.Pass.Length > 10)
                result = LKCamelot.util.Cryption.CheckHashPass(player.Pass, player.Name, msg.LoginP.shapassword);
            else
                result = (player.Pass == msg.LoginP.shapassword);

            LoginProto logResp = new LoginProto();
            logResp.LoginReponseP = new LoginResponse();
            if (player != null)
            {
                if (player.loggedIn)
                {
                    logResp.LoginReponseP.loginresp = LoginResponse.LoginStatus.LOGGEDIN;
                }
                else if (!result)
                {
                    logResp.LoginReponseP.loginresp = LoginResponse.LoginStatus.WRONGPASS;
                }
                else if (result)
                {
                    player.loggedIn = true;
                    player.apistate = 1;
                    player.keepalive = Server.tickcount.ElapsedMilliseconds;
                    logResp.LoginReponseP.loginresp = LoginResponse.LoginStatus.SUCCESS;
                    logResp.LoginReponseP.classtype = ((int)player.m_Class).ToString();
                }
            }
            else
            {
                logResp.LoginReponseP.loginresp = LoginResponse.LoginStatus.WRONGPASS;
            }
            iweb.Send(CreateBuffer(logResp));
        }

        public void CharCurMessage(LKCamelot.model.Player play)
        {
            LoginProto curResp = new LoginProto();
            curResp.CharCurrencyResponseP = new CharCurrencyReponse();
            curResp.CharCurrencyResponseP.Gold = play.Gold.ToString();
         //   curResp.CharCurrencyResponseP.AGold = play.Gold.ToString();
            iweb.Send(CreateBuffer(curResp));
        }

        public void KeepAlive(LKCamelot.model.Player play)
        {
            LoginProto curResp = new LoginProto();
            curResp.KeepAliveResponseP = new KeepAliveResponse();
            curResp.KeepAliveResponseP.result = "1";
            player.keepalive = Server.tickcount.ElapsedMilliseconds;
            iweb.Send(CreateBuffer(curResp));
        }

        public void GetItemsMessage(LKCamelot.LoginProto msg, LKCamelot.model.Player play)
        {
            LoginProto curResp = new LoginProto();
            curResp.GetItemsResponseP = new GetItemsResponse();
            var templ = new List<TraderItem>();
            foreach (var item in play.Inventory)
            {
                var ti = new TraderItem();
                ti.Name = item.Name;
                if (item.Stage > 0)
                    ti.Name += "<br>" + item.NPrefix() + "(" + item.Stage + ")";

                ti.Quantity = item.Quantity.ToString();
                ti.Serial = ((int)(item.m_Serial)).ToString();
                ti.Sprite = item.m_ItemID.ToString();
                ti.Stage = item.Stage.ToString();
                templ.Add(ti);
            }

            curResp.GetItemsResponseP.traderItem = templ;
            iweb.Send(CreateBuffer(curResp));
        }

        public void CreateAuction(LKCamelot.LoginProto msg, LKCamelot.model.Player play)
        {
            int ser = 0;
            ulong gold = 0;
            int agold = 0;
            try{
            ser = Convert.ToInt32(msg.CreateAuctionP.ItemSerial);
            gold = Convert.ToUInt64(msg.CreateAuctionP.Gold);
            agold = Convert.ToInt32(msg.CreateAuctionP.AGold);
            }
            catch{return;}

            var item = play.Inventory.Where(xe => xe.m_Serial == ser && 
                (xe.Parent == play || xe.ParSer == play.Serial)).FirstOrDefault();
            if (item != null)
            {
                LKCamelot.script.item.Item it;
                var aucit = new script.item.AuctionItem(item, gold, 1, agold);
                aucit.sellerSerial = play.Serial;
                aucit.state = script.item.aucState.forsale;

                LKCamelot.model.World.NewItems.TryRemove(item.m_Serial, out it);
                LKCamelot.model.World.NewAuctions.TryAdd(item.m_Serial, aucit);
            }
            GetItemsMessage(msg, play);
            GetAuctions(play);
        }

        public void GetAuctions(LKCamelot.model.Player play)
        {
            var aucs = LKCamelot.model.World.NewAuctions.Values.OrderBy(xe => xe.item.Name).ThenBy(xe => xe.item.Stage).ThenBy(xe => xe.goldprice).ToList();
            LoginProto curResp = new LoginProto();
            curResp.GetAuctionsResponseP = new GetAuctionsResponse();

            var templ = new List<AuctionTraderItem>();
            foreach (var item in aucs)
            {
                if (item.state == script.item.aucState.sold
                    && item.buyerSerial != play.Serial)
                    continue;

                var tt = new AuctionTraderItem();
                var ti = new TraderItem();
                ti.Name = item.item.Name;
                if (item.item.Stage > 0)
                    ti.Name += "<br>" + item.item.NPrefix() + "("+ item.item.Stage +")";
                ti.Quantity = item.item.Quantity.ToString();
                ti.Serial = ((int)item.item.m_Serial).ToString();
                ti.Sprite = item.item.m_ItemID.ToString();
                ti.Stage = item.item.Stage.ToString();
                tt.Gold = item.goldprice.ToString();
                tt.AGold = item.agoldprice.ToString();
                tt.flags = item.flags.ToString();
                tt.BItem = ti;
                tt.count = 1;
                if (item.sellerSerial == play.Serial && item.state == script.item.aucState.forsale)
                    tt.flags = "3";
                if (item.buyerSerial == play.Serial && item.state == script.item.aucState.sold)
                    tt.flags = "2";

                templ.Add(tt);
            }
            var templ2 = templ.ToList();
            AuctionTraderItem lastitem = new AuctionTraderItem();
            lastitem.BItem = new TraderItem();
            
            foreach (var temp in templ2)
            {
                if (temp.BItem.Name == lastitem.BItem.Name
                    && temp.flags == "1")
                {
                    templ.Remove(temp);
                    templ[templ.IndexOf(lastitem)].count++;

                    continue;
                }
                lastitem = temp;
            }
            curResp.GetAuctionsResponseP.auctiontraderItem = templ;
            iweb.Send(CreateBuffer(curResp));
        }

        public void BuyAuction(LKCamelot.LoginProto msg)
        {
            LoginProto curResp = new LoginProto();
            curResp.BuyAuctionResponseP = new BuyAuctionResponse();
            curResp.BuyAuctionResponseP.result = "2";

            LKCamelot.script.item.AuctionItem ai;
            try{
                ai = LKCamelot.model.World.NewAuctions[Convert.ToInt32(msg.BuyAuctionP.ItemSerial)];
            }
            catch{
                iweb.Send(CreateBuffer(curResp));
                return;}

            if (ai != null && ai.flags == 1)
            {
                if (player.Gold > ai.goldprice && msg.BuyAuctionP.useagold == false)
                {
                    player.m_Gold -= Convert.ToUInt64(ai.goldprice);
                    var owner = Server.playerHandler.add.Values.Where(xe => xe.Serial == ai.item.ParSer).FirstOrDefault();
                    owner.m_Gold += Convert.ToUInt64(ai.goldprice);

                    ai.buyerSerial = player.Serial;
                    ai.state = script.item.aucState.sold;

                    ai.item.ParSer = player.Serial;
                    ai.flags = 2;
                    curResp.BuyAuctionResponseP.result = "1";
                }
            }
            iweb.Send(CreateBuffer(curResp));
            CharCurMessage(player);
            GetAuctions(player);
        }

        public void ClaimAuction(LKCamelot.LoginProto msg)
        {
            LKCamelot.script.item.AuctionItem ai;
            try
            {
                ai = LKCamelot.model.World.NewAuctions[Convert.ToInt32(msg.ClaimAuctionP.Serial)];
            }
            catch { return; }

            if (ai != null)
            {
                if (ai.item.ParSer == player.Serial)
                {
                    ai.flags = 0;
                    LKCamelot.script.item.AuctionItem it;
                    LKCamelot.model.World.NewAuctions.TryRemove(ai.item.m_Serial, out it);
                    var titem = ai.item;
                    titem.m_InvSlot = player.FreeBankSlot;
                    titem.m_Loc = null;
                    titem.m_Parent = player;
                    titem.ParSer = player.Serial;
                    LKCamelot.model.World.NewItems.TryAdd(titem.m_Serial, titem);

                    LoginProto curResp = new LoginProto();
                    curResp.ClaimAuctionResponseP = new ClaimAuctionResponse();
                    curResp.ClaimAuctionResponseP.slot = titem.InvSlot.ToString();
                    iweb.Send(CreateBuffer(curResp));
                    CharCurMessage(player);
                    GetAuctions(player);
                }
            }
        }

        public byte[] CreateBuffer(LKCamelot.LoginProto msg)
        {
            System.IO.MemoryStream outp = new System.IO.MemoryStream();
            Serializer.Serialize(outp, msg);
            var buff = new byte[outp.Length];
            Array.Copy(outp.GetBuffer(), 0, buff, 0, outp.Length);
            return buff;
        }
    }
}
