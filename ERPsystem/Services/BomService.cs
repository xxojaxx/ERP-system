using ERPsystem.Models;
using ERPsystem.Models.TableDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Services
{
    class BomService
    {
        private readonly IServiceProvider _serviceProvider;

        private AppDbContext CreateDbContext()
        {
            var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<AppDbContext>();
        }

        public async Task<List<Bom>> GetAllAsync()
        {
            using var context = CreateDbContext();
            return await context.Boms
                .Include(b => b.BomItems)         
                .ThenInclude(bi => bi.Item)          
                .ToListAsync();
        }
        public async Task<Bom> GetByIdAsync(int bomId)
        {
            using var context = CreateDbContext();
            return await context.Boms
                .Include(b => b.BomItems)
                .ThenInclude(bi => bi.Item)
                .FirstOrDefaultAsync(b => b.BomId == bomId);
        }

        public async Task AddAsync(Bom bom)
        {
            using var context = CreateDbContext();
            context.Boms.Add(bom);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bom bom)
        {
            using var context = CreateDbContext();
            context.Boms.Update(bom);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = CreateDbContext();
            var bom = await GetByIdAsync(id);
            if (bom != null)
            {
                context.Boms.Remove(bom);
                await context.SaveChangesAsync();
            }
        }
    }
}
