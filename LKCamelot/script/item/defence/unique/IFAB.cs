using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class IFAB : BaseArmor, IAura
    {
        public override string Name { get { return "*BLESSED I Found a Bug and All I Got Was This Lousy T-Shirt"; } }
        public override string FlavorText { get { return "\"Dont put it in the dryer!\""; } }
        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 3; } }
        public override bool Blessed { get { return true; } }

        public override int ReduceCast { get { return 200; } }
        public override int ReduceSwing { get { return 100; } }

        public override int InitMinHits { get { return 500; } }
        public override int InitMaxHits { get { return 500; } }

        public override int APStage { get { return 0;} }

        public override Class ClassReq { get { return 0; } }
        public override ArmorType ArmorType { get { return ArmorType.Armor; } }

        public int Aura()
        {
            return 34;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);
            World.SendToAll(new QueDele(player.Map, new SetObjectEffectsPlayer(player).Compile()));
        }

        public override void Unequip(Player player, int slot)
        {
            base.Unequip(player, slot);
            World.SendToAll(new QueDele(player.Map, new SetObjectEffectsPlayer(player).Compile()));       
        }

        public IFAB()
            : base(177)
        {
        }

        public IFAB(Serial serial)
            : base(serial)
        {
        }
    }
}
