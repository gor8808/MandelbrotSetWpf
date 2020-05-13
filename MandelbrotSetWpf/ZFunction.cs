using System;


namespace MandelbrotSetWpf
{
    public class ZFunction
    {
        public int Z0 = 0;
        public CNumber ZValue;
        public ZFunction(CNumber c)
        {
            ZValue = c;
        }
        public ZFunction(int i)
        {
            ZValue = new CNumber(0, 0);
        }
        public double Length
        {
            get
            {
                return ZValue.Length();
            }
        }
        public void Print()
        {
            if (ZValue.Y < 0)
            {
                Console.WriteLine($"{ZValue.X} {ZValue.Y}i");
            }
            else
            {
                Console.WriteLine($"{ZValue.X} + {ZValue.Y}i");
            }
        }
        public static ZFunction operator +(ZFunction ZN, CNumber c)
        {
            return new ZFunction(ZN.ZValue + c);
        }
        public static ZFunction operator *(ZFunction Z1, ZFunction Z2)
        {
            return new ZFunction(Z1.ZValue * Z2.ZValue);
        }
    }
}
