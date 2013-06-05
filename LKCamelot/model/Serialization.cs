using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.model
{
    public abstract class GenericWriter
    {
        protected GenericWriter() { }

        public abstract void Close();

        public abstract long Position { get; }

        public abstract void Write(string value);
        public abstract void Write(DateTime value);
#if Framework_4_0
		public abstract void Write( DateTimeOffset value );
#endif
        public abstract void Write(TimeSpan value);
        public abstract void Write(decimal value);
        public abstract void Write(long value);
        public abstract void Write(ulong value);
        public abstract void Write(int value);
        public abstract void Write(uint value);
        public abstract void Write(short value);
        public abstract void Write(ushort value);
        public abstract void Write(double value);
        public abstract void Write(float value);
        public abstract void Write(char value);
        public abstract void Write(byte value);
        public abstract void Write(sbyte value);
        public abstract void Write(bool value);
        public abstract void WriteEncodedInt(int value);
     //   public abstract void Write(IPAddress value);

        public abstract void WriteDeltaTime(DateTime value);

    //    public abstract void Write(Point3D value);
        public abstract void Write(Point2D value);
     //   public abstract void Write(Rectangle2D value);
    //    public abstract void Write(Rectangle3D value);


    //    public abstract void Write(Item value);


   //     public abstract void Write(Race value);

  //      public abstract void WriteItemList(ArrayList list);
   //     public abstract void WriteItemList(ArrayList list, bool tidy);

   //     public abstract void WriteMobileList(ArrayList list);
   //     public abstract void WriteMobileList(ArrayList list, bool tidy);

     //   public abstract void WriteGuildList(ArrayList list);
   //     public abstract void WriteGuildList(ArrayList list, bool tidy);

   //     public abstract void Write(List<Item> list);
  //      public abstract void Write(List<Item> list, bool tidy);

  //      public abstract void WriteItemList<T>(List<T> list) where T : Item;
 //       public abstract void WriteItemList<T>(List<T> list, bool tidy) where T : Item;
#if Framework_4_0
		public abstract void Write( HashSet<Item> list );
		public abstract void Write( HashSet<Item> list, bool tidy );

		public abstract void WriteItemSet<T>( HashSet<T> set ) where T : Item;
		public abstract void WriteItemSet<T>( HashSet<T> set, bool tidy ) where T : Item;
#endif



#if Framework_4_0
		public abstract void Write( HashSet<Mobile> list );
		public abstract void Write( HashSet<Mobile> list, bool tidy );

		public abstract void WriteMobileSet<T>( HashSet<T> set ) where T : Mobile;
		public abstract void WriteMobileSet<T>( HashSet<T> set, bool tidy ) where T : Mobile;
#endif
  //      public abstract void Write(List<BaseGuild> list);
  //      public abstract void Write(List<BaseGuild> list, bool tidy);

    //    public abstract void WriteGuildList<T>(List<T> list) where T : BaseGuild;
   //     public abstract void WriteGuildList<T>(List<T> list, bool tidy) where T : BaseGuild;
#if Framework_4_0
		public abstract void Write( HashSet<BaseGuild> list );
		public abstract void Write( HashSet<BaseGuild> list, bool tidy );

		public abstract void WriteGuildSet<T>( HashSet<T> set ) where T : BaseGuild;
		public abstract void WriteGuildSet<T>( HashSet<T> set, bool tidy ) where T : BaseGuild;
#endif
        //Stupid compiler won't notice there 'where' to differentiate the generic methods.
    }
}
