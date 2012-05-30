using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Figura> lf = new List<Figura>();

            // adaugare cerc
            lf.Add(new Cerc(new Punct(1, 2), 10));

            // adaugare triunghi
            lf.Add(new Triunghi(new Punct(1, 2), new Punct(1, 3), new Punct(2, 4)));

            // adaugare patrat 
            lf.Add(new Patrat(new Punct(1, 2), new Punct(3, 4)));

            // polimorfism -
            foreach (Figura f in lf)
            {
                Console.WriteLine("");
                f.Help();
                f.Draw();
            }

            // apel metoda statica
            Console.WriteLine("");
            Figura.StaticFigura();
        }
    }

    public class Punct
    {
        int x, y;

        public Punct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Punct()
            : this(0, 0)
        {
        }

        // proprietate clasica
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        // suprascriere metode virtuale din clasa de baza
        public void Draw()
        {
            Console.WriteLine("Draw Punct ({0},{1}) - [apel metoda a instantei]", X, Y);
        }

        public void Help()
        {
            Console.WriteLine("Punct");
        }
    }

    public class Figura
    {
        Punct xy;

        public Figura()
            : this(new Punct())
        {

        }

        public Figura(Punct p)
        {
            xy = p;
        }

        public virtual void Draw()
        {
            Console.WriteLine("Figura : Draw");
        }

        public virtual void Help()
        {
            Console.WriteLine("Figura generica!");
        }

        /// <summary>
        /// Proprietate automatica
        /// Poate fi considerata si agregare deoarece Figura "are un tip Punct"
        /// Vom regasi aceasta in clasele derivate
        /// </summary>
        public Punct XY
        {
            get
            {
                return xy;
            }
            set
            {
                xy = value;
            }
        }

        // metoda statica
        public static void StaticFigura()
        {
            Console.WriteLine("[Apel metoda statica din Figura!]");
        }
    }

    /// <summary>
    /// Clasa Cerc
    /// </summary>
    public class Cerc : Figura
    {
        private int raza;

        public Cerc(Punct p, int r)
            : base(p)
        {
            raza = r;
        }

        // inlantuiri de apel constructori
        public Cerc(Punct p)
            : this(p, 1)
        { }
        public Cerc(int raza)
            : this(new Punct(), raza)
        { }

        public Cerc()
        {
            raza = 1;
        }

        // proprietate clasica
        public int Raza
        {
            get
            {
                return raza;
            }
            set
            {
                raza = value;
            }
        }

        // suprascriere metode virtuale din clasa de baza
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Draw Cerc ({0},{1}) si raza={2} - [apel metoda a instantei]", XY.X, XY.Y, this.raza);
        }

        public override void Help()
        {
            Console.WriteLine("Cerc");
        }
    }

    public class Triunghi : Figura
    {
        private Punct p1, p2, p3;

        public Triunghi(Punct v1, Punct v2, Punct v3)
        {
            p1 = v1;
            p2 = v2;
            p3 = v3;
        }

        public Triunghi()
            : this(new Punct(), new Punct(), new Punct())
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Draw Triunghi ({0},{1}), ({2},{3}), ({4},{5}) - [apel metoda a instantei]",
                p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);
        }

        public Punct P1
        {
            get
            {
                return p1;
            }
            set
            {
                p1 = value;
            }
        }

        public Punct P2
        {
            get
            {
                return p2;
            }
            set
            {
                p2 = value;
            }
        }

        public Punct P3
        {
            get
            {
                return p3;
            }
            set
            {
                p3 = value;
            }
        }
    }

    public class Patrat : Figura
    {
        private Punct p1, p2;

        public Patrat(Punct v1, Punct v2)
        {
            p1 = v1;
            p2 = v2;
        }

        public Patrat()
            : this(new Punct(), new Punct())
        {

        }

        public override void Draw()
        {
            Console.WriteLine("Draw Patrat ({0},{1}), ({2},{3}) - [apel metoda a instantei]",
                p1.X, p1.Y, p2.X, p2.Y);
        }

        public Punct P1
        {
            get
            {
                return p1;
            }
            set
            {
                p1 = value;
            }
        }

        public Punct P2
        {
            get
            {
                return p2;
            }
            set
            {
                p2 = value;
            }
        }
    }
}
