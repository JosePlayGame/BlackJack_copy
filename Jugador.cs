using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarajaCartas
{
    public class Jugador
    {
        int _cuenta;
        string _nombre;
        List<Carta> _mano = new();
        public string Nombre { get => _nombre; set => _nombre = value; }
        public List<Carta> Mano { get => _mano; set => _mano = value;}
        public int Cuenta { get => _cuenta; set => _cuenta = value; }

        public void Limpiar()
        {
            _mano.Clear();
        }
        public void MostrarMano(int x, int y, bool oculta)
        {
            foreach (var item in _mano)
            {
                item.DibujarCarta(x, y, oculta);
                x += 5;
            } 
        }
        public int ActualizarCuenta()
        {
            _cuenta = 0;
            foreach (Carta carta in Mano)
                this._cuenta += carta.Cuenta;
            return _cuenta;
        }
    }
}
