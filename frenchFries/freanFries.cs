using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace frenchFries
{
    delegate void eventHandler();
    class frenchFries
    {
        private int _mountOfFrenchFries;
        public event eventHandler eatFrenchFries;
        public event eventHandler nothingToEat;
        private Timer t = null;
        public int mount
        {
            get
            {
                return _mountOfFrenchFries;
            }
            set
            {
                _mountOfFrenchFries = value;
            }
        }

        public void beginEating()
        {
            t = new Timer(eat, null, 0, 1000);
        }

        public void eat(object o)
        {
            _mountOfFrenchFries -= 2;
            if (eatFrenchFries != null)
            {
                eatFrenchFries();
            }

            if (_mountOfFrenchFries <= 0)
            {
                if (nothingToEat != null)
                {
                    nothingToEat();
                }

                t.Dispose();
                t = null;
            }
        }
    }

    class people
    {
        private string _name = "";
        private int cnt = 0;
        public frenchFries f = new frenchFries();
        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public void eating(int mount)
        {
            f.mount = mount;
            cnt = mount;
            f.eatFrenchFries += F_eatFrenchFries;
            f.nothingToEat += F_nothingToEat;
            f.beginEating();
        }

        private void F_nothingToEat()
        {
            Console.WriteLine("poor {0} has nothing to eat", name);
        }

        private void F_eatFrenchFries()
        {
            Console.Write(string.Format("{0, 3}%\r",f.mount*100/cnt));
        }
    }
}
