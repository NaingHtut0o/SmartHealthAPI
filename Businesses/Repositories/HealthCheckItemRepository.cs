using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using SmartHealthAPI.Data;
using SmartHealthAPI.Infrastructures.Repositories;
using SmartHealthAPI.Models;
using SmartHealthAPI.Utilities;

namespace SmartHealthAPI.Businesses.Repositories
{
    public class HealthCheckItemRepository : IHealthCheckItemRepository
    {
        private readonly AppDb _context;

        public HealthCheckItemRepository(AppDb context)
        {
            _context = context;
        }

        public async Task<dynamic> GetAllHealthCheckItems()
        {
            var result = from healthCheckItem in _context.healthCheckItemMasters
                         select new
                         {
                             healthCheckItem.ItemId,
                             healthCheckItem.ItemName,
                             healthCheckItem.Unit,
                         };
            return await result.ToListAsync();
        }

        public async Task<dynamic> GetAllHealthCheckItemsCombined()
        {
            var result = from healthCheckItem in _context.healthCheckItemMasters
                         select new
                         {
                             healthCheckItem.ItemId,
                             CombinedName = $"{healthCheckItem.ItemName}( {healthCheckItem.Unit} )",
                         };
            return await result.ToListAsync();
        }

        public async Task<dynamic> GetHealthCheckItemById(int itemId)
        {
            var result = from healthCheckItem in _context.healthCheckItemMasters
                         where healthCheckItem.ItemId == itemId
                         select new
                         { 
                             healthCheckItem.ItemId,
                             healthCheckItem.ItemName,
                             healthCheckItem.Unit,
                             healthCheckItem.CreatedAt,
                             healthCheckItem.UpdatedAt
                         };
            return await result.FirstOrDefaultAsync();
        }

        public async Task<dynamic> GetHealthCheckItem(int? itemId, string? itemName, string? unit)
        {
            var result = from healthCheckItem in _context.healthCheckItemMasters
                         select new
                         {
                             healthCheckItem.ItemId,
                             healthCheckItem.ItemName,
                             healthCheckItem.Unit,
                         };
            if (itemId == null && itemName == null && unit == null)
                result = result.Where(res => res.ItemId == 0);
            else
            {
                if (itemId != null)
                    result = result.Where(result => result.ItemId == itemId);
                if (itemName != null)
                    result = result.Where(result => result.ItemName.Contains(itemName));
                if (unit != null)
                    result = result.Where(res => res.Unit.Contains(unit));
            }
            return await result.ToListAsync();
        }

        public async Task<dynamic> AddNewHealthCheckItem(HealthCheckItemMaster healthCheckItemMaster)
        {
            dynamic response = new ExpandoObject();
            response.Success = true;
            response.Message = Message.SucMsgAdd + "Health Check Item.";
            _context.healthCheckItemMasters.Add(healthCheckItemMaster);
            var affectedRow = await _context.SaveChangesAsync();
            if (affectedRow <= 0)
            {
                response.Success = false;
                response.Message = Message.ErrMsgAdd;
            }
            return response;
        }

        public async Task<dynamic> UpdateHealthCheckItem(HealthCheckItemMaster healthCheckItemMaster)
        {
            dynamic response = new ExpandoObject();
            response.Success = true;
            response.Message = Message.SucMsgUpt + "Health Check Item.";
            _context.healthCheckItemMasters.Update(healthCheckItemMaster);
            var rowAffected = await _context.SaveChangesAsync();
            if (rowAffected <= 0)
            {
                response.Success = false;
                response.Message = Message.ErrMsgUpt;
            }
            return response;
        }

        public async Task<dynamic> RemoveHealthCheckItem(int itemId)
        {
            dynamic response = new ExpandoObject();
            response.Success = false;
            response.Message = Message.NotFoundData;
            HealthCheckItemMaster? user = await _context.healthCheckItemMasters.FindAsync(itemId);
            if (user != null)
            {
                _context.Remove(user);
                var rowAffected = await _context.SaveChangesAsync();
                if (rowAffected > 0)
                {
                    response.Success = true;
                    response.Message = Message.SucMsgDel + "Health Check Item.";
                }
                else
                {
                    response.Success = false;
                    response.Message = Message.ErrMsgDel;
                }
            }
            return response;
        }
    }
}
