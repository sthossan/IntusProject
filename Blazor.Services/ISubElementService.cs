using Blazor.Models;
using Blazor.ViewModels;

namespace Blazor.Services
{
    public interface ISubElementService
    {
        List<SubElements> GetList(int orderId, int windowId);
        Task<ApiResponse> InsertUpdateAync(SubElements model);
        Task<ApiResponse> RemoveAync(int id);
    }
}
