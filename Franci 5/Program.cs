using System;

namespace AlgoritmosOrdenacion
{
    // Clase para el Ejercicio 1
    class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public Libro(int id, string titulo, string autor)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== PRÁCTICA DE ALGORITMOS DE ORDENACIÓN ===");
                Console.WriteLine("1. Bubble Sort (Ordenar Libros)");
                Console.WriteLine("2. Selection Sort (Ordenar Precios)");
                Console.WriteLine("3. Insertion Sort (Tiempos de Llegada)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione un ejercicio: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

                switch (opcion)
                {
                    case 1: Ejercicio1_BubbleSort(); break;
                    case 2: Ejercicio2_SelectionSort(); break;
                    case 3: Ejercicio3_InsertionSort(); break;
                    case 0: Console.WriteLine("Cerrando programa..."); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            } while (opcion != 0);
        }

        // EJERCICIO 1: BUBBLE SORT (LIBROS)

        static void Ejercicio1_BubbleSort()
        {
            Console.WriteLine("\n--- EJERCICIO 1: BUBBLE SORT ---");
            Libro[] libros = new Libro[]
            {
                new Libro(1, "El Principito", "Antoine de Saint-Exupéry"),
                new Libro(2, "Cien años de soledad", "Gabriel García Márquez"),
                new Libro(3, "Don Quijote", "Miguel de Cervantes"),
                new Libro(4, "1984", "George Orwell"),
                new Libro(5, "Fahrenheit 451", "Ray Bradbury")
            };

            int n = libros.Length;
            int comparaciones = 0;
            int intercambios = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    comparaciones++;
                    // string.Compare devuelve > 0 si la primera cadena es mayor alfabéticamente
                    if (string.Compare(libros[j].Titulo, libros[j + 1].Titulo) > 0)
                    {
                        // Intercambio (Swap)
                        Libro temp = libros[j];
                        libros[j] = libros[j + 1];
                        libros[j + 1] = temp;
                        intercambios++;
                    }
                }

                // Mostrar estado del arreglo después de cada pasada (Outer loop)
                Console.WriteLine($"\nPasada {i + 1}:");
                foreach (var lib in libros)
                {
                    Console.WriteLine($" - {lib.Titulo}");
                }
            }

            Console.WriteLine($"\nTotal Comparaciones: {comparaciones} | Total Intercambios: {intercambios}");
        }

        // EJERCICIO 2: SELECTION SORT (PRECIOS)

        static void Ejercicio2_SelectionSort()
        {
            Console.WriteLine("\n--- EJERCICIO 2: SELECTION SORT ---");
            int[] precios = { 250, 120, 75, 300, 100, 180, 90, 220 };
            int n = precios.Length;
            int comparaciones = 0;
            int intercambios = 0;

            Console.WriteLine("Arreglo original: " + string.Join(", ", precios));

            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    comparaciones++;
                    if (precios[j] < precios[minIdx])
                    {
                        minIdx = j;
                    }
                }

                // Imprimir el índice mínimo encontrado en la iteración actual
                Console.WriteLine($"Iteración {i + 1}: Índice de selección mínima = {minIdx} (Valor: {precios[minIdx]:C0})");

                // Realizar el intercambio si el mínimo no es el elemento actual
                if (minIdx != i)
                {
                    int temp = precios[minIdx];
                    precios[minIdx] = precios[i];
                    precios[i] = temp;
                    intercambios++;
                }
            }

            Console.WriteLine("\nArreglo ordenado: " + string.Join(", ", precios));
            Console.WriteLine($"Total Comparaciones: {comparaciones} | Total Intercambios: {intercambios}");
        }

        // EJERCICIO 3: INSERTION SORT (TIEMPOS)

        static void Ejercicio3_InsertionSort()
        {
            Console.WriteLine("\n--- EJERCICIO 3: INSERTION SORT ---");
            int[] tiempos = { 58, 54, 60, 52, 57, 56, 59 };
            int n = tiempos.Length;
            int comparaciones = 0;
            int desplazamientos = 0;

            Console.WriteLine("Estado inicial: " + string.Join(", ", tiempos));

            for (int i = 1; i < n; i++)
            {
                int llave = tiempos[i]; // El elemento a insertar
                int j = i - 1;

                // Mover los elementos mayores a la llave una posición a la derecha
                while (j >= 0)
                {
                    comparaciones++;
                    if (tiempos[j] > llave)
                    {
                        tiempos[j + 1] = tiempos[j];
                        desplazamientos++;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }

                tiempos[j + 1] = llave; // Inserción en la posición correcta

                // Mostrar cómo se forma el arreglo paso a paso
                Console.WriteLine($"Paso {i} (Insertando {llave}): " + string.Join(", ", tiempos));
            }

            Console.WriteLine($"\nTotal Comparaciones: {comparaciones} | Total Desplazamientos: {desplazamientos}");
        }
    }
}