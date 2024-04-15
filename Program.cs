using System.Runtime.InteropServices;

namespace BarajaCartas
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Blackjack();
                Console.ReadKey();
            }
        }
        static void Blackjack()
        {
            ConsoleKeyInfo tecla;
            int tr = 500;

            Console.CursorVisible = false;
            //crea baraja
            Baraja baraja = new();
            baraja.Barajar();

            //crea cuprier
            Jugador cuprier = new();
            cuprier.Nombre = "Cuprier";

            //crea jugador
            Jugador plr1 = new();
            PedirNombre(plr1);

            //rondas
            PrimerEncabezado("EMPEZANDO");
            ActualizarJugador(plr1, false);
            ActualizarCuprier(cuprier, true);
           
            Mensaje("presione una tecla para comenzar");
            Console.ReadKey();

            ///primera ronda
            PrimerEncabezado("CONTINUANDO");
            baraja.ExtraerCarta(plr1,1);
            ActualizarJugador(plr1,false);

            Thread.Sleep(tr);

            baraja.ExtraerCarta(cuprier, 1);
            ActualizarCuprier(cuprier, true);
            
            Mensaje("primeras cartas repartidas | tecla para continuar");
            Console.ReadKey();

            ///segunda ronda
            PrimerEncabezado("CONTINUANDO");
            baraja.ExtraerCarta(plr1, 1);
            ActualizarJugador(plr1, false);

            Thread.Sleep(tr);

            baraja.ExtraerCarta(cuprier, 1);
            ActualizarCuprier(cuprier, false);

            PrimerEncabezado("JUGANDO");

            ///pedir cartas
            PrimerEncabezado("PEDIR");
            Mensaje("cualquier [tecla] para pedir o [espacio] para plantarse");
            ///jugador jugada
            while (plr1.Cuenta <= 21)
            {
                tecla = Console.ReadKey();
                if (tecla.Key != ConsoleKey.Spacebar)
                {
                    baraja.ExtraerCarta(plr1, 1);
                    ActualizarJugador(plr1, false);
                }
                else
                    break;
            }
            ///cuprier jugada
            if (plr1.Cuenta < 21)
            {
                Mensaje("el crupier esta jugando...");
                Thread.Sleep(tr);
                baraja.ExtraerCarta(cuprier, 1);
                ActualizarCuprier(cuprier, false);
            }
            else
                Mensaje("te has pasado! \\ has perdido!");
            if (cuprier.Cuenta > 21)
                Mensaje("el crupier se ha pasado y ha perdido | has ganado!");

            if (cuprier.Cuenta<=21 && plr1.Cuenta<=21)
            {
                if (cuprier.Cuenta > plr1.Cuenta)
                    Mensaje("gana el cuprier!");
                else if (cuprier.Cuenta < plr1.Cuenta)
                    Mensaje("tú ganas!");
                else
                    Mensaje("empate");
            }
        }

        static string PedirNombre(Jugador plr)
        {
            do
            {
                Console.Clear();
                Console.Write("Escriba su nombre de usuario para entrar en la sala: ");
                plr.Nombre = Console.ReadLine();
            } while (plr.Nombre == null);
            Console.Clear();
            return plr.Nombre;
        }
        static void PrimerEncabezado(string instruccion)
        {
            string pl = $"BLACKJACK PORTADA ALTA - {instruccion}";

            //vaciar
            Console.SetCursorPosition(Console.BufferWidth / 2 - (pl.Count()), 1);
            Console.WriteLine($"{new string(' ', 100)}");
            Console.SetCursorPosition(Console.BufferWidth / 2 - (pl.Count()), 2);
            Console.WriteLine($"{new string(' ', 100)}");
            Console.SetCursorPosition(Console.BufferWidth / 2 - (pl.Count()), 3);
            Console.WriteLine($"{new string(' ', 100)}");

            //rellenar
            Console.SetCursorPosition(Console.BufferWidth / 2 - (pl.Count() / 2), 1);
            Console.WriteLine($"+{new string('-', pl.Count()-2)}+");
            Console.SetCursorPosition(Console.BufferWidth / 2 - (pl.Count()/2), 2);
            Console.Write(pl);
            Console.SetCursorPosition(Console.BufferWidth / 2 - (pl.Count() / 2), 3);
            Console.WriteLine($"+{new string('-', pl.Count()-2)}+");
        }
        static void ActualizarJugador(Jugador plr, bool oculta)
        {
            int left = 1;
            int top = 5;

            Console.SetCursorPosition(left, top);
            plr.ActualizarCuenta();
            Console.Write($"{plr.Nombre.ToUpper()} | {plr.Cuenta}");
            plr.MostrarMano(left, top+1, oculta);
        }
        static void ActualizarCuprier(Jugador cuprier, bool oculta)
        {
            int left = Console.BufferWidth - 40;
            int top = 5;

            Console.SetCursorPosition(left, top);
            cuprier.ActualizarCuenta();

            string cuenta;
            if (oculta == true)
                cuenta = "?";
            else
                cuenta = cuprier.Cuenta.ToString();

            Console.Write($"{cuprier.Nombre.ToUpper()} | {cuenta}");
            cuprier.MostrarMano(left, top + 1, oculta);
        }
        static void Mensaje(string acc)
        {
            string accln = $"// {acc} \\\\";

            //vaciar
            Console.SetCursorPosition(1, 20);
            Console.WriteLine($"{new string(' ',100)}");
            Console.SetCursorPosition(1, 21);
            Console.WriteLine($"{new string(' ', 100)}");
            Console.SetCursorPosition(1, 22);
            Console.WriteLine($"{new string(' ', 100)}");

            //rellenar
            Console.SetCursorPosition(1, 20);
            Console.WriteLine($"+{new string('-', accln.Count()-2)}+");
            Console.SetCursorPosition(1, 21);
            Console.WriteLine($"{accln}");
            Console.SetCursorPosition(1, 22);
            Console.WriteLine($"+{new string('-', accln.Count()-2)}+");
        }
    }
}