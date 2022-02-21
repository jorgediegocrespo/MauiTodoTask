using System.Windows.Input;

namespace TaskManager.Features;

public class TaskDetailViewModel : BaseViewModel
{
    private readonly IStorageService storageService;

    private int id;
    private string name;
    private string description;
    private DateTime expirationDate;
    private TaskPriority priority;

    private bool isLoadingTaskItem;
    private bool isSaving;
    private bool isRemoving;

    public TaskDetailViewModel(
        INavigationService navigationService,
        IStorageService storageService) : base(navigationService)
    {
        this.storageService = storageService;
        
        isLoadingTaskItem = true;


        NavigateBackCommand = new Command(async () => await NavigateBackAsync());
        SaveTaskItemCommand = new Command(async () => await SaveTaskItemAsync());
        RemoveTaskItemCommand = new Command(async () => await RemoveTaskItemAsync());
    }

    public ICommand NavigateBackCommand { get; private set; }
    public ICommand SaveTaskItemCommand { get; private set; }
    public ICommand RemoveTaskItemCommand { get; private set; }

    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Description
    {
        get => description;
        set
        {
            description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    public DateTime ExpirationDate
    {
        get => expirationDate;
        set
        {
            expirationDate = value;
            OnPropertyChanged(nameof(ExpirationDate));
        }
    }

    public TaskPriority Priority
    {
        get => priority;
        set
        {
            priority = value;
            OnPropertyChanged(nameof(Priority));
        }
    }

    public bool IsLoadingTaskItem
    {
        get => isLoadingTaskItem;
        private set
        {
            isLoadingTaskItem = value;
            OnPropertyChanged(nameof(IsLoadingTaskItem));
        }
    }

    public bool IsSaving
    {
        get => isSaving;
        private set
        {
            isSaving = value;
            OnPropertyChanged(nameof(IsSaving));
        }
    }

    public bool IsRemoving
    {
        get => isRemoving;
        private set
        {
            isRemoving = value;
            OnPropertyChanged(nameof(IsRemoving));
        }
    }

    public async Task Init(int taskId)
    {
        IsLoadingTaskItem = true;
        id = taskId;
        var taskItem = await storageService.GetTaskItem(taskId);

        IsLoadingTaskItem = false;
    }

    private async Task NavigateBackAsync()
    {
        await navigationService.NavigateBack();
    }

    private async Task SaveTaskItemAsync()
    {
        IsSaving = true;
        //TODO 
        await navigationService.NavigateBack();
        IsSaving = false;
    }

    private async Task RemoveTaskItemAsync()
    {
        IsRemoving = true;
        await storageService.RemoveTaskItems(id);
        await navigationService.NavigateBack();
        IsRemoving = false;
    }
}
