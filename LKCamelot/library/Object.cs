using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace LKCamelot.library
{
    public class LKObject
    {
        [Category("ObjectID")]
        public int ObjectID { get; set; }
        [Category("FaceDir")]
        public short FaceDir { get; set; }
        [Category("X")]
        public short X { get; set; }
        [Category("Y")]
        public short Y { get; set; }
    }

    public class MagicObject : LKObject
    {
        [Category("Width")]
        public byte Width { get; set; }

        private byte[] Sprite { get; set; }

        public MagicObject(int ObjectID, short FaceDir, short X, short Y, byte[] Sprite, byte Width)
        {
            this.ObjectID = ObjectID;
            this.FaceDir = FaceDir;
            this.X = X;
            this.Y = Y;
            this.Sprite = Sprite;
            this.Width = Width;
        }
    }

    public class ItemObject : LKObject
    {
        [Category("Width")]
        public byte Width { get; set; }

        private byte[] Name { get; set; }
        private byte[] Sprite { get; set; }

        public ItemObject(int ObjectID, short FaceDir, short X, short Y, byte[] Sprite, byte[] name)
        {
            this.ObjectID = ObjectID;
            this.FaceDir = FaceDir;
            this.X = X;
            this.Y = Y;
            this.Sprite = Sprite;
            this.Name = name;
        }
    }
}
