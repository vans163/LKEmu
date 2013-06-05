using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.model
{
    public class Point2D
    {
        private int m_X;
        private int m_Y;
        public bool walkable;

        public static readonly Point2D Zero = new Point2D(0, 0);

        public Point2D(int x, int y)
        {
            m_X = x;
            m_Y = y;
            walkable = true;
        }

        public int X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        public int Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }
    }
}
