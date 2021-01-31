using Data;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class WR
    {

        public List<WareHouseReciptsViewModel> ListaWR()
        {
            Data.WR ware = new Data.WR();

            List<WareHouseReciptsViewModel> wrm = new List<WareHouseReciptsViewModel>();
            List<WarehouseReceipts> datos = ware.lista();
            for (int i = 0; i < datos.Count; i++)
            {
                WareHouseReciptsViewModel wr = new WareHouseReciptsViewModel
                {
                    GUID = datos[i].GUID,
                    Number = datos[i].Number,
                    TotalPieces = datos[i].TotalPieces.GetValueOrDefault(),

                    codeWR = datos[i].codeWR
                };
                decimal volumeweight = Math.Round(decimal.Parse(datos[i].TotalVolumeWeight), 2);
                decimal volume = Math.Round(decimal.Parse(datos[i].TotalVolume), 2);

                decimal weight = Math.Round(decimal.Parse(datos[i].TotalWeight), 2);
                wr.TotalVolume = String.Format("{0:.##}", volume);
                wr.TotalVolumeWeight = String.Format("{0:.##}", volumeweight);

                wr.TotalWeight = String.Format("{0:.##}", weight);
                int day = datos[i].CreatedOn.Value.Day;
                var month = datos[i].CreatedOn.Value.Month;
                var year = datos[i].CreatedOn.Value.Year;
                string fecha = day + "/" + month + "/" + year;



                wr.CreatedOn = fecha;

                wr.Status = datos[i].Status;
                wr.Shipper = "Prueba";

                wrm.Add(wr);

            }
            return wrm;


        }

        //public IEnumerable<WareHouseReceiptsItems> listaWRById(int ID)
        //{
        //    return de.ReciptById(ID);
        //}
    }
}
