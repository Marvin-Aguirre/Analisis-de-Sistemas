public interface Task_Repository{
    void add_Task(string description);
    void delete_Task(int id);
    void modify_Task(int id, string Description, bool Task_Status);
    List<Task> get_AllTask();
    Task GetTaskById(int id);
}