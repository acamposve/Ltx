using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WR
    {
        readonly latamEntities bd = new latamEntities();
        public List<WarehouseReceipts> lista() {
            return bd.WarehouseReceipts.Where(x => x.Status.Equals("InTransit")).ToList();

        }
    }
}
