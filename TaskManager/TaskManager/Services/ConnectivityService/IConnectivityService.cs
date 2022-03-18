namespace TaskManager.Services.ConnectivityService;

public interface IConnectivityService
{
    Task<bool> HasInternet();
}