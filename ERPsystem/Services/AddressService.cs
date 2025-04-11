using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPsystem.Models;
using ERPsystem.Models.TableDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ERPsystem.Services
{
    class AddressService
    {
        private readonly IServiceProvider _serviceProvider;
        private AppDbContext CreateDbContext()
        {
            var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<AppDbContext>();
        }

        public async Task AddAddressAsync(string country, string postalCode, string city, string street)
        {
            using var context = CreateDbContext();
            var address = new Address
            {
                Country = country,
                PostalCode = postalCode,
                City = city,
                Street = street
            };

            context.Addresses.Add(address);
            await context.SaveChangesAsync();
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            using var context = CreateDbContext();
            return await context.Addresses.ToListAsync();
        }
    }

}
