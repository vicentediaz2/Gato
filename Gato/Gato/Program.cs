using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Gato
{

    public class IA
    {
        Random rnm = new Random();
        public int juegoIA, decoX, decoY, jugadaIAX, jugadaIAY, ran, ran1,intentos=0;

        public int JugadaIA()
        {   //MAQUINA --V1
            return juegoIA = rnm.Next(1, 10);
        }
        public void Decodificar(int juegoUsuario)
        {   //trasforma el input del usuario en coordenadas --v2
            switch (juegoUsuario)
            {
                case 1: decoX = 0; decoY = 0; break;
                case 2: decoX = 0; decoY = 1; break;
                case 3: decoX = 0; decoY = 2; break;
                case 4: decoX = 1; decoY = 0; break;
                case 5: decoX = 1; decoY = 1; break;
                case 6: decoX = 1; decoY = 2; break;
                case 7: decoX = 2; decoY = 0; break;
                case 8: decoX = 2; decoY = 1; break;
                case 9: decoX = 2; decoY = 2; break;
                default: break;

            }
        }

        public void JugadaBloIA(char[,,] arreglo,int intentosHehcos)
        {   //opera las coordenadas para "responder" a la jugada del usuario --v2
            jugadaIAX = decoX;
            jugadaIAY = decoY;
            if (intentosHehcos==1)
            {
                intentos += 1;
            }
            else if (intentosHehcos==0)
            {
                intentos = 0;
            }
            ran = rnm.Next(1, 3);
            if (intentos >= 6)
            {
                Decodificar(JugadaIA());
                jugadaIAX = decoX;
                jugadaIAY = decoY;
            }

            if (arreglo[0, 0, 0] != ' ' && arreglo[1, 1, 0] == ' ')
            {
                if (arreglo[0, 0, 0] == arreglo[2, 2, 0] )
                {
                    jugadaIAX = 1;
                    jugadaIAY = 1;
                    ran = 0;
                    
                }
            }
            else if (arreglo[2, 0, 0] != ' ' && arreglo[1,1,0] == ' ')
            {
                if (arreglo[2, 0, 0] == arreglo[0, 2, 0] )
                {
                    jugadaIAX = 1;
                    jugadaIAY = 1;
                    ran = 0;
                }
            }
            switch (ran)
            {
                case 1:
                    if (decoX == 2)
                    {
                        jugadaIAX = (decoX - 1); 
                    }
                    else if (decoX == 0)
                    {
                        jugadaIAX = (decoX + 1);
                    }
                    else if (decoX == 1)
                    {
                        ran1 = rnm.Next(1, 3);
                        if (ran1 == 1)
                        {
                            jugadaIAX = (decoX + 1);
                        }
                        else
                        {
                            jugadaIAX = (decoX - 1);
                        }
                    }
                    break;
                case 2:
                    if (decoY == 2)
                    {

                        jugadaIAY = (decoY - 1);
                    }
                    else if (decoY == 0)
                    {
                        jugadaIAY = (decoY + 1);
                    }
                    else if (decoY == 1)
                    {
                        ran1 = rnm.Next(1, 3);
                        if (ran1 == 1)
                        {
                            jugadaIAY = (decoY + 1);
                        }
                        else
                        {
                            jugadaIAY = (decoY - 1);
                        }
                    }
                    break;
                default: break;
            }
        }

    }
    class Gato
    {
        IA ia = new IA();
        public int cont = 2, juego, dificultad, victoriasX, victoriasO, empate;
        public char jugada; //guarda 'x' || 'o'
        public bool fin = false; //se utiliza para limpiar el tablero cuando una partida termina 


        public char[,,] arreglo3D = new char[3, 3, 2]
        {

            { { ' ', '1' }, { ' ', '2' } , { ' ', '3' } },
            { { ' ', '4' }, { ' ', '5' } , { ' ', '6' } },
            { { ' ', '7' }, { ' ', '8' } , { ' ', '9' } },


        };
        public Gato()
        {
            Console.WriteLine("╔═════════════════════════════╗" +
                            "\n╠══════════   Gato   ═════════╣" +
                            "\n╚═════════════════════════════╝");
            MostrarTablero(1);
            String linea;
            do
            {
                Console.WriteLine("Ingrese que dificultad quiere jugar:  \n\t1.- Usuario vs Usuario\n\t2.- Usuario vs Maquina --v1" +
                                "\n\t3.- Usuario vs Maquina --v2\n\t/.- Usuario vs Maquina --v3\n\t5.- Maquina --v1 vs Maquina --v1" +
                                "\n\t6.- Maquina --v2 vs Maquina --v2\n\t7.- Maquina --v1 vs Maquina --v2\n\t8.- Maquina --v2 vs Maquina --v1");
                linea = Console.ReadLine();
            } while (!int.TryParse(linea, out dificultad));
            //dificultad = (int.Parse(Console.ReadLine()));

        }
        
        public void MostrarTablero(int x) //x==0 es tablero de juego x==1 es "interfaz de digitos" 
        {
            //Muestra por pantalla el tablero de juego 
            Console.WriteLine("\n\t     " + arreglo3D[0, 0, x] + "|" + arreglo3D[0, 1, x] + "|" + arreglo3D[0, 2, x] +
                                "\n\t     ─┴─┴─" +
                                "\n\t     " + arreglo3D[1, 0, x] + "|" + arreglo3D[1, 1, x] + "|" + arreglo3D[1, 2, x] +
                                "\n\t     ─┬─┬─" +
                                "\n\t     " + arreglo3D[2, 0, x] + "|" + arreglo3D[2, 1, x] + "|" + arreglo3D[2, 2, x]);

        }
        public void IngresarTablero(int juego, char jugada, int UM) //UM quien va a validar, usuario o maquina
        {
            //trasforma la jugada de "digito" a "coordenadas"
            switch (juego)
            {
                case 1: Validar(0, 0, UM); break;
                case 2: Validar(0, 1, UM); break;
                case 3: Validar(0, 2, UM); break;
                case 4: Validar(1, 0, UM); break;
                case 5: Validar(1, 1, UM); break;
                case 6: Validar(1, 2, UM); break;
                case 7: Validar(2, 0, UM); break;
                case 8: Validar(2, 1, UM); break;
                case 9: Validar(2, 2, UM); break;
                case 10: MostrarTablero(1); IngresarTablero(IngresarJugada(), jugada, 1); break;

                default: Console.WriteLine("Jugada mas ingresada"); IngresarTablero(IngresarJugada(), jugada, 1); break;

            }
        }
        public void Validar(int x, int y, int UM) //UM quien va a validar, usuario o maquina
        {
            //valida que la jugada se haga en un lugar valido
            switch (UM)
            {
                case 1: //USUARIO
                    if (arreglo3D[x, y, 0] == ' ')
                    {
                        arreglo3D[x, y, 0] = jugada;
                        cont++;
                    }
                    else
                    {
                        Console.WriteLine("ya hay un simbolo en esta pocicion");
                        IngresarTablero(IngresarJugada(), jugada, 1);
                    }
                    break;
                case 2: //MAQUINA --v1
                    if (arreglo3D[x, y, 0] == ' ')
                    {
                        arreglo3D[x, y, 0] = jugada;
                        cont +=1;
                    }
                    else
                    {
                        //Console.WriteLine("ya hay un simbolo en esta pocicion (IA)v2");
                        IngresarTablero(ia.JugadaIA(), jugada, 2);
                    }
                    break;
                case 3: //MAQUINA --v2
                    if (arreglo3D[x, y, 0] == ' ')
                    {
                        arreglo3D[x, y, 0] = jugada;
                        cont += 1;
                    }
                    else
                    {
                        //Console.WriteLine("ya hay un simbolo en esta pocicion (IA)v3");
                        ia.Decodificar(juego);
                        ia.JugadaBloIA(arreglo3D,1);
                        Validar(ia.jugadaIAX, ia.jugadaIAY, 3);
                    }
                    break;
                default:
                    break;
            }
        }
        public void Jugador()
        {   
            //cambia el simbolo 
            if (cont % 2 == 0)
            {
                jugada = 'x';
            }
            else
            {
                jugada = 'o';
            }

        }
        public int IngresarJugada()
        {
            //input para las jugadas del Usuario
            String linea;
            do
            {
                Console.WriteLine("Ingrese un numero del 1 - 9 ");
                linea = Console.ReadLine();
            } while (!int.TryParse(linea, out juego));
            return juego;
        }
        public void Ganador()
        {   // if's para decidir quien gana

            if (arreglo3D[0, 0, 0].Equals(arreglo3D[0, 1, 0]) && arreglo3D[0, 1, 0].Equals(arreglo3D[0, 2, 0]))
            {
                if (arreglo3D[0, 0, 0] != ' ') { Console.WriteLine("- - - - - - - - - - - - -\n\t" + arreglo3D[0, 0, 0] + "  Es el ganador" +
                    "\n- - - - - - - - - - - - -"); Terminar(arreglo3D[0, 0, 0]); }
            }
            if (arreglo3D[1, 0, 0].Equals(arreglo3D[1, 1, 0]) && arreglo3D[1, 1, 0].Equals(arreglo3D[1, 2, 0]))
            {
                if (arreglo3D[1, 0, 0] != ' ') { Console.WriteLine("- - - - - - - - - - - - -\n\t" + arreglo3D[1, 0, 0] + "  Es el ganador" +
                    "\n- - - - - - - - - - - - -"); Terminar(arreglo3D[1, 0, 0]); }
            }
            if (arreglo3D[2, 0, 0].Equals(arreglo3D[2, 1, 0]) && arreglo3D[2, 1, 0].Equals(arreglo3D[2, 2, 0]))
            {
                if (arreglo3D[2, 0, 0] != ' ') { Console.WriteLine("- - - - - - - - - - - - -\n\t" + arreglo3D[2, 0, 0] + "  Es el ganador\n" + 
                    "- - - - - - - - - - - - -"); Terminar(arreglo3D[2, 0, 0]); }
            }
            if (arreglo3D[0, 0, 0].Equals(arreglo3D[1, 0, 0]) && arreglo3D[1, 0, 0].Equals(arreglo3D[2, 0, 0]))
            {
                if (arreglo3D[0, 0, 0] != ' ') { Console.WriteLine("- - - - - - - - - - - - -\n\t" + arreglo3D[0, 0, 0] + "  Es el ganador\n" + 
                    "- - - - - - - - - - - - -"); Terminar(arreglo3D[0, 0, 0]); }
            }
            if (arreglo3D[0, 1, 0].Equals(arreglo3D[1, 1, 0]) && arreglo3D[1, 1, 0].Equals(arreglo3D[2, 1, 0]))
            {
                if (arreglo3D[0, 1, 0] != ' ') { Console.WriteLine("- - - - - - - - - - - - -\n\t" + arreglo3D[0, 1, 0] + "  Es el ganador\n" + 
                    "- - - - - - - - - - - - -"); Terminar(arreglo3D[0, 1, 0]); }
            }
            if (arreglo3D[0, 2, 0].Equals(arreglo3D[1, 2, 0]) && arreglo3D[1, 2, 0].Equals(arreglo3D[2, 2, 0]))
            {
                if (arreglo3D[0, 2, 0] != ' ') { Console.WriteLine("- - - - - - - - - - - - -\n\t" + arreglo3D[0, 2, 0] + "  Es el ganador\n" +
                    "- - - - - - - - - - - - -"); Terminar(arreglo3D[0, 2, 0]); }
            }
            if (arreglo3D[0, 0, 0].Equals(arreglo3D[1, 1, 0]) && arreglo3D[1, 1, 0].Equals(arreglo3D[2, 2, 0]))
            {
                if (arreglo3D[1, 1, 0] != ' ') { Console.WriteLine("- - - - - - - - - - - - -\n\t" + arreglo3D[1, 1, 0] + "  Es el ganador\n" +
                    "- - - - - - - - - - - - -"); Terminar(arreglo3D[1, 1, 0]); }
            }   
            if (arreglo3D[2, 0, 0].Equals(arreglo3D[1, 1, 0]) && arreglo3D[1, 1, 0].Equals(arreglo3D[0, 2, 0]))
            {
                if (arreglo3D[1, 1, 0] != ' ') { Console.WriteLine("- - - - - - - - - - - - -\n\t" + arreglo3D[1, 1, 0] + "  Es el ganador\n" +
                    "- - - - - - - - - - - - -"); Terminar(arreglo3D[1, 1, 0]); }
            }
            if ((arreglo3D[0, 0, 0] != ' ') && (arreglo3D[0, 1, 0] != ' ') && (arreglo3D[0, 2, 0] != ' ') &&
                (arreglo3D[1, 0, 0] != ' ') && (arreglo3D[1, 1, 0] != ' ') && (arreglo3D[1, 2, 0] != ' ') &&
                (arreglo3D[2, 0, 0] != ' ') && (arreglo3D[2, 1, 0] != ' ') && (arreglo3D[2, 2, 0] != ' '))
            {
                Terminar(' ');
            }
        }

        public void Terminar (char simbolo) 
        {   //termina la partida y limpia el tablero 
            if (simbolo =='x')
            {
                victoriasX += 1;
                Console.WriteLine("X ha ganado " + victoriasX + " veces\nO ha ganado " + victoriasO + " veces\n" + empate + " veces hubo empate");
            }
            else if (simbolo == 'o')
            {
                victoriasO += 1;
                Console.WriteLine("X ha ganado " + victoriasX + " veces\nO ha ganado " + victoriasO + " veces\n" + empate + " veces hubo empate");
            }
            else
            {
                empate += 1;
                Console.WriteLine("- - - - Empate - - - -");
                Console.WriteLine("X ha ganado " + victoriasX + " veces\nO ha ganado " + victoriasO + " veces\n" + empate + " veces hubo empate");
            }
            //se limpia el tablero para nueva partida
            arreglo3D[0, 0, 0] = ' '; arreglo3D[0, 1, 0] = ' '; arreglo3D[0, 2, 0] = ' ';
            arreglo3D[1, 0, 0] = ' '; arreglo3D[1, 1, 0] = ' '; arreglo3D[1, 2, 0] = ' ';
            arreglo3D[2, 0, 0] = ' '; arreglo3D[2, 1, 0] = ' '; arreglo3D[2, 2, 0] = ' ';
            cont = 2;
            ia.intentos = 0;
            fin = true;
        }


        static void Main(string[] args)
        {
            Gato g = new Gato();
            IA ia = new IA();
            int conI = 0;
            switch (g.dificultad)
            {
                case 1:
                    do
                    {   //USUARIO VS USUARIO
                        g.Ganador();
                        if (g.fin) { g.fin = false; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        g.IngresarTablero(g.IngresarJugada(), g.jugada, 1);
                        Console.Clear();
                    } while (true);

                case 2:
                    do
                    {   //USUARIO VS MAQUINA --v1
                        g.Ganador();
                        if (g.fin) { g.fin = false; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        g.IngresarTablero(g.IngresarJugada(), g.jugada, 1);
                        Console.Clear();
                        g.Ganador();
                        if (g.fin) { g.fin = false; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        g.IngresarTablero(ia.JugadaIA(), g.jugada, 2);
                        Console.Clear();
                    } while (true);

                case 3:
                    do
                    {   //USUARIO VS MAQUINA --v2
                        g.Ganador();
                        if (g.fin) { g.fin = false; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        g.IngresarTablero(g.IngresarJugada(), g.jugada, 1);
                        Console.Clear();
                        g.Ganador();
                        if (g.fin) { g.fin = false; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        ia.Decodificar(g.juego);
                        ia.JugadaBloIA(g.arreglo3D,0);
                        g.Validar(ia.jugadaIAX, ia.jugadaIAY, 3);
                        Console.Clear();
                    } while (true);

                case 5:
                    do
                    {   //MAQUINA --v1 VS MAQUINA --v1
                        g.Ganador();
                        if (g.fin) { g.fin = false; conI++;  continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        g.IngresarTablero(ia.JugadaIA(), g.jugada, 2);
                        Thread.Sleep(200);
                        Console.Clear();
                        g.Ganador();
                        if (g.fin) { g.fin = false; conI++;  continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        g.IngresarTablero(ia.JugadaIA(), g.jugada, 2);
                        Thread.Sleep(200);
                        Console.Clear();
                    } while (conI <= 1000);
                    break;
                case 6:
                    do
                    {   //MAQUINA --v2 vs MAQUINA --v2
                        g.Ganador();
                        if (g.fin) { g.fin = false; conI++; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        ia.Decodificar(g.juego);
                        ia.JugadaBloIA(g.arreglo3D, 0);
                        g.Validar(ia.jugadaIAX, ia.jugadaIAY, 3);
                        Thread.Sleep(200);
                        Console.Clear();
                        g.MostrarTablero(0);
                        g.Ganador();
                        if (g.fin) { g.fin = false; conI++; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        ia.Decodificar(g.juego);
                        ia.JugadaBloIA(g.arreglo3D, 0);
                        g.Validar(ia.jugadaIAX, ia.jugadaIAY, 3);
                        Thread.Sleep(200);
                        Console.Clear();
                    } while (conI <= 1000);
                    break;
                case 7:
                    do
                    {   //MAQUINA --v1 vs MAQUINA --v2
                        g.MostrarTablero(0);
                        g.Ganador();
                        if (g.fin) { g.fin = false; conI++; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        g.IngresarTablero(ia.JugadaIA(), g.jugada, 2);
                        Thread.Sleep(200);
                        Console.Clear();
                        g.Ganador();
                        if (g.fin) { g.fin = false; conI++; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        ia.Decodificar(g.juego);
                        ia.JugadaBloIA(g.arreglo3D, 0);
                        g.Validar(ia.jugadaIAX, ia.jugadaIAY, 3);
                        Thread.Sleep(200);
                        Console.Clear();
                    } while (conI <= 1000);
                    break;
                case 8:
                    do
                    {   //MAQUINA --v2 vs MAQUINA --v1
                        g.Ganador();
                        if (g.fin) { g.fin = false; conI++; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        ia.Decodificar(g.juego);
                        ia.JugadaBloIA(g.arreglo3D, 0);
                        g.Validar(ia.jugadaIAX, ia.jugadaIAY, 3);
                        Thread.Sleep(200);
                        Console.Clear();
                        g.Ganador();
                        if (g.fin) { g.fin = false; conI++; continue; }
                        g.Jugador();
                        g.MostrarTablero(0);
                        g.IngresarTablero(ia.JugadaIA(), g.jugada, 2);
                        Thread.Sleep(200);
                        Console.Clear();
                    } while (conI <= 1000);
                    break;
                default:
                    break;
            }
        }
    }
}
