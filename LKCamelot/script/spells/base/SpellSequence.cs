using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.spells
{
	public class SpellSequence
	{
        public int OnCastSprite, MovingSprite, OnImpactSprite, Thickness, Speed, Streak, Type;

        public SpellSequence(int castsprite, int movingsprite, int impactsprite, int Thickness, int Type, int Speed, int Streak)
        {
            this.OnCastSprite = castsprite;
            this.MovingSprite = movingsprite;
            this.OnImpactSprite = impactsprite;
            this.Thickness = Thickness;
            this.Type = Type;
            this.Speed = Speed;
            this.Streak = Streak; 
        }
	}
}
