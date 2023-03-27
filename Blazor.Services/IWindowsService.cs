using Blazor.Models;
using Blazor.ViewModels;

namespace Blazor.Services
{
    public interface IWindowsService
    {
        List<Windows> GetList(int orderId);
        Task<ApiResponse> InsertUpdateAync(Windows model);
        Task<ApiResponse> RemoveAync(int id);
        Task<IEnumerable<DdlViewModel>> GetDDL(int orderId);

    }
}
