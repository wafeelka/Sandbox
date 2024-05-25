
using AsyncDapper.Models;

namespace AsyncDapper
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var userRepository = scope.ServiceProvider.GetRequiredService<BaseRepository<User>>();
            var user = new User
            {
                Id = 2,
                Age = 18,
                Name = "Artem"
            };
            await userRepository.UpdateAsync(user,stoppingToken);
        }
    }
}
