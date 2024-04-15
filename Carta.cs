using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarajaCartas
{
    public enum PaloEnum { Corazón, Rombo, Pica, Trébol };
    public enum ValorEnum { As, Dos, Tres, Cuatro, Cinco, Seis, Siete, Ocho, Nueve, Diez, Jota, Reina , Rey }  
    public class Carta
    {
        PaloEnum _palo;
        ValorEnum _valor;
        public PaloEnum Palo { get => _palo; set => _palo = value; }
        public ValorEnum Valor { get => _valor; set => _valor = value; }
        public int Cuenta
        {
            get
            {
                switch (_valor)
                {
                    case ValorEnum.As:
                        return 1;
                    case ValorEnum.Dos:
                        return 2;
                    case ValorEnum.Tres:
                        return 3;
                    case ValorEnum.Cuatro:
                        return 4;
                    case ValorEnum.Cinco:
                        return 5;
                    case ValorEnum.Seis:
                        return 6;
                    case ValorEnum.Siete:
                        return 7;
                    case ValorEnum.Ocho:
                        return 8;
                    case ValorEnum.Nueve:
                        return 9;
                    case ValorEnum.Diez:
                        return 10;
                    case ValorEnum.Jota:
                        return 10;
                    case ValorEnum.Reina:
                        return 10;
                    case ValorEnum.Rey:
                        return 10;
                    default:
                        return 0;
                }
            }
        }
        public Carta(PaloEnum palo, ValorEnum valor)
        {
            this._palo = palo;
            this._valor = valor;
        }
        public void DibujarCarta(int x, int y, bool oculta)
        {
            string valorString;
            string paloString;

            switch (_valor)
            {
                case ValorEnum.As:
                    valorString = "A";
                    break;
                case ValorEnum.Dos:
                    valorString = "2";
                    break;
                case ValorEnum.Tres:
                    valorString = "3";
                    break;
                case ValorEnum.Cuatro:
                    valorString = "4";
                    break;
                case ValorEnum.Cinco:
                    valorString = "5";
                    break;
                case ValorEnum.Seis:
                    valorString = "6";
                    break;
                case ValorEnum.Siete:
                    valorString = "7";
                    break;
                case ValorEnum.Ocho:
                    valorString = "8";
                    break;
                case ValorEnum.Nueve:
                    valorString = "9";
                    break;
                case ValorEnum.Diez:
                    valorString = "10";
                    break;
                case ValorEnum.Jota:
                    valorString = "J";
                    break;
                case ValorEnum.Reina:
                    valorString = "Q";
                    break;
                case ValorEnum.Rey:
                    valorString = "K";
                    break;
                default:
                    valorString = "?";
                    break;
            }

            switch (_palo)
            {
                case PaloEnum.Corazón:
                    paloString = "♥";
                    break;
                case PaloEnum.Rombo:
                    paloString = "♦";
                    break;
                case PaloEnum.Pica:
                    paloString = "♠";
                    break;
                case PaloEnum.Trébol:
                    paloString = "♣";
                    break;
                default:
                    paloString = "?";
                    break;
            }

            if (oculta)
            {
                WriteAt($" _______ ", x, y++, true);
                WriteAt($"|       |", x, y++, true);
                WriteAt($"| * * * |", x, y++, true);
                WriteAt($"|  * *  |", x, y++, true);
                WriteAt($"| * * * |", x, y++, true);
                WriteAt($"|_______|", x, y++, true);
            }
            else
            {
                WriteAt($" _______ ", x, y++, true);
                if (valorString == "10")
                    WriteAt($"|{valorString}     |", x, y++, true);
                else
                    WriteAt($"|{valorString}      |", x, y++, true);
                WriteAt($"|       |", x, y++, true);
                WriteAt($"|   {paloString}   |", x, y++, true);
                WriteAt($"|       |", x, y++, true);
                WriteAt($"|_______|", x, y++, true);
            }
        }
        static void WriteAt(string s, int x, int y, bool line)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            if (line)
                Console.WriteLine(s);
            else
                Console.Write(s);
        }
    }
}
