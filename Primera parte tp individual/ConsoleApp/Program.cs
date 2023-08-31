namespace CalculadoraConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Multiplicación");
                Console.WriteLine("3. Salir");

                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            RealizarSuma();
                            break;
                        case 2:
                            RealizarMultiplicacion();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, elija una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
                }

                Console.WriteLine(); 
            }
        }

        static void RealizarSuma()
        {
            try
            {
                Console.WriteLine("Ingrese el primer número:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese el segundo número:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double resultado = num1 + num2;
                Console.WriteLine($"Resultado de la suma: {resultado}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese números válidos.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Los números son demasiado grandes o pequeños.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

        }

        static void RealizarMultiplicacion()
        {
            try
            {
                Console.WriteLine("Ingrese el primer número:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese el segundo número:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double resultado = num1 * num2;
                Console.WriteLine($"Resultado de la multiplicación: {resultado}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese números válidos.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Los números son demasiado grandes o pequeños.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
    }
}
