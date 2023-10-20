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

        public string ShowASide ()
        {
            return Convert.ToString(a);
        }
        public string ShowCSide()
        {
            return Convert.ToString(c);
        }
        public string ShowBSide()
        {
            return Convert.ToString(b);
        }

        public (string,string,string) ShowSides(double a, double b,double c)
        {
            return (Convert.ToString(a), Convert.ToString(b), Convert.ToString(c)); 

        }
        public string foundTrinagleP(double a, double b, double c)
        {
            double p = a + b + c;
            string pstr = p.ToString();
            return pstr;
        }

        public string foundTraingleS(double a, double b, double c)
        {
            
            double p = (a + b + c) / 2;
            double s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            string sstr = s.ToString();
            return sstr;
        }

        public string foundTriangleHbySnadoneside(double s)
        {
            double h = (2 * s) / a;
            h = Math.Round(h,2);
            string hstr = h.ToString();
            return hstr;
        }


        public string foundTriangleHa()
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            double h = (2 * s) / a;
            string hstr = h.ToString();
            return hstr;
        }

        public string foundtype(double a, double b, double c)
        {
            string type = "";
            if (a == b && b == c && c == a)
            {
                type = "Võrdkülgne kolmnurk";
            }
            else if (a == b || b == c || c == a)
            {
                type = "Tasakülgne kolmnurk";
            }
            else
            {
                type = "Skaleeni kolmnurk";
            }
            return type;
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
