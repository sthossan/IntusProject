using Blazor.Models;
using Blazor.Models.Context;
using Blazor.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Blazor.Services
{
    public class WindowsService : IWindowsService
    {
        private readonly ApplicationDbContext _context;

        public WindowsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Windows> GetList(int orderId)
        {
            return _context.Windows.Where(t => t.OrderId == orderId).OrderBy(t => t.Id).ToList();
        }

        public async Task<ApiResponse> InsertUpdateAync(Windows model)
        {
            ApiResponse response = new();
            try
            {
                if (await _context.Windows.AnyAsync(t => t.Id != model.Id && t.OrderId == model.OrderId && t.Name == model.Name))
                {
                    response.Status = false;
                    response.Message = "Duplicate data";
                }

                if (model.Id == 0)
                {
                    _context.Windows.Add(model);
                }
                else
                {
                    _context.Windows.Update(model);
                }

                _context.SaveChanges();

                response.Status = true;
                response.Message = model.Id == 0 ? "Data Save Successfully" : "Data Update Successfully";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> RemoveAync(int id)
        {
            ApiResponse response = new();
            try
            {
                var window = await _context.Windows.FirstOrDefaultAsync(t => t.Id == id);
                var elementList = _context.SubElements.Where(t => t.WindowId == id).ToList();

                if (window != null)
                    _context.Windows.Remove(window);
                if (elementList.Count > 0)
                    _context.SubElements.RemoveRange(elementList);

                await _context.SaveChangesAsync();

                response.Status = id != 0;
                response.Message = id != 0 ? $"{window.Name} remove successfull" : "Data not found";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<IEnumerable<DdlViewModel>> GetDDL(int orderId)
        {
            var data = await _context.Windows.Where(t => t.OrderId == orderId).OrderBy(t => t.Id)
                            .Select(t => new DdlViewModel
                            {
                                WindowId = t.Id,
                                Name = t.Name,
                            }).ToListAsync();
            return data;
        }
    }
}
