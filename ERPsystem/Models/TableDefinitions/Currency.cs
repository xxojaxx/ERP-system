using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class Currency
    {
        public string CurrencyId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public decimal ExchangeRate { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Supply> Supplies { get; set; } = new List<Supply>();
    }
}
