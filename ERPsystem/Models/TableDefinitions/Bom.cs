using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class Bom
    {
        public int BomId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<BomItem> BomItems { get; set; } = new List<BomItem>();
    }
}
