using System;
using System.Collections.Generic;
using listas_cSharp.Clases;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Persona> personas = new List<Persona>();// Lista para almacenar los objetos Persona
        // Bucle para ingresar los datos de los alumnos 
        do
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Ingrese el nombre del Alumno (deje en blanco para terminar)");
                string nombre = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(nombre))
                {
                    break; // Si se deja en blanco, se termina el bucle y se pasa a la siguiente sección de código  
                }

                Console.WriteLine("Ingrese la edad del Alumno");
                int edad = Convert.ToInt32(Console.ReadLine());

                string email;
                do
                {
                    Console.WriteLine("Ingrese el Email del Alumno");
                    email = Console.ReadLine()?.Trim();
                } while (!IsValidEmail(email));// Repite hasta que se ingrese un email válido

                personas.Add(new Persona { Name = nombre, Age = edad, Email = email });// Agrega un nuevo objeto Persona a la lista
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Verifique los datos ingresados");
            }

            Console.WriteLine("Desea ingresar otro alumno? Presione Enter (Sí) o la tecla Esc (Escape) para terminar");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        Console.Clear();
        Console.WriteLine("{0,-15} {1,20} {2,30} {3,40}", "Codigo", "Nombre del alumno", "Edad", "Correo electronico");

         // Itera sobre la lista de personas e imprime sus datos
        foreach (Persona person in personas)
        {
            try
            {
                Console.WriteLine("{0,-15} {1,20} {2,25} {3,30}", person.IdPerson, person.Name, person.Age, person.Email);
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Verifique con ChatGPT");
            }
        }

        string respuesta;

        do
        {
            Console.WriteLine("\nRealizar búsqueda por nombre del alumno:");
            string nombreBusqueda = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(nombreBusqueda))
            {
                Persona ? alumnoEncontrado = personas.Find(p => string.Equals(p.Name, nombreBusqueda, StringComparison.OrdinalIgnoreCase));

                if (alumnoEncontrado != null)
                {
                    Console.WriteLine("\nAlumno encontrado:");
                    Console.WriteLine("{0,-15} {1,20} {2,25} {3,30}", alumnoEncontrado.IdPerson, alumnoEncontrado.Name, alumnoEncontrado.Age, alumnoEncontrado.Email);
                }
                else
                {
                    Console.WriteLine("\nNo se encontró ningún alumno con ese nombre.");
                }
            }
            else
            {
                Console.WriteLine("\nNo se ingresó un nombre válido para la búsqueda.");
            }

            Console.WriteLine("¿Desea buscar otra persona? (Sí/No)");
            respuesta = Console.ReadLine()?.Trim();

            // Continuar el bucle si la respuesta es "Sí" o "s" (ignorando mayúsculas/minúsculas)
        } while (string.Equals(respuesta, "Sí", StringComparison.OrdinalIgnoreCase) || string.Equals(respuesta, "s", StringComparison.OrdinalIgnoreCase));

        Console.ReadKey();
    }

    // Método para validar el formato del correo electrónico
    private static bool IsValidEmail(string email)
    {
        // Lógica para validar el formato del correo electrónico
        // Puedes implementar aquí la validación que desees utilizar

        return !string.IsNullOrEmpty(email);
    }
}
