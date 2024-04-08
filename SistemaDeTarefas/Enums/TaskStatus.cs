using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum TaskStatus
    {
        [Description("To do")]
        ToDo = 1,
        [Description("In progress")]
        InProgress = 2,
        [Description("Finished")]
        Finished = 3
    }
}
