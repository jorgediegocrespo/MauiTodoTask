using System.Windows.Input;
using TaskManager.Resources.Texts;

namespace TaskManager.Features;

public class TaskDetailViewModel : BaseViewModel
{
    private readonly IStorageService storageService;
    private readonly IAlertDialogService alertDialogService;

    private int id;
    private string name;
    private string description;
    private DateTime expirationDate;
    private TaskPriorityInfo selectedPriority;
    private List<TaskPriorityInfo> priorities;

    private bool isBusy;

    public TaskDetailViewModel(
        INavigationService navigationService,
        IStorageService storageService,
        IAlertDialogService alertDialogService) : base(navigationService)
    {
        this.storageService = storageService;
        this.alertDialogService = alertDialogService;
        
        IsBusy = true;

        SaveTaskItemCommand = new Command(async () => await SaveTaskItemAsync());
        RemoveTaskItemCommand = new Command(async () => await RemoveTaskItemAsync());
    }

    public ICommand SaveTaskItemCommand { get; private set; }
    public ICommand RemoveTaskItemCommand { get; private set; }

    public int Id
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

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

    public TaskPriorityInfo SelectedPriority
    {
        get => selectedPriority;
        set
        {
            selectedPriority = value;
            OnPropertyChanged(nameof(SelectedPriority));
        }
    }

    public List<TaskPriorityInfo> Priorities
    {
        get => priorities;
        private set
        {
            priorities = value;
            OnPropertyChanged(nameof(Priorities));
        }
    }

    public bool IsBusy
    {
        get => isBusy;
        private set
        {
            isBusy = value;
            OnPropertyChanged(nameof(IsBusy));
        }
    }

    public void Init(int taskId)
    {
        id = taskId;
    }

    public override async Task OnAppearing()
    {
        await base.OnAppearing();
        IsBusy = true;
        LoadPriorities();
        await LoadTaskItem();
        IsBusy = false;
    }

    private void LoadPriorities()
    {
        Priorities = new List<TaskPriorityInfo>
        {
            new TaskPriorityInfo(TaskPriority.High),
            new TaskPriorityInfo(TaskPriority.Medium),
            new TaskPriorityInfo(TaskPriority.Low),
        };
    }

    private async Task LoadTaskItem()
    {
        var taskItem = await storageService.GetTaskItem(id);
        if(taskItem != null)
        {
            Id = taskItem.Id;
            SelectedPriority = Priorities.FirstOrDefault(x => x.TaskPriority == taskItem.Priority);
            Description = taskItem.Description;
            ExpirationDate= taskItem.ExpirationDate;
            Name = taskItem.Name;
        }
        else
        {
            SelectedPriority = Priorities.FirstOrDefault(x => x.TaskPriority == TaskPriority.Medium);
            ExpirationDate = DateTime.Now.AddDays(1);
        }
    }

    private async Task SaveTaskItemAsync()
    {
        if (!(await alertDialogService.ShowDialogConfirmationAsync(AppResource.TaskDetailSave, AppResource.TaskDetailSaveQuestion, AppResource.DialogCancel, AppResource.DialogOk)))
            return;

        if (!IsValidTaskItem())
        {
            await alertDialogService.ShowDialogAsync(AppResource.DialogError, AppResource.TaskDetailSaveError, AppResource.DialogOk);
            return;
        }

        IsBusy = true;        
        TaskItem data = new TaskItem()
        {
            Id= id,
            Description = Description,
            ExpirationDate = ExpirationDate,
            Name = Name,
            Priority = SelectedPriority.TaskPriority

        };
        await storageService.SaveTaskItem(data);
        await navigationService.NavigateBack();
        IsBusy = false;
    }

    private bool IsValidTaskItem()
    {
        if (string.IsNullOrWhiteSpace(Name))
            return false;

        if (string.IsNullOrWhiteSpace(Description))
            return false;

        return true;
    }

    private async Task RemoveTaskItemAsync()
    {
        if (!(await alertDialogService.ShowDialogConfirmationAsync(AppResource.TaskDetailRemove, AppResource.TaskDetailRemoveQuestion, AppResource.DialogCancel, AppResource.DialogOk)))
            return;

        IsBusy = true;
        await storageService.RemoveTaskItems(id);
        await navigationService.NavigateBack();
        IsBusy = false;
    }
}
