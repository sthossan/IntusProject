using Blazor.Models;
using Blazor.Services;
using Blazor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blazor.Server.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class WindowsController : ControllerBase
    {
        private readonly IWindowsService _service;

        public WindowsController(IWindowsService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public List<Windows> GetList(int orderId)
        {
            return _service.GetList(orderId);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> CreateAync(Windows model)
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

        [HttpGet("[action]")]
        public async Task<IEnumerable<DdlViewModel>> GetDDL(int orderId)
        {
            return await _service.GetDDL(orderId);
        }
    }
}