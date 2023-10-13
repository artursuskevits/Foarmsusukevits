using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Foarmsusukevits
{
    public class Triangle
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double ha { get; set; }

        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }

        public Triangle(double A, double B, double C, double Ha)
        {
            a = A;
            b = B;
            c = C;
            ha = Ha;
        }

        public (string,string,string) ShowSides(double a, double b,double c)
        {
            return (Convert.ToString(a), Convert.ToString(b), Convert.ToString(c)); 

        }
        public double foundTrinagleP(double a, double b, double c)
        {
            double p = a + b + c;
            return p;
        }

        public double foundTraingleS(double a, double b, double c)
        {
            
            double p = (a + b + c) / 2;
            double s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return s;
        }

        public double foundTriangleHa()
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            double h =(2*s)/a;
            return h;
        }

        public double NewAValue 
        { 
            get
            { return a; }
            set
            { a = value; }   
        }
        public double NewBValue
        {
            get
            { return b; }
            set
            { b = value; }
        }
        public double NewCValue
        {
            get
            { return c; }
            set
            { c = value; }
        }

        public double NewHaValue
        {
            get
            { return ha; }
            set
            { ha = value; }
        }

        public bool ItIsTriangle
        { 
            get
            {
                if ((a < b + c) && (b < a + c) && (c < a + b))
                    return true;
                else return false;
                
            }
        }

    }
}
