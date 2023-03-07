using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraVKostky
{
    internal class Round
    {
        private int _total = 0;
        private Dice[] _dices;

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
        
        public Dice[] Dices
        {

            get { return _dices; }
            set {
                if(value.Length == 5)
                {
                    _dices = value;
                }
            }

        }

        public Round(Dice[] d)
        {
            _dices = d;
        }

        public void Roll()
        {
                int t = 0;
                foreach (Dice i in Dices)
                {

                    i.Roll();
                    t += i.Value;

                }

                Total = t;

        }

        public string State()
        {
            string message = "";
            for(int i = 0; i < 5; i++)
            {
               message += "Kostka č." + (i+1) + " | Padlo: " + _dices[i].Value.ToString() + "\n";
            }

            return message;

        }

        public int[] Value()
        {

            int[] list = new int[5];
            for(int g = 0; g < 5; g++)
            {
                list[g] = _dices[g].Value;
            }
            return list;
        }

        public void SetLock(int cislokostky, bool zamknout)
        {
            if (cislokostky < Dices.Length)
            {
                Dices[cislokostky - 1].Locked = zamknout;
            }
        }

        public void SwitchLock(int cislokostky)
        {
            if (cislokostky < Dices.Length)
            {
                Dices[cislokostky - 1].Locked ^= true;
            }

        }

    }
}
