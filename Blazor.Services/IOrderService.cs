using Blazor.Models;
using Blazor.ViewModels;

namespace Blazor.Services
{
    public interface IOrderService
    {
        List<Orders> GetList();
        Task<ApiResponse> InsertUpdateAync(Orders model);
        Task<ApiResponse> RemoveAync(int id);
        Task<IEnumerable<DdlViewModel>> GetDDL();
    }
}
