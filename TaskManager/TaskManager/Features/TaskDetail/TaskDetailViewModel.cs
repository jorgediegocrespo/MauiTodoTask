namespace TaskManager.Features
{
    public class TaskDetailViewModel : BaseViewModel
    {
        private TaskItem selectedTaskItem;

        public TaskDetailViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public TaskItem SelectedTaskItem
        {
            get => selectedTaskItem;
            set
            {
                selectedTaskItem = value;
                OnPropertyChanged(nameof(selectedTaskItem));
            }
        }


    }
}
