using AutoMapper;
using Data;
using Data.ViewModels;
using Entidades.Incoming;
using Entidades.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class UsuarioLogic
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        readonly ConsignatarioData cd = new ConsignatarioData();

        public void GuardaConsignatario(ConsignatarioViewModel cons)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ConsignatarioViewModel, consignatario>());
            consignatario consigna = new consignatario();
            var consigna2 = Mapper.Map(cons, consigna);

            unitOfWork.ConsignatarioRepository.Insert(consigna2);


            var estado = unitOfWork.CiudadesRepository.Get(x => x.id_ciudad == cons.CityId).FirstOrDefault();
            direcciones dir = new direcciones
            {
                City = cons.CityId,
                Direccion = cons.Add1,
                Email = cons.Email,
                Name = "Principal",
                Sector = cons.Sector,
                State = estado.id_estado
            };

            unitOfWork.DireccionesRepository.Insert(dir);

            unitOfWork.Save();
        }

        public bool IsEmailExist(string emailID)
        {
            var v = unitOfWork.ConsignatarioRepository.Get(a => a.Email == emailID).FirstOrDefault();
            return v != null;
        }


        public LoginVIewModel message(LoginIn usuario)
        {
            LoginVIewModel lvm = new LoginVIewModel();
            var v = unitOfWork.ConsignatarioRepository.Get(x => x.Email == usuario.Login);
            if (v != null)
            {
                foreach (var item in v)
                {
                    if (!item.isEmailVerified.GetValueOrDefault())
                    {
                        lvm.message = "Please verify your email first";
                    }
                    if (string.Compare(Crypto.Hash(usuario.Password), item.AccessPassword) == 0)
                    {
                        lvm.passHash = 0;
                    }
                    else
                    {
                        lvm.message = "Invalid credential provided";
                    }
                }
            }
            else
            {
                lvm.message = "Invalid credential provided";
            }
            return lvm;
        }
        public UsuarioViewModel ObtenerUsuarioSesion(string email)
        {
            var usuario = unitOfWork.ConsignatarioRepository.Get(x => x.Email == email);

            var direcciones = unitOfWork.DireccionesRepository.Get(x => x.Email == email).ToList();

            List<AddressViewModel> ListaDirecciones = new List<AddressViewModel>();
            foreach (var item in direcciones)
            {
                AddressViewModel avm = new AddressViewModel();
                var city = unitOfWork.CiudadesRepository.Get(x => x.id_ciudad == item.City).FirstOrDefault();
                avm.Ciudad = city.ciudad;
                var estado = unitOfWork.EstadosRepository.Get(x => x.id_estado == item.State).FirstOrDefault();
                avm.Estado = estado.estado;
                avm.Direccion = item.Direccion;
                avm.Email = item.Email;
                avm.Id = item.Id;
                avm.Name = item.Name;

                ListaDirecciones.Add(avm);
            }

            UsuarioViewModel uvm = new UsuarioViewModel();
            foreach (var item in usuario)
            {
                uvm.apellido = item.apellido;
                uvm.Name = item.Name;
                uvm.idConsignatario = item.idConsignatario;
            }

            uvm.direccionesUsuario = ListaDirecciones;
            return uvm;
        }
        public UsuarioViewModel DatosUsuario(string email)
        {
            var usuario = unitOfWork.ConsignatarioRepository.Get(x => x.Email == email);

            var direcciones = unitOfWork.DireccionesRepository.Get(x => x.Email == email);
            //bd.pa_ususarioxemail(email);
            UsuarioViewModel uvm = new UsuarioViewModel();
            foreach (var item in usuario)
            {
                uvm.apellido = item.apellido;
                uvm.Name = item.Name;
                uvm.idConsignatario = item.idConsignatario;





            }


            return uvm;

        }

        public ConsignatarioViewModel registro()
        {
            return cd.EstadosLista();
        }
        public consignatario VerificarRegistro(Guid id)
        {
            var v = unitOfWork.ConsignatarioRepository.Get(a => a.ActivationCode == id).FirstOrDefault();
            if (v != null)
            {
                v.isEmailVerified = true;
                unitOfWork.ConsignatarioRepository.Update(v);
                unitOfWork.Save();
            }
            return v;
        }
    }
}
