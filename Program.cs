using System.Runtime.InteropServices;

namespace Reservas_de_asientos_del_cine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Ejercicio: Sistema de Reservas de Asientos en un Cine

             Crea un programa en C# que simule un sistema de reservas de 
             asientos en un cine. Deberás utilizar una matriz para representar la
             disposición de los asientos en el cine. Cada asiento debe tener un 
             estado (reservado o libre) y un número de fila y columna.

             Define una clase Asiento con las siguientes propiedades:

             Fila (int): El número de fila del asiento.
             Columna (int): El número de columna del asiento.
             Reservado (bool): Indica si el asiento está reservado o no.

             Crea una clase Cine que contenga una matriz de objetos Asiento para 
             representar los asientos del cine. El tamaño de la matriz debe ser 
             especificado por el usuario al principio del programa.

             Implementa un método en la clase Cine que permita realizar una reserva de asiento.
             El usuario deberá especificar la fila y columna del asiento que desea reservar.
             Si el asiento está libre, se marca como reservado; de lo contrario, se 
             muestra un mensaje de error.

             Implementa un método en la clase Cine que muestre en pantalla el estado 
             actual de todos los asientos en el cine, indicando qué asientos están 
             reservados y cuáles están libres.

             En el programa principal, permite que el usuario realice múltiples reservas y
             visualice el estado actual de los asientos tantas veces como desee.
             */


            //Variables
            int op = 0, fila, columna;



            //Damos la bienvenida xd
            Console.WriteLine("Bienvenido al Sistema de Reservas de Asientos en el Cine: ");



            //Pedimos el tamaño de la matriz e inicializamos el constructor cinema
            Cinema cine = new();



            //Se repite hasta que se digite 2
            do
            {

                //Mostramos el estado actual de los asientos
                cine.DisplaySeats();

                //Pedimos una opcion
                Console.WriteLine("Opcion 1: Reservar asiento");
                Console.WriteLine("Opcion 2: Salir");
                op = GetValidOption("Digite una opcion: ");


                //Pedimos el asiento a reservar en caso de 1
                if (op == 1)
                {

                    //Pedimos la fila y columna del asiento+
                    fila = GetValidIntPositive("Ingrese la fila del asiento a reservar: ");
                    columna = GetValidIntPositive("Ingrese la columna del asiento a reservar: ");
                   

                    //Mostramos si se pudo reservar
                    cine.ValidarReserva(fila, columna);
                }

            }
            while (op != 2);


            //Mostramos mensaje de despedida
            Console.Clear();
            Console.WriteLine("Gracias por usar nuestro sistema de reservas!. Aquí está el estado final de los asientos: ");


            //Mostramos el estado final de los asientos
            cine.DisplaySeats();



            Console.ReadKey();
        }



        //Metodo auxiliar para validar opcion
        static int GetValidOption(string message)
        {
            int op;

            do
            {
                Console.Write(message);

                //se repite hasta que se digite un int o sea menor o igual a 0
            } while ((!int.TryParse(Console.ReadLine(), out op)) || op <= 0 || op > 2);

            return op;
        }



        //Metodo auxiliar para validar columnas y filas
        public static int GetValidIntPositive(string message)
        {
            int number;

            do
            {
                Console.Write(message);

                //se repite hasta que se digite un int o sea menor o igual a 0
            } while ((!int.TryParse(Console.ReadLine(), out number)) || number <= 0);


            return number;
        }

    }

    //Clases
    class Cinema
    {

        //Propiedades
        public Seat[,] Seats { get; set; }
        public string[,] SeatingMap { get; set; }



        //Constructor
        public Cinema()
        {

            //Variables
            int fila, columna;


            //Pedimos datos
            fila = Program.GetValidIntPositive("Ingrese el numero de filas: ");
            columna = Program.GetValidIntPositive("Ingrese el numero de columnas: ");


            //Inicializamos la matriz Seats con instancias de Seat
            Seats = new Seat[fila, columna];
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columna; j++)
                {
                    Seats[i, j] = new Seat();
                }
            }

            //Inicializamos la matriz SeatingMap
            SeatingMap = new string[fila, columna];
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columna; j++)
                {
                    SeatingMap[i, j] = "[ ] ";
                }
            }
        }




        //Metodos:


        //Mostrar si se reservo correctamente el asiento segun los datos ingresados
        public void ValidarReserva(int fila, int columna)
        {

            //Verificamos la posicion
            if (fila - 1 >= 0 && fila - 1 < Seats.GetLength(0) && columna - 1 >= 0 && columna - 1 < Seats.GetLength(1))
            {
                //Verificamos si ya esta reservado
                if (!Seats[fila - 1, columna - 1].Reserved)
                {
                    SeatingMap[fila - 1, columna - 1] = "[X] ";
                    Seats[fila - 1, columna - 1].Reserved = true;
                }
                else Console.WriteLine("Error, el asiento ya está reservado.");
            }
            else Console.WriteLine("Error, ubicación de asiento no válida.");
        }



        //Mostrar estado de asientos
        public void DisplaySeats()
        {

            Console.WriteLine();
            Console.WriteLine("Estado actual de los asientos: ");

            for (int i = 0; i < Seats.GetLength(0); i++)
            {
                //Mostramos las filas de manera cronologica
                Console.Write($"Fila {i + 1}: ");

                for (int j = 0; j < Seats.GetLength(1); j++)
                {
                    //Imprimimos " [ ] "
                    Console.Write(SeatingMap[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

        }



    }




    class Seat
    {

        //Propiedades
        public bool Reserved { get; set; }


        //Constructor
        public Seat()
        {
            Reserved = false;
        }
    }
}