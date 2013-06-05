using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class KVSword : BaseWeapon, IProc
    {
        public override string Name { get { return "Sword of Knight Vlad"; } }

        public override int DamBase { get { return 167; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 515; } }
        public override int DexReq { get { return 101; } }

        public override int InitMinHits { get { return 500; } }
        public override int InitMaxHits { get { return 500; } }

        public override Class ClassReq { get { return Class.Knight; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public int Proc(Player player, script.monster.Monster mob, Player play = null)
        {
            int take = 0;
            Point2D targetLoc = (play != null) ? play.Loc : mob.m_Loc;
            if (Util.Dice(1, 100, 0) <= (Stage < 7 ? 10 : 14))
            {
                take += Util.Dice((player.GetStat("str") / 1000), 50, player.GetStat("str") / 16);
                int mobile = Serial.NewMobile;
                World.SendToAll(new QueDele(player.Map, new CreateMagicEffect(mobile, 1, (short)targetLoc.X, (short)targetLoc.Y, new byte[] { 4, 0, 0, 0, 0, 0, 0, 0, 0, 110 }, 0).Compile()));
                var tmp = new QueDele(LKCamelot.Server.tickcount.ElapsedMilliseconds + 1300, player.m_Map, new DeleteObject(mobile).Compile());
                tmp.tempser = mobile;
                World.TickQue.Add(tmp);
            }
            return take;
        }

        public KVSword()
            : base(181)
        {
        }

        public KVSword(Serial serial)
            : base(serial)
        {
        }
    }
}
