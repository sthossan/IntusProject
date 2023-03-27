using Blazor.Models;
using Blazor.Models.Context;
using Blazor.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Blazor.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Orders> GetList()
        {
            return _context.Orders.OrderBy(t => t.Id).ToList();
        }

        public async Task<ApiResponse> InsertUpdateAync(Orders model)
        {
            ApiResponse response = new();
            try
            {
                if (await _context.Orders.AnyAsync(t => t.Id != model.Id && t.Name == model.Name && t.State == model.State))
                {
                    response.Status = false;
                    response.Message = "Duplicate data";
                }

                if (model.Id == 0)
                {
                    _context.Orders.Add(model);
                }
                else
                {
                    _context.Orders.Update(model);
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
                var order = _context.Orders.FirstOrDefault(t => t.Id == id);
                var windowList = _context.Windows.Where(t => t.OrderId == id).ToList();
                var elementList = _context.SubElements.Where(t => t.OrderId == id).ToList();

                if (order != null)
                    _context.Orders.Remove(order);
                if (windowList.Count > 0)
                    _context.Windows.RemoveRange(windowList);
                if (elementList.Count > 0)
                    _context.SubElements.RemoveRange(elementList);

                await _context.SaveChangesAsync();

                response.Status = id != 0;
                response.Message = id != 0 ? $"{order.Name} remove successfull" : "Data not found";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<IEnumerable<DdlViewModel>> GetDDL()
        {
            var data = await _context.Orders.OrderBy(t => t.Id)
                            .Select(t => new DdlViewModel
                            {
                                OrderId = t.Id,
                                Name = t.Name,
                            }).ToListAsync();
            return data;
        }
    }
}