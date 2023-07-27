// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Program {

    static void Main() {
        int opcion;
        Dictionary<int, Usuario> miDiccionario = new Dictionary<int, Usuario>();
        do{
            MostrarMenu();
            opcion = PedirOpcion();

            switch (opcion) {
                case 1:
                    Agregar(miDiccionario);
                    break;
                case 2:
                    Mostrar(miDiccionario);
                    break;
                case 3:
                    MostrarUser(miDiccionario);
                    break;
                case 4:
                    Eliminar(miDiccionario);
                    break;
                case 5:
                    Console.WriteLine("Hasta luego.");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                    break;
            }

            Console.WriteLine();
        } while(opcion!=5);

    }

static void MostrarMenu() {
    Console.WriteLine("Menú de opciones:");
    Console.WriteLine("1. Agregar");
    Console.WriteLine("2. Mostrar");
    Console.WriteLine("3. Buscar por ID");
    Console.WriteLine("4. Eliminar");
    Console.WriteLine("5. Salir");
    }
    static int PedirOpcion() {
        Console.Write("Elige una opción: ");
        return Convert.ToInt32(Console.ReadLine());
    }
    static void Agregar(Dictionary<int, Usuario> miDiccionario){

         Console.WriteLine("Ingrese el ID del usuario");
         int id= Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Ingrese el nombre del usuario");
         string? nombre=Console.ReadLine();
         Console.WriteLine("Ingrese la edad del usuario");
         int edad= Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Ingrese el numero de hobbies");
         int hobbies= Convert.ToInt32(Console.ReadLine());
         List<string> hobbiesNum=new List<string>();
        for (int i = 0; i < hobbies; i++)
        {
            Console.WriteLine($"Ingrese el hobbie {i+1}");
            string? leerHobby = Console.ReadLine();
            hobbiesNum.Add(leerHobby);

        }
        miDiccionario.Add(id, new Usuario{name=nombre, age=edad, hobbies=hobbiesNum});
    }
    static void Mostrar(Dictionary<int, Usuario> miDiccionario){
          foreach(var u in miDiccionario){
            Console.WriteLine($"ID: {u.Key}, Nombre: {u.Value.name}, Edad: {u.Value.age}");
            u.Value.hobbies.ForEach(x => Console.WriteLine(x));
        }
}
    static void MostrarUser(Dictionary<int, Usuario> miDiccionario){
        Console.WriteLine("Ingrese el numero de ID:");
        int idEntered=Convert.ToInt32(Console.ReadLine());
        foreach(var u in miDiccionario){
            if(u.Key == idEntered){
                Console.WriteLine($"ID: {u.Key}, Nombre: {u.Value.name}, Edad: {u.Value.age}");
                u.Value.hobbies.ForEach(x => Console.WriteLine(x));
            }
        }
    }
    static void Eliminar(Dictionary<int, Usuario> miDiccionario){
        Console.WriteLine("Ingrese el numero de ID:");
        int idEntered=Convert.ToInt32(Console.ReadLine());
        foreach(var u in miDiccionario){
            if(u.Key == idEntered){
                miDiccionario.Remove(u.Key);
                Console.WriteLine("Usuario eliminado correctamente");
            }
        }
    }
}


class Usuario{
    public string? name {get ; set; }
    public int age {get ; set; }
    public List<string>? hobbies {get ; set; }
}