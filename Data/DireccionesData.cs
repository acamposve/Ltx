using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DireccionesData
    {
        private latamEntities le = new latamEntities();
        public DireccionesViewModel estadosLista()
        {
            DireccionesViewModel cvm = new DireccionesViewModel();

            List<estados> lecvm = new List<estados>();
            List<ciudades> lecity = new List<ciudades>();

            var listaEstados = le.estados.ToList();
            var listaCiudades = le.ciudades.ToList();

            foreach (var item in listaEstados)
            {
                estados ecvm = new estados();

                ecvm.estado = item.estado;
                ecvm.id_estado = item.id_estado;
                lecvm.Add(ecvm);
            }


            foreach (var item in listaCiudades)
            {
                ciudades ecvm = new ciudades();

                ecvm.ciudad = item.ciudad;
                ecvm.id_ciudad = item.id_ciudad;
                ecvm.id_estado = item.id_estado;
                lecity.Add(ecvm);
            }
            cvm.listaEstados = lecvm;
            cvm.listaCiudades = lecity;

            return cvm;
        }
    }
}
