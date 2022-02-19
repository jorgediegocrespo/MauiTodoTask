using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TaskManager.Features
{
    public class TaskListViewModel : BaseViewModel
    {
        private ObservableCollection<TaskItem> taskItems;
        private TaskItem selectedTaskItem;

        public TaskListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            taskItems = new ObservableCollection<TaskItem>();
            NavigateToSelectedTaskCommand = new Command(async () => await NavigateToSelectedTaskAsync());
        }

        public ICommand NavigateToSelectedTaskCommand { get; set; }

        public ObservableCollection<TaskItem> TaskItems
        {
            get => taskItems;
            set
            {
                taskItems = value;
                OnPropertyChanged(nameof(TaskItems));
            }
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

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            await LoadTaskItemsAsync();
        }

        private Task LoadTaskItemsAsync()
        {
            TaskItems.Clear();

            for (int i = 1; i <= 100; i++)
            {
                TaskItems.Add(new TaskItem
                {
                    Name = $"Task {i}",
                    Description = $"Description {i}",
                    Priority = (TaskPriority)(i % 3)
                });
            }

            return Task.CompletedTask;
        }

        public async Task NavigateToSelectedTaskAsync()
        {
            //TODO Navigate to task detail
            await Task.CompletedTask;
        }
    }
}
