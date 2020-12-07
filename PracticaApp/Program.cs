using System;

namespace PracticaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logo();
           
           
            int contadorPc, contadorPlayer, tamF, tamC, f, c;
            //int contadorDisparosPc, contadorDisparosPlayer;
            int opcion;
            int contadorSoldado, contadorTanque, contadorAvion,contadorRonda;
            tamC = 4;
            tamF = 4;
            contadorPc = 0;
            contadorPlayer = 0;
            //contadorDisparosPc = 0;
            //contadorDisparosPlayer = 0;
            contadorSoldado = 0;
            contadorTanque = 0;
            contadorAvion = 0;
            contadorRonda = 1;

            int[,] pc = new int[tamF, tamC];
            int[,] player = new int[tamF, tamC];

            Random numRandom = new Random();

            Console.WriteLine("");

            //MENU
            
            Menu();

            //Creando el tablero para la PC
            Console.Write("Ingrese OPCION: ");
            opcion = int.Parse(Console.ReadLine());
            
            while (opcion != 4)
            {

                
                switch (opcion)
                {
                    case 1:
                        //Armando tablero de la PC.
                        for (int i = 0; i < tamF; i++)
                        {
                            for (int j = 0; j < tamC; j++)
                            {
                                pc[i, j] = numRandom.Next(0, 4);
                            }
                        }
                        //Mostrando

                        for (int i = 0; i < tamF; i++)
                        {
                            
                            Console.Write(" | ");
                            for (int j = 0; j < tamC; j++)
                            {
                                

                                Console.Write(pc[i, j] + " | ");
                            }
                            Console.WriteLine("");
                        }

                        //Contador PC
                        Console.WriteLine("");
                        for (int i = 0; i < tamF; i++)
                        {
                            for (int j = 0; j < tamC; j++)
                            {
                                if (pc[i, j] == 1 || pc[i, j] == 2 || pc[i, j] == 3)
                                {
                                    contadorPc = contadorPc + 1;
                                }
                                
                                if (pc[i,j] == 1)
                                {
                                    contadorSoldado = contadorSoldado + 1;
                                }
                                else
                                {
                                    if (pc[i, j] == 2)
                                    {
                                        contadorTanque += 1;
                                    }
                                    else
                                    {
                                        if (pc[i,j] == 3)
                                        {
                                            contadorAvion += 1;
                                        }
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Cantidad de Soldados (1): "+ contadorSoldado);
                        Console.WriteLine("Cantidad de Tanques (2): " + contadorTanque);
                        Console.WriteLine("Cantidad de Aviones (3): " + contadorAvion);
                        Console.WriteLine("El ejer de la PC es: " + contadorPc);

                        Console.WriteLine("");
                        Console.WriteLine("Se armo el tablero correctamente!");
                        
                        break;
                    case 2:

                        //Armando tablero del Player.
                        for (int i = 0; i < tamF; i++)
                        {
                            Console.WriteLine("Fila: " + (i + 1));
                            for (int j = 0; j < tamC; j++)
                            {

                                player[i, j] = int.Parse(Console.ReadLine());
                            }
                            Console.WriteLine("");
                        }

                        for (int i = 0; i < tamF; i++)
                        {
                            Console.Write(" | ");
                            for (int j = 0; j < tamC; j++)
                            {

                                Console.Write(player[i, j] + " | ");
                            }
                            Console.WriteLine("");
                        }

                        //Contador player

                        contadorSoldado = 0;
                        contadorTanque = 0;
                        contadorAvion = 0;

                        for (int i = 0; i < tamF; i++)
                        {
                            for (int j = 0; j < tamC; j++)
                            {
                                if (player[i, j] == 1 || player[i, j] == 2 || player[i, j] == 3)
                                {
                                    contadorPlayer = contadorPlayer + 1;
                                }
                                
                                if (player[i, j] == 1)
                                {
                                    contadorSoldado = contadorSoldado + 1;
                                }
                                else
                                {
                                    if (player[i, j] == 2)
                                    {
                                        contadorTanque += 1;
                                    }
                                    else
                                    {
                                        if (player[i, j] == 3)
                                        {
                                            contadorAvion += 1;
                                        }
                                    }
                                }



                            }
                        }
                        Console.WriteLine("Cantidad de Soldados es (1): "+contadorSoldado);
                        Console.WriteLine("Cantidad de Tanques es (2): " + contadorTanque);
                        Console.WriteLine("Cantidad de Aviones es (3): " + contadorAvion);
                        Console.WriteLine("El ejer del Player es: " + contadorPlayer);
                        Console.WriteLine("");
                        Console.WriteLine("Se armo el tablero correctamente!");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("The Match");
                        Console.ResetColor();
                        Console.WriteLine("");
                        do
                        {
                            //Arranca la partida

                            
                            Console.WriteLine("Ronda nº "+contadorRonda);
                            Console.WriteLine("");
                            //Turno Player
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Turno Player");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("Ingrese x and y (X,Y), del 1 al " + (tamC));
                            Console.Write("Ingrese Fila X: ");
                            f = int.Parse(Console.ReadLine());
                            f = f - 1;
                            Console.Write("Ingrese Columna Y: ");
                            c = int.Parse(Console.ReadLine());
                            c = c - 1;
                            Console.WriteLine("");
                            Console.Write("Disparo X: " + (f+1) + " Y: " + (c+1)+" --> ");
                            if (pc[f, c] == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Disparo fallado!");
                                Console.ResetColor();
                                Console.WriteLine("Ejercito restante de la PC: " + contadorPc);
                            }
                            else
                            {
                                if (pc[f, c] == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("Mato a un Soldado");
                                    Console.ResetColor();
                                    contadorPc = contadorPc - 1;
                                    Console.WriteLine("Ejercito restante de la PC: " + contadorPc);
                                    pc[f, c] = 0;
                                    

                                }
                                else
                                {
                                  
                                    if (pc[f, c] == 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine("Mato a un Tanque");
                                        Console.ResetColor();
                                        contadorPc = contadorPc - 1;
                                        Console.WriteLine("Ejercito restante de la PC: " + contadorPc);
                                        pc[f, c] = 0;
                                    }
                                    else
                                    {
                                        if (pc[f, c] == 3)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            Console.WriteLine("Mato a un Avion");
                                            Console.ResetColor();
                                            contadorPc = contadorPc - 1;
                                            Console.WriteLine("Ejercito restante de la PC: " + contadorPc);
                                            pc[f, c] = 0;
                                        }
                                    }
                                }
                            }
                            

                            //Turno pc

                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Turno PC");
                            Console.ResetColor();
                            Console.WriteLine("");
                            f = numRandom.Next(0, 4);
                            c = numRandom.Next(0, 4);
                            Console.Write("Disparo X: " + (f + 1) + " Y: " + (c + 1)+" --> ");
                            if (player[f, c] == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Disparo fallado!");
                                Console.ResetColor();
                                Console.WriteLine("Ejercito restante del Player: " + contadorPlayer);
                            }
                            else
                            {
                                if (player[f, c] == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("Mato a un Soldado");
                                    Console.ResetColor();
                                    contadorPlayer = contadorPlayer - 1;
                                    Console.WriteLine("Ejercito restante del Player: " + contadorPlayer);
                                    player[f, c] = 0;
                                    
                                }
                                else
                                {
                                    if (player[f, c] == 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine("Mato a un Tanque");
                                        Console.ResetColor();
                                        contadorPlayer = contadorPlayer - 1;
                                        Console.WriteLine("Ejercito restante del Player: " + contadorPlayer);
                                        player[f, c] = 0;
                                    }
                                    else
                                    {
                                        if (player[f, c] == 3)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            Console.WriteLine("Mato a un Avion");
                                            Console.ResetColor();
                                            contadorPlayer = contadorPlayer - 1;
                                            Console.WriteLine("Ejercito restante del Player: "+contadorPlayer);
                                            player[f, c] = 0;
                                        }
                                    }
                                }
                            }
                            contadorRonda += 1;
                            Console.WriteLine("");
                            


                        } while (contadorPc > 0 && contadorPlayer > 0);

                        Console.WriteLine("Fin de la partida.");
                        Console.WriteLine("");
                        Console.WriteLine("Ejercito de PC: "+contadorPc);
                        Console.WriteLine("Ejercito de Player: "+contadorPlayer);
                        Console.WriteLine("");

                        if (contadorPc == 0)
                        {
                            Console.WriteLine("Player Win!");
                        }
                        else
                        {
                            if (contadorPlayer == 0)
                            {
                                Console.WriteLine("PC Win!");
                            }
                            
                        }
                        Console.WriteLine("");

                        //Mostrar tablero pc
                        Console.WriteLine("     Tablero PC");
                        for (int i = 0; i < tamF; i++)
                        {
                            Console.Write(" | ");
                            for (int j = 0; j < tamC; j++)
                            {

                                Console.Write(pc[i, j] + " | ");
                            }
                            Console.WriteLine("");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("   Tablero Player");
                        //mostrar tablero player
                        for (int i = 0; i < tamF; i++)
                        {
                            Console.Write(" | ");
                            for (int j = 0; j < tamC; j++)
                            {

                                Console.Write(player[i, j] + " | ");
                            }
                            Console.WriteLine("");
                        }

                        break;
                    
                        
                    case 4:
                        Console.WriteLine("Saliste.");
                        break;

                    default:
                        Console.WriteLine("ERROR");
                        break;
                }
                Console.WriteLine("");
                Console.Write("Ingrese OPCION: ");
                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine("");
            }


            //Console.ReadKey();
        }
        static void Logo()
        {
            Console.WriteLine("#     #                                ######                                   ");
            Console.WriteLine("##    #   ##   #    #   ##   #         #     #   ##   ##### ##### #      ###### ");
            Console.WriteLine("# #   #  #  #  #    #  #  #  #         #     #  #  #    #     #   #      #      ");
            Console.WriteLine("#  #  # #    # #    # #    # #         ######  #    #   #     #   #      #####  ");
            Console.WriteLine("#   # # ###### #    # ###### #         #     # ######   #     #   #      #      ");
            Console.WriteLine("#    ## #    #  #  #  #    # #         #     # #    #   #     #   #      #      ");
            Console.WriteLine("#     # #    #   ##   #    # ######    ######  #    #   #     #   ###### ###### ");
            Console.WriteLine("");
        }
        static void Menu()
        {
            Console.WriteLine(" 1. Armar tablero PC \n 2. Armar tablero Player \n 3. Jugar  \n 4. Salir");
            Console.WriteLine("");
        }
    }
}
