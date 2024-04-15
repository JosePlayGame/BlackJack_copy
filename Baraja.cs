using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarajaCartas
{
    public class Baraja
    {
        List<Carta> _mazo;
        public List<Carta> Mazo { get => _mazo; set => _mazo = value; }
        public Baraja()
        {
            _mazo = new List<Carta>();
            foreach (PaloEnum i in Enum.GetValues(typeof(PaloEnum)))
            {
                foreach (ValorEnum v in Enum.GetValues(typeof(ValorEnum)))
                {
                    Carta NuevaCarta = new(i, v);
                    _mazo.Add(NuevaCarta);
                }
            }
        }
        public void MostrarBaraja(byte x, byte y, bool oculta)
        {
            foreach (var item in _mazo)
            {
                item.DibujarCarta(x, y, oculta);
                x += 5;
            }
        }
        public void Barajar()
        {
            Random rnd = new Random();
            int n = _mazo.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);

                Carta temp = _mazo[k];
                _mazo[k] = _mazo[n];
                _mazo[n] = temp;
            }
        }
        public void ExtraerCarta(Jugador destino, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                destino.Mano.Add(_mazo[_mazo.Count-1]);
                _mazo.Remove(_mazo[_mazo.Count-1]);
            }
        }
    }
}
