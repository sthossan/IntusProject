using Blazor.Models;
using Blazor.Models.Context;
using Blazor.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly ApplicationDbContext _context;

        public SubElementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SubElements> GetList(int orderId, int windowId)
        {
            return _context.SubElements.Where(t => t.OrderId == orderId && t.WindowId == windowId).OrderBy(t => t.Id).ToList();
        }

        public async Task<ApiResponse> InsertUpdateAync(SubElements model)
        {
            ApiResponse response = new();
            try
            {
                if (model.Id == 0)
                {
                    await _context.SubElements.AddAsync(model);
                    var window = await _context.Windows.FirstOrDefaultAsync(t => t.Id == model.WindowId);
                    window.TotalSubElements += 1;
                    _context.Windows.Update(window);
                }
                else
                {
                    _context.SubElements.Update(model);
                }

                await _context.SaveChangesAsync();

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
                var element = await _context.SubElements.FirstOrDefaultAsync(t => t.Id == id);

                if (element != null)
                {
                    _context.SubElements.Remove(element);

                    var window = await _context.Windows.FirstOrDefaultAsync(t => t.Id == element.WindowId);
                    window.TotalSubElements -= 1;
                    _context.Windows.Update(window);

                    await _context.SaveChangesAsync();
                }
                response.Status = id != 0;
                response.Message = id != 0 ? $"{element.Type} remove successfull" : "Data not found";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}