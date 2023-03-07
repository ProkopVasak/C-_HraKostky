using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HraVKostky
{
    internal class Game
    {
        private Dice[] _p1dices, _p2dices;
        private int _p1wins, _p2wins;
        private int _p1score = 0;
        private int _p2score = 0;
        private int _cntr = 0;
        private bool _end = false;

        public Dice[] P1dices
        {
            get { return _p1dices; }
            set { _p1dices = value; }
        }

        public Dice[] P2dices
        {
            get { return _p2dices; }
            set { _p2dices = value; }

        }

        public bool End
        {
            get { return _end; }
        }

        public int Cntr
        {
            get { return _cntr; }
        }

        public Game(Dice[] player1dices, Dice[] player2dices)
        {
            P1dices = player1dices;
            P2dices = player2dices;

        }

        private bool _p1plays = true;

        public string Next(int [] zamknout)
        {
            string zprava = "";
            _cntr++;

            Round r;
            if (_p1plays){
                r = new Round(P1dices);
            }
            else{
                r = new Round(P2dices);

            }

            foreach (int q in zamknout)
            {
                r.SetLock(q, true);
            }

            r.Roll();
            foreach (int q in zamknout)
            {
                r.SwitchLock(q);
            }
            int[] h= r.Value();

            int s = CountScore(h);


            if (_p1plays)
            {
                _p1score = s;
                zprava = "Hod č." + _cntr + " | hraje hráč č.1\n" + r.State();
            }
            else
            {
                _p2score = s;
                zprava = "Hod č." + _cntr + " | hraje hráč č.2\n" + r.State();
            }

            _p1plays ^= true;
            if (_cntr % 4 == 0)
            {
                if (_p1score > _p2score)
                {
                    _p1wins++;
                    zprava += "\nBod získává hráč č. 1";
                }
                else if(_p1score < _p2score)
                {
                    _p2wins++;
                    zprava += "\nBod získává hráč č. 2";
                }
                else
                {
                    zprava += "\nRemíza, bod nezískává nikdo";
                }

                if (_p1wins == 2 || _p2wins == 2)
                {
                    _end = true;
                }

            }

            if (_cntr == 12)
            {
                _end = true;
            }
            return zprava;

        }

        public string Vyhodnoceni()
        {
            if (_end)
            {
                if (_p1wins > _p2wins)
                {
                    return "Vyhrál hráč č.1 - Gratulujeme";
                }else if (_p1wins < _p2wins)
                {
                    return "Vyhrál hráč č.2 - Gratulujeme";
                }
                else
                {
                    return "Je to remíza, ale Ivan Kraus i tak prohrál";
                }
            }
            else
            {
                return "Ještě není konec hry";
            }
        }



        private static int CountValue(int[] arr, int num)
        {
            int counter = 0;

            foreach (int x in arr)
            {

                if (x == num)
                {
                    counter++;
                }

            }
            return counter;
        }

        private static int CountScore(int[] h)
        {
            int s = 1;
            int[] hodnoty = new int[6];

            for (int e = 0; e < hodnoty.Length; e++)
            {
                hodnoty[e] = CountValue(h, e + 1);
            }

            foreach (int o in hodnoty)
            {

                if (o == 5)
                {
                    s = 9;
                    break;
                }
                else if (o == 4)
                {
                    s = 8;
                    break;
                }
                else if (o == 3)
                {
                    foreach (int l in hodnoty)
                    {
                        if (l == 2)
                        {
                            s = 7;
                            break;
                        }

                    }

                    if (s != 7)
                    {
                        s = 4;
                    }

                    break;

                }
                else if (o == 2)
                {
                    int counter = 0;
                    foreach (int f in hodnoty)
                    {
                        if (f == 2)
                        {
                            counter++;
                        }
                    }

                    if (counter == 2)
                    {
                        s = 3;
                    }
                    else
                    {
                        s = 2;
                        foreach (int z in hodnoty)
                        {
                            if (z == 3)
                            {
                                s = 7;
                                break;
                            }
                        }
                    }

                    break;
                }
                else
                {
                    s = 1;
                }


            }

            if (hodnoty[0] == 0 && hodnoty[1] == 1 && hodnoty[2] == 1 && hodnoty[3] == 1 &&
                hodnoty[4] == 1 && hodnoty[5] == 1)
            {
                s = 6;
            }
            else if (hodnoty[0] == 1 && hodnoty[1] == 1 && hodnoty[2] == 1 && hodnoty[3] == 1 &&
                     hodnoty[4] == 1 && hodnoty[5] == 0)
            {
                s = 5;
            }

            return s;
        }
    }
}
