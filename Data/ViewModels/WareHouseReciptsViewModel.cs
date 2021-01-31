using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class WareHouseReciptsViewModel
    {

        public string GUID { get; set; }
        public string Number { get; set; }
        public int TotalPieces { get; set; }
        public int codeWR { get; set; }
        public string TotalWeight { get; set; }
        public string TotalVolume { get; set; }
        public string TotalVolumeWeight { get; set; }
        public string CreatedOn { get; set; }

        public string Status { get; set; }
        public string Shipper { get; set; }
    }
}
