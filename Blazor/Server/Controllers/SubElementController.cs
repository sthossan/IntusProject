using Blazor.Models;
using Blazor.Services;
using Blazor.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class SubElementController : ControllerBase
    {
        private readonly ISubElementService _service;

        public SubElementController(ISubElementService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public List<SubElements> GetList(int orderId, int windowId)
        {
            return _service.GetList(orderId, windowId);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> CreateAync(SubElements model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(s => s.Errors).Select(t => t.ErrorMessage));
                ModelState.AddModelError(string.Empty, errors);
                return new ApiResponse { Status = false, Message = errors };
            }
            return await _service.InsertUpdateAync(model);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> RemoveAync(int id)
        {
            return await _service.RemoveAync(id);
        }

        
    }
}