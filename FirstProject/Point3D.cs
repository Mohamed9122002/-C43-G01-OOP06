using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Point3D: IComparable, ICloneable
    {
        #region 1.Define 3D Point Class and the basic Constructors (use chaining in constructors).

        #region Full Properties
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private int z;

        public int Z
        {
            get { return z; }
            set { z = value; }
        }

        #endregion

        #region Constructors
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(int x, int y) : this(x, y, 1)

        {

        }

        public Point3D(int x) : this(x, 1, 1)
        {

        }

        public Point3D()
        {
            x = y = z = 0;
        }

        public Point3D(Point3D point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }
        #endregion

        #endregion

        #region 2.Override the ToString Function to produce this output:
        public override string ToString()
        {
            return $"point coordinates = ({X},{Y},{z})";
        }

        #endregion

        #region 3.Read from the User the Coordinates for a point (Check the input using try Pares, Parse, Convert). 
        public static Point3D GeneratePoint()
        {
            int x, y, z;
            //bool flag;

            do
            {
                Console.WriteLine("X= ");
                //flag = ;
            }
            while (!int.TryParse(Console.ReadLine(), out x));

            do
            {
                Console.WriteLine("Y= ");

            }
            while (!int.TryParse(Console.ReadLine(), out y));

            do
            {
                Console.WriteLine("Z= ");

            }
            while (!int.TryParse(Console.ReadLine(), out z));

            return new Point3D(x, y, z);
        }

        #endregion

        #region 4.Try to use ==      If(P1 ==P2)     Does it work properly? 



        public static bool operator ==(Point3D p1, Point3D p2)
        {
            return p1.x == p2.x && p1.y == p2.y && p1.z == p2.z;
        }

        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return p1.x != p2.x && p1.y != p2.y && p1.z != p2.z;
        }

        public override bool Equals(object obj)
        {
            Point3D p = (Point3D)obj;

            return x == p.x && y == p.y && z == p.z;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ x + y + z;
        }

        #endregion

        #region Print Array
        public static void PrintArray(Point3D[] pointArr)
        {
            for (int i = 0; i < pointArr.Length; i++)
            {
                Console.WriteLine(pointArr[i]);
            }
        }

        #endregion

        #region Sort array based on X & Y coordinates.

        public static void SortArray(Point3D[] pointArr)
        {
            Array.Sort(pointArr);
        }

        public int CompareTo(object obj)
        {
            Point3D p = (Point3D)obj;

            if (x > p.x)
                return 1;
            else if (x < p.x)
                return -1;
            else
            {
                if (y > p.y)
                    return 1;
                else if (y < p.y)
                    return -1;
                else
                    return 0;
            }
        }



        #endregion

        #region 6. Implement IClonable interface to be able to clone the object.
        public object Clone()
        {
            return new Point3D(this);
        }

        #endregion
    }
}
