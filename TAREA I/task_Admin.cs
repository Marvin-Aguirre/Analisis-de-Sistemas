public class task_Admin : Task_Repository
{
    private readonly Dictionary<int, Task> tasks;
    private int nextTaskId;
    public task_Admin()
    {
        tasks = new Dictionary<int, Task>();
        nextTaskId = 1;
    }
    public void add_Task(string description)
    {
        Task newTask = new Task{
            Id= nextTaskId,
            Description=description,
            Task_Status=false
        };
        tasks.Add(nextTaskId, newTask);
        nextTaskId++;
    }

    public void delete_Task(int id)
    {
        if (!tasks.Remove(id))
        {
            Console.WriteLine("No se encontró la tarea con el ID especificado.");
        }
    }

    public Task GetTaskById(int id)
    {
        if (tasks.TryGetValue(id, out Task task))
        {
            return task;
        }
        else
        {
            Console.WriteLine("No se encontró la tarea con el ID especificado.");
            return null;
        }
    }

    public List<Task> get_AllTask()
    {
        return tasks.Values.ToList();
    }

    public void modify_Task(int id, string Description, bool Task_Status)
    {
        if (tasks.TryGetValue(id, out Task taskToUpdate))
        {
            taskToUpdate.Description = Description;
            taskToUpdate.Task_Status = Task_Status;
        }
        else
        {
            Console.WriteLine("No se encontró la tarea con el ID especificado.");
        }
    }
}