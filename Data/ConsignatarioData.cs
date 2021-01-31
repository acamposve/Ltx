using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ConsignatarioData
    {
        private readonly latamEntities le = new latamEntities();
        public ConsignatarioViewModel EstadosLista()
        {
            ConsignatarioViewModel cvm = new ConsignatarioViewModel();

            List<estados> lecvm = new List<estados>();
            List<ciudades> lecity = new List<ciudades>();
            List<Sector> lesector = new List<Sector>();

            var listaEstados = le.estados.ToList();
            var listaCiudades = le.ciudades.ToList();
            var listaSectores = le.Sector.ToList();
            foreach (var item in listaEstados)
            {
                estados ecvm = new estados
                {
                    estado = item.estado,
                    id_estado = item.id_estado
                };
                lecvm.Add(ecvm);
            }


            foreach (var item in listaCiudades)
            {
                ciudades ecvm = new ciudades
                {
                    ciudad = item.ciudad,
                    id_ciudad = item.id_ciudad,
                    id_estado = item.id_estado
                };
                lecity.Add(ecvm);
            }
            cvm.listaEstados = lecvm;
            cvm.listaCiudades = lecity;
            cvm.listaSectores = listaSectores;

            return cvm;
        }
    }
}
