using Microsoft.EntityFrameworkCore;

namespace Blazor.Models.Context
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>().HasData(
                new Orders { Id = 1, Name = "New York Building 1", State = "NY" },
                new Orders { Id = 2, Name = "California Hotel AJK", State = "CA" }
            );

            modelBuilder.Entity<Windows>().HasData(
                new Windows { Id = 1, OrderId = 1, Name = "A51", QuantityOfWindows = 4, TotalSubElements = 3 },
                new Windows { Id = 2, OrderId = 1, Name = "C Zone 5", QuantityOfWindows = 2, TotalSubElements = 1 },

                new Windows { Id = 3, OrderId = 2, Name = "GLB\" QuantityOfWindows", QuantityOfWindows = 3, TotalSubElements = 2 },
                new Windows { Id = 4, OrderId = 2, Name = "OHF", QuantityOfWindows = 10, TotalSubElements = 2 }
            );

            modelBuilder.Entity<SubElements>().HasData(
                new SubElements { Id = 1, OrderId = 1, WindowId = 1, Element = 1, Type = "Doors", Width = 1200, Height = 1850 },
                new SubElements { Id = 2, OrderId = 1, WindowId = 1, Element = 2, Type = "Window", Width = 800, Height = 1850 },
                new SubElements { Id = 3, OrderId = 1, WindowId = 1, Element = 3, Type = "Window", Width = 700, Height = 1850 },

                new SubElements { Id = 4, OrderId = 1, WindowId = 2, Element = 1, Type = "Window", Width = 1500, Height = 2000 },

                new SubElements { Id = 5, OrderId = 2, WindowId = 3, Element = 1, Type = "Doors", Width = 1400, Height = 2200 },
                new SubElements { Id = 6, OrderId = 2, WindowId = 3, Element = 1, Type = "Window", Width = 600, Height = 2200 },

                new SubElements { Id = 7, OrderId = 2, WindowId = 4, Element = 1, Type = "Window", Width = 1500, Height = 2000 },
                new SubElements { Id = 8, OrderId = 2, WindowId = 4, Element = 1, Type = "Window", Width = 1500, Height = 2000 }
            );
        }
    }
}