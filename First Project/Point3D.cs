using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class Point3D:ICloneable,IComparable
    {
        #region  1.Define 3D Point Class and the basic Constructors (use chaining in constructors).

        #region Full Properties
        private int x;
        private int y;
        private int z;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Z
        {
            get { return z; }
            set { z = value; }
        }

        #endregion

        #region Constructor 

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
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
            return $"point coordinates ({X},{Y},{Z}) ";

        }

        #endregion
        #region Read from the User the Coordinates for 2 points P1, P2 (Check the input using try Pares, Parse, Convert).
        public static Point3D GeneratePoint()
        {
            int x, y, z;
            do
            {
                
            Console.WriteLine("Enter the x coordinate");
            }
            while (!int.TryParse(Console.ReadLine(), out x));

            do
            {

                Console.WriteLine("Enter the Y coordinate");
            }
            while (!int.TryParse(Console.ReadLine(), out y));
            do
            {

                Console.WriteLine("Enter the Z coordinate");
            }
            while (!int.TryParse(Console.ReadLine(), out z));
            return new Point3D(x, y, z);
            #endregion

        }
        #region 4.Try to use == If(P1 == P2) Does it work properly?
        public static bool operator == (Point3D point1, Point3D point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y && point1.Z == point2.Z;
        }
        public static bool operator !=(Point3D point1, Point3D point2)
        {
            return !(point1.X == point2.X);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Point3D point)
            {
                return x == point.x && y == point.y && z == point.z;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
        #endregion

        #region 5.Define an array of points and sort this array based on X & Y coordinates
        public static void PrintArray(Point3D[] pointArr)
        {
            for (int i = 0; i < pointArr.Length; i++)
            {
                Console.WriteLine(pointArr[i]);
            }
        }
        #endregion
        #region   sort this array based on X & Y
        public static void SortArray(Point3D[] pointArr)
        {
            Array.Sort(pointArr);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1; 
            if (obj is Point3D point)
            {
                if (X > point.X)
                    return 1;
                if (X < point.X)
                    return -1;
                if (Y > point.Y)
                    return 1;
                if (Y < point.Y)
                    return -1;
                return 0;
            }
            throw new ArgumentException("Object is not a Point3D");
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
