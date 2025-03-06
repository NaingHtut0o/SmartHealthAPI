using SmartHealthAPI.Infrastructures.Repositories;
using SmartHealthAPI.Infrastructures.Services;
using SmartHealthAPI.Models;

namespace SmartHealthAPI.Businesses.Services
{
    public class HealthCheckItemService : IHealthCheckItemService
    {
        private readonly IHealthCheckItemRepository _repository;
        private readonly ILogger<HealthCheckItemService> _logger;

        public HealthCheckItemService(IHealthCheckItemRepository repository, ILogger<HealthCheckItemService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        public async Task<dynamic> GetAllHealthCheckItems()
        { 
            return await _repository.GetAllHealthCheckItems();
        }
        
        public async Task<dynamic> GetAllHealthCheckItemsCombined()
        { 
            return await _repository.GetAllHealthCheckItemsCombined();
        }
        
        public async Task<dynamic> GetHealthCheckItemById(int itemId)
        { 
            return await _repository.GetHealthCheckItemById(itemId);
        }
        
        public async Task<dynamic> GetHealthCheckItem(int? itemId, string? itemName, string? unit)
        {
            return await _repository.GetHealthCheckItem(itemId, itemName, unit);
        }
        
        public async Task<dynamic> AddNewHealthCheckItem(HealthCheckItemMaster healthCheckItemMaster)
        { 
            healthCheckItemMaster.CreatedAt = DateTime.UtcNow;
            healthCheckItemMaster.UpdatedAt = DateTime.UtcNow;
            return await _repository.AddNewHealthCheckItem(healthCheckItemMaster);
        }
        
        public async Task<dynamic> UpdateHealthCheckItem(HealthCheckItemMaster healthCheckItemMaster)
        {
            int itemId = healthCheckItemMaster.ItemId;
            dynamic oldModel = await _repository.GetHealthCheckItemById(itemId);
            healthCheckItemMaster.CreatedAt = oldModel.CreatedAt.ToUniversalTime();
            healthCheckItemMaster.UpdatedAt = DateTime.UtcNow;
            return await _repository.UpdateHealthCheckItem(healthCheckItemMaster);
        }

        public async Task<dynamic> RemoveHealthCheckItem(int itemId)
        { 
            return await _repository.RemoveHealthCheckItem(itemId);
        }
    }
}
