using AutoMapper;
using Data;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DireccionesLogic
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        //public List<direcciones> listaDirecciones(string email)
        //{
        //    return de.direccionesUsuario(email).ToList();
        //}

        public bool UpdateDireccion(DireccionesViewModel dwm)
        {
            direcciones direc = new direcciones();
            Mapper.Initialize(cfg => cfg.CreateMap<DireccionesViewModel, direcciones>());



            unitOfWork.DireccionesRepository.Update(Mapper.Map(dwm, direc));
            unitOfWork.Save();
            return true;
        }


        public DireccionesViewModel DireccionxId(int id)
        {
            DireccionesViewModel dvm = new DireccionesViewModel();
            var datos = unitOfWork.DireccionesRepository.GetByID(id);

            dvm.Direccion = datos.Direccion;
            dvm.Email = datos.Email;
            dvm.Id = datos.Id;
            dvm.Name = datos.Name;
            dvm.Sector = datos.Sector;
            dvm.listaCiudades = unitOfWork.CiudadesRepository.Get().ToList();
            dvm.listaEstados = unitOfWork.EstadosRepository.Get().ToList();
            dvm.listaSectores = unitOfWork.SectorRepository.Get().ToList();
            return dvm;
        }
    }
}
