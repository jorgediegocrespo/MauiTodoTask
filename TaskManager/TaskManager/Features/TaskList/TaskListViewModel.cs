using System.Windows.Input;

namespace TaskManager.Features
{
    public class TaskListViewModel : BaseViewModel
    {
        private readonly IStorageService storageService;
        private List<TaskItem> taskItems;
        private TaskItem selectedTaskItem;
        private bool isLoadingTaskItems;

        public TaskListViewModel(
            INavigationService navigationService,
            IStorageService storageService) : base(navigationService)
        {
            this.storageService = storageService;
            
            isLoadingTaskItems = true;
            taskItems = new List<TaskItem>();
            
            NavigateToSelectedTaskCommand = new Command(async () => await NavigateToSelectedTaskAsync());
        }

        public ICommand NavigateToSelectedTaskCommand { get; private set; }

        public List<TaskItem> TaskItems
        {
            get => taskItems;
            private set
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

        public bool IsLoadingTaskItems
        {
            get => isLoadingTaskItems;
            private set
            {
                isLoadingTaskItems = value;
                OnPropertyChanged(nameof(IsLoadingTaskItems));
            }
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            await LoadTaskItems();
        }

        public async Task LoadTaskItems()
        {
            isLoadingTaskItems = true;
            TaskItems = await storageService.GetTaskItems();
            isLoadingTaskItems = false;
        }

        public async Task NavigateToSelectedTaskAsync()
        {
            int taskId = SelectedTaskItem.Id;
            SelectedTaskItem = null;
            await navigationService.NavigateToPageDetail(taskId);
        }
    }
}
