namespace TaskManager.Services.ConnectivityService;

public class ConnectivityService : IConnectivityService
{
    public Task<bool> HasInternet()
    {
        return Task.FromResult(Microsoft.Maui.Essentials.Connectivity.NetworkAccess == NetworkAccess.Internet);
    }
}