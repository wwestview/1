using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Fractional
{
    public class Frac
    {
        public struct MyFrac
        {
            public long nom, denom;
            public MyFrac(long nom_, long denom_)
            {
                int sign = 1;
                if ((double)nom_ / denom_ < 0)
                    sign = -1;

                long tnom_ = Math.Abs(nom_);
                long tdenom_ = Math.Abs(denom_);
                long gcd;
                while (true)
                {
                    if (tnom_ % tdenom_ == 0)
                    {
                        gcd = tdenom_;
                        break;
                    }
                    if (tdenom_ % tnom_ == 0)
                    {
                        gcd = tnom_;
                        break;
                    }
                    if (tnom_ > tdenom_)
                        tnom_ %= tdenom_;
                    else
                        tdenom_ %= tnom_;
                }
                nom = Math.Abs(nom_) / gcd * sign;
                denom = Math.Abs(denom_) / gcd;
            }
            public override string ToString()
            {
                return nom + "/" + denom;
            }

        }
       public string ToStringWithIntPart(MyFrac f)
        {
            string minus = "";
            if (f.nom < 0) minus = "-";
            long intPart = Math.Abs(f.nom) / f.denom;
            long nom = Math.Abs(f.nom) % f.denom;
            if (nom == 0) return $"{minus}({intPart})";
            if(intPart == 0) return $"{minus}({nom}/{f.denom})";
            return $"{minus}({intPart}+{nom}/{f.denom})";
        }

        public static double DoubleValue(MyFrac f)
        {
            return (double)f.nom / f.denom;
        }
        public static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom,
                              f1.denom * f2.denom);
        }
        public static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom,
                              f1.denom * f2.denom);

        }
        public static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }
        public static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }
        public static MyFrac CalcExpr1(int n)
        {
            MyFrac fr = new(0, 1);
            for (long i = 1; i <= n; i++)
            {

                fr = Plus(fr, new MyFrac(1, i * (i + 1)));
            }
            return fr;
        }
        public static MyFrac CalcExpr2(int n)
        {
            if (n == 1) return new MyFrac(1, 1);
            MyFrac fr = new(1, 1);
            for (long i = 2; i <= n; i++)
            {
                fr = Multiply(fr, Minus(new MyFrac(1, 1), new MyFrac(1, i * i)));
            }
            return fr;
        }
       public static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Frac frac = new Frac();
            Console.WriteLine("Введіть чисельник і знаменник першого дробу: ");
            long[] dataFrac1 = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            long nom1 = dataFrac1[0];
            long denom1 = dataFrac1[1];

            Console.WriteLine("Введіть чисельник і знаменник другого дробу: ");
            long[] dataFrac2 = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            long nom2 = dataFrac2[0];
            long denom2 = dataFrac2[1];

            MyFrac fr1 = new(nom1, denom1);
            MyFrac fr2 = new(nom2, denom2);

            Console.WriteLine("1 -  рядкове представлення  для першого дробу\n" +
                            "2 - дійсне значення для першого дробу\n" +
                            "3 - додавання\n" +
                            "4 - віднімання\n" +
                            "5 - множення\n" +
                            "6 - ділення\n" +
                            "7 - CalcExpr1\n" +
                            "8 - CalcExpr2");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine(frac.ToStringWithIntPart(fr1));
                    break;
                case 2:
                    Console.WriteLine(DoubleValue(fr1));
                    break;
                case 3:
                    Console.WriteLine(Plus(fr1, fr2));
                    break;
                case 4:
                    Console.WriteLine(Minus(fr1, fr2));
                    break;
                case 5:
                    Console.WriteLine(Multiply(fr1, fr2));
                    break;
                case 6:
                    Console.WriteLine(Divide(fr1, fr2));
                    break;
                case 7:
                    Console.WriteLine("Введіть n");
                    int n1 = int.Parse(Console.ReadLine());
                    Console.WriteLine(CalcExpr1(n1));
                    Console.WriteLine($"За формулою: {n1 / (n1 + 1.0)}");
                    break;
                case 8:
                    Console.WriteLine("Введіть n");
                    int n2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(CalcExpr1(n2));
                    Console.WriteLine($"За формулою: {(n2 + 1.0) / (n2 * 2)}");
                    break;
                default:
                    Console.WriteLine("Неправильний ввід");
                    break;

            }
        }
    }
}

