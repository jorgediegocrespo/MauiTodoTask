//TODO Jorge
using TaskManager.Resources.Texts;

namespace TaskManager.Features
{
    public class TaskPriorityInfo
    {
        public TaskPriorityInfo(TaskPriority taskPriority)
        {
            TaskPriority = taskPriority;
            Text = taskPriority switch
            {
                TaskPriority.High => AppResource.TaskPriorityHigh,
                TaskPriority.Medium => AppResource.TaskPriorityMedium,
                TaskPriority.Low => AppResource.TaskPriorityLow,
                _ => string.Empty
            };
        }

        public TaskPriority TaskPriority { get; set; }
        public string Text { get; set; }
    }
}
