using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraVKostky
{
    internal class Dice
    {

        private bool _locked;
        private int _size;
        private int _value = 0;

        public bool Locked
        {
            get { return _locked; }
            set { _locked = value; }
        }

        public int Size
        {
            get { return _size; }
            set { if(value > 0)
                {
                    _size = value;
                }
            }
        }

        public int Value
        {
            get { return _value; }
        }

        public Dice(int sides)
        {
            Size = sides;
        }

        public Dice()
        {
            Size = 6;
        }

        public int Roll()
        {
            if (!_locked)
            {
                _value = Random.Shared.Next(1, Size + 1);
                return _value;
            }
            else
            {
                return 0;
            }

        }

    }
}
