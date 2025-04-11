using ERPsystem.Models.TableDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ERPsystem.Models;

namespace ERPsystem.Services
{
    class BomItemService
    {
        private readonly IServiceProvider _serviceProvider;

        private AppDbContext CreateDbContext()
        {
            var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<AppDbContext>();
        }
        public async Task<BomItem?> GetByIdAsync(int bomId, int itemId)
        {
            using var context = CreateDbContext();
            return await context.BomItems
                .Include(bi => bi.Item)
                .Include(bi => bi.Bom)
                .FirstOrDefaultAsync(bi => bi.BomId == bomId && bi.ItemId == itemId);
        }

        public async Task AddAsync(BomItem bomItem)
        {
            using var context = CreateDbContext();
            context.BomItems.Add(bomItem);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BomItem bomItem)
        {
            using var context = CreateDbContext();
            context.BomItems.Update(bomItem);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int bomId, int itemId)
        {
            using var context = CreateDbContext();
            var bomItem = await GetByIdAsync(bomId, itemId);
            if (bomItem != null)
            {
                context.BomItems.Remove(bomItem);
                await context.SaveChangesAsync();
            }
        }
    }
}
