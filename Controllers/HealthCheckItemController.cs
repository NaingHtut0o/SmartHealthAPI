using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthAPI.Infrastructures.Services;
using SmartHealthAPI.Models;
using SmartHealthAPI.Utilities;

namespace SmartHealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckItemController : ControllerBase
    {
        private readonly IHealthCheckItemService _service;
        private readonly ILogger<HealthCheckItemController> _logger;

        public HealthCheckItemController(IHealthCheckItemService service, ILogger<HealthCheckItemController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAllHealthCheckItems")]
        public async Task<IActionResult> GetAllHealthCheckItems()
        {
            _logger.LogInformation(Message.InfMsgRead);
            var result = await _service.GetAllHealthCheckItems();
            if (result == null)
            {
                _logger.LogError(Message.ErrMsgRead);
                return StatusCode(500, Message.ErrMsgRead);
            }
            _logger.LogInformation(Message.SucMsgRead);
            return Ok(result);
        }

        [HttpGet("GetAllHealthCheckItemsCombined")]
        public async Task<IActionResult> GetAllHealthCheckItemsCombined()
        {
            _logger.LogInformation(Message.InfMsgRead);
            var result = await _service.GetAllHealthCheckItemsCombined();
            if (result == null)
            {
                _logger.LogError(Message.ErrMsgRead);
                return StatusCode(500, Message.ErrMsgRead);
            }
            _logger.LogInformation(Message.SucMsgRead);
            return Ok(result);
        }

        [HttpGet("GetHealthCheckItemById/{itemId}")]
        public async Task<IActionResult> GetHealthCheckItemById(int itemId)
        {
            if (itemId == 0)
            {
                _logger.LogError(Message.ErrMsgReq);
                return BadRequest(Message.ErrMsgReq);
            }
            _logger.LogInformation(Message.InfMsgRead);
            var result = await _service.GetHealthCheckItemById(itemId);
            if (result == null)
            {
                _logger.LogError(Message.NotFoundData);
                return NotFound(Message.NotFoundData);
            }
            _logger.LogInformation(Message.SucMsgRead);
            return Ok(result);
        }

        [HttpGet("GetHealthCheckItem")]
        public async Task<IActionResult> GetHealthCheckItem(int? itemId, string? itemName, string? unit)
        {
            _logger.LogInformation(Message.InfMsgRead);
            var result = await _service.GetHealthCheckItem(itemId, itemName, unit);
            if (result == null)
            {
                _logger.LogError(Message.NotFoundData);
                return NotFound(Message.NotFoundData);
            }
            _logger.LogInformation(Message.SucMsgRead);
            return Ok(result);
        }

        [HttpPost("AddNewHealthCheckItem")]
        public async Task<IActionResult> AddNewHealthCheckItem([FromBody] HealthCheckItemMaster healthCheckItemMaster)
        {
            if (healthCheckItemMaster == null)
            {
                _logger.LogError(Message.ErrMsgReq);
                return BadRequest(Message.ErrMsgReq);
            }
            _logger.LogInformation(Message.InfMsgAdd);
            dynamic response = await _service.AddNewHealthCheckItem(healthCheckItemMaster);
            if (response.Success)
            {
                _logger.LogInformation($"{response.Message}");
                return Ok(response.Message);
            }
            _logger.LogError($"{response.Message}");
            return StatusCode(500, response.Message);
        }

        [HttpPost("UpdateHealthCheckItem")]
        public async Task<IActionResult> UpdateHealthCheckItem([FromBody] HealthCheckItemMaster healthCheckItemMaster)
        {
            if (healthCheckItemMaster == null)
            {
                _logger.LogError(Message.ErrMsgReq);
                return BadRequest(Message.ErrMsgReq);
            }
            _logger.LogInformation(Message.InfMsgEdt);
            dynamic response = await _service.UpdateHealthCheckItem(healthCheckItemMaster);
            if (response.Success)
            {
                _logger.LogInformation($"{response.Message}");
                return Ok(response.Message);
            }
            _logger.LogError($"{response.Message}");
            return StatusCode(500, response.Message);
        }

        [HttpDelete("RemoveHealthCheckItem/{itemId}")]
        public async Task<IActionResult> RemoveHealthCheckItem(int itemId)
        {
            if (itemId == 0)
            {
                _logger.LogError(Message.ErrMsgReq);
                return BadRequest(Message.ErrMsgReq);
            }
            _logger.LogInformation(Message.InfMsgDel);
            dynamic response = await _service.RemoveHealthCheckItem(itemId);
            if (response.Success)
            {
                _logger.LogInformation($"{response.Message}");
                return Ok(response.Message);
            }
            _logger.LogError($"{response.Message}");
            return StatusCode(500, response.Message);
        }
    }
}
