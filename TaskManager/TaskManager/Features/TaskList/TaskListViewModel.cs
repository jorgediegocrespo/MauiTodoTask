//TODO Elbrinener
using System.Collections.Generic;
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
            
            IsLoadingTaskItems = true;
            TaskItems = new List<TaskItem>();
            
            NavigateToSelectedTaskCommand = new Command(async () => await NavigateToSelectedTaskAsync());
            AddTaskItemCommand = new Command(async () => await AddTaskItemAsync());
        }

        public ICommand AddTaskItemCommand { get; private set; }
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
                OnPropertyChanged(nameof(SelectedTaskItem));
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
            IsLoadingTaskItems = true;
            TaskItems = new List<TaskItem>(await storageService.GetTaskItems());
            IsLoadingTaskItems = false;
        }

        public async Task NavigateToSelectedTaskAsync()
        {
            if (SelectedTaskItem == null)
                return;

            IsLoadingTaskItems = true;
            int taskId = SelectedTaskItem.Id;
            SelectedTaskItem = null;
            await navigationService.NavigateToPageDetail(taskId);
        }

        private async Task AddTaskItemAsync()
        {
            IsLoadingTaskItems = true;
            await navigationService.NavigateToPageDetail(0);
        }
    }
}
