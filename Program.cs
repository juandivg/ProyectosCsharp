using System;
using System.Collections.Generic;

namespace SistemaHobbies
{
    class Hobbie
    {
        static Dictionary<int, Usuario> Usuarios = new Dictionary<int, Usuario>();

        static void Main(string[] args)
        {
            bool continuar = true;

            do {
                Console.Clear();
                Console.WriteLine(" GESTIÓN DE USUARIOS \n\n");
                Console.WriteLine("1. Agregar un usuario");
                Console.WriteLine("2. Mostrar un usuario");
                Console.WriteLine("3. Listar todos los usuarios");
                Console.WriteLine("4. Eliminar un usuario");
                Console.WriteLine("5. Terminar\n\n");
                Console.WriteLine("******************************");
                Console.Write("Elija una Opción: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            agregar();
                            break;
                        case 2:
                            mostrar();
                            break;
                        case 3:
                            listar();
                            break;
                        case 4:
                            borrar();
                            break;
                        case 5:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Elija Opción entre 1 y 5");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                    Console.ReadKey();
                }
            } while (continuar);
        }

        static void agregar()
        {
            Console.Clear();
            Console.WriteLine("Agregar Usuario");
            Console.Write("Ingrese ID de Usuario: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (Usuarios.ContainsKey(id))
                {
                    Console.WriteLine("Número de ID ya existe...");
                }
                else
                {
                    Console.Write("Ingrese nombre del usuario: ");
                    string nombre =  Console.ReadLine() ?? "";

                    Console.Write("Ingrese edad del usuario: ");
                    if (int.TryParse(Console.ReadLine(), out int edad))
                    {
                        Console.Write("Ingrese hobbies del usuario (separados por comas): ");
                        List<string> hobbies = new List<string>(Console.ReadLine().Split(','));

                        Usuario newUsuario = new Usuario(nombre, edad, hobbies);
                        Usuarios.Add(id, newUsuario);
                        Console.WriteLine("Usuario agregado correctamente.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor numérico para la edad");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("Número de identificación No válido");
                Console.ReadKey();
            }
        }

        static void mostrar()
        {
            Console.Clear();
            Console.WriteLine("Mostrar Usuario");
            Console.Write("Ingrese número de identificación del usuario: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (Usuarios.TryGetValue(id, out Usuario Usuario))
                {
                    Console.WriteLine("Información del usuario:");
                    Console.WriteLine($"Nombre: {Usuario.Nombre}");
                    Console.WriteLine($"Edad: {Usuario.Edad}");
                    Console.WriteLine("Hobbies:");
                    foreach (var hobby in Usuario.Hobbies)
                    {
                        Console.WriteLine($"- {hobby}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró un usuario con ese número de identificación.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Número de identificación NO válido.");
                Console.ReadKey();
            }
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        static void listar()
        {
            Console.Clear();
            Console.WriteLine("Listado de Usuarios ");
            if (Usuarios.Count > 0)
            {
                foreach (var usr in Usuarios)
                {
                    Console.WriteLine($"Número de identificación: {usr.Key}");
                    Console.WriteLine($"Nombre: {usr.Value.Nombre}");
                    Console.WriteLine($"Edad: {usr.Value.Edad}");
                    Console.WriteLine("Hobbies:");
                    foreach (var hobby in usr.Value.Hobbies)
                    {
                        Console.WriteLine($"- {hobby}");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        static void borrar()
        {
            Console.Clear();
            Console.WriteLine("Eliminar un Usuario");
            Console.Write("Ingrese número de identificación del usuario a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (Usuarios.ContainsKey(id))
                {
                    Usuarios.Remove(id);
                    Console.WriteLine("Usuario eliminado");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No se encontró un usuario con el número de identificación");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Número de identificación NO válido.");
                Console.ReadKey();
            }
        }
    }
}
