using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Project
{
    internal class Maths
    {
        public static int Adds (int x , int y)
        {
            return x + y;
        }
       public static int Sub (int x , int y)
        {

            return x - y;
        }
        public static int Mul(int x, int y)
        {
            return x * y;
        }

        public static double Divid(int x, int y)
        {
            if (y == 0)
                return 0;
            return x / y;
        }

    }
}
