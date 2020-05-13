using System;

namespace MandelbrotSetWpf
{
    public class CNumber
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        static ComplexNumber i = new ComplexNumber();
        public CNumber(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }
        public double Length()
        {
            double doubleX = Convert.ToDouble(X);
            double sqaureX = Math.Pow(doubleX, 2);
            double doubleY = Convert.ToDouble(Y);
            double sqaureY = Math.Pow(doubleY, 2);
            double result = Math.Sqrt(sqaureX + sqaureY);
            return result;
        }
        public static CNumber operator *(CNumber c1, CNumber c2)
        {
            double squareX = Math.Pow(Convert.ToDouble(c1.X), 2);
            double squareY = Math.Pow(Convert.ToDouble(c1.Y), 2);
            double newX = squareX - squareY;
            double newY = 2 * c1.X * c1.Y;
            return new CNumber(newX, newY);
        }
        public static CNumber operator +(CNumber c1, CNumber c2)
        {
            return new CNumber(c1.X + c2.X, c1.Y + c2.Y);
        }
    }
}