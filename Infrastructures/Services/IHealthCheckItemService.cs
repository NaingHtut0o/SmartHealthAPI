﻿using SmartHealthAPI.Models;

namespace SmartHealthAPI.Infrastructures.Services
{
    public interface IHealthCheckItemService
    {
        Task<dynamic> GetAllHealthCheckItems();
        Task<dynamic> GetAllHealthCheckItemsCombined();
        Task<dynamic> GetHealthCheckItemById(int itemId);
        Task<dynamic> GetHealthCheckItem(int? itemId, string? itemName, string? unit);
        Task<dynamic> AddNewHealthCheckItem(HealthCheckItemMaster healthCheckItemMaster);
        Task<dynamic> UpdateHealthCheckItem(HealthCheckItemMaster healthCheckItemMaster);
        Task<dynamic> RemoveHealthCheckItem(int itemId);
    }
}
