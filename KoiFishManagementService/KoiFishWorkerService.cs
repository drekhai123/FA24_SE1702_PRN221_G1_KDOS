using KoiFishManagementService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class KoiFishWorkerService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public KoiFishWorkerService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var koiFishService = scope.ServiceProvider.GetRequiredService<IFishHelthService>();
           
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        
        return Task.CompletedTask;
    }
}