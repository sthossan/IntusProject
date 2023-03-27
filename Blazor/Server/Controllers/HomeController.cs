using Blazor.Models;
using Blazor.Services;
using Blazor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blazor.Server.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public HomeController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public List<Orders> GetOrderList()
        {
            return _orderService.GetList();
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> CreateAync(Orders model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(s => s.Errors).Select(t => t.ErrorMessage));
                ModelState.AddModelError(string.Empty, errors);
                return new ApiResponse { Status = false, Message = errors };
            }
            return await _orderService.InsertUpdateAync(model);
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> RemoveAync(int id)
        {
            return await _orderService.RemoveAync(id);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<DdlViewModel>> GetDDL()
        {
            return await _orderService.GetDDL();
        }
    }
}