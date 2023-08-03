// See https://aka.ms/new-console-template for more information

public class Program
{
    public static void Main(string[] args)
    {
        Task_Repository taskManager = new task_Admin();

        while (true)
        {
            Console.WriteLine("---- Menu Principal ----");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Actualizar tarea");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Mostrar todas las tareas");
            Console.WriteLine("5. Salir");
            Console.WriteLine("---------------------------");

            Console.Write("Seleccione una opción: ");
            int option = int.Parse(Console.ReadLine());

            switch(option){
                case 1:
                    Console.WriteLine("Ingresa la descripcion de la tarea: ");
                    string description =Console.ReadLine();

                    Thread addThread = new Thread(() => taskManager.add_Task(description));
                    addThread.Start();
                    addThread.Join();

                    Console.WriteLine("Tarea agregada correctamente.");
                    break;

                break;

                case 2:
                    Console.Write("Ingrese el ID de la tarea a actualizar");
                    int idToUpdate = int.Parse(Console.ReadLine());
                    Task taskToUpdate = taskManager.GetTaskById(idToUpdate);

                    if (taskToUpdate != null)
                    {
                        Console.Write("Nueva descripción de la tarea: ");
                        string newDescription = Console.ReadLine();

                        Console.Write("¿La tarea está completada? (true/false): ");
                        bool newIsCompleted = bool.Parse(Console.ReadLine());

                        taskManager.modify_Task(idToUpdate, newDescription, newIsCompleted);
                        Console.WriteLine("Tarea actualizada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró la tarea con el ID especificado.");
                    }
                break;

                case 3:
                    Console.Write("Ingrese el ID de la tarea a eliminar: ");
                    int idToDelete = int.Parse(Console.ReadLine());
                    taskManager.delete_Task(idToDelete);
                    Console.WriteLine("Tarea eliminada correctamente.");
                break;

                case 4:
                    Console.WriteLine("Lista de todas las tareas:");
                    foreach (var task in taskManager.get_AllTask())
                    {
                        Console.WriteLine($"ID: {task.Id}, Descripción: {task.Description}, Completada: {task.Task_Status}");
                    }
                break;

                case 5:
                    Console.WriteLine("Saliendo...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
            
        }

    }
}
