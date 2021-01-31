using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly latamEntities context = new latamEntities();
        private GenericRepository<direcciones> direccionesRepository;
        private GenericRepository<estados> estadosRepository;
        private GenericRepository<ciudades> ciudadesRepository;
        private GenericRepository<consignatario> consignatarioRepository;
        private GenericRepository<Users> usuarioRepository;
        private GenericRepository<PasswordRecovery> passwordRecoveryRepository;
        private GenericRepository<Sector> sectoresRepository;
        //private GenericRepository<bitacoras> bitacorasRepository;
        public GenericRepository<direcciones> DireccionesRepository
        {
            get
            {

                if (this.direccionesRepository == null)
                {
                    this.direccionesRepository = new GenericRepository<direcciones>(context);
                }
                return direccionesRepository;
            }
        }

        public GenericRepository<ciudades> CiudadesRepository
        {
            get
            {

                if (this.ciudadesRepository == null)
                {
                    this.ciudadesRepository = new GenericRepository<ciudades>(context);
                }
                return ciudadesRepository;
            }
        }

        public GenericRepository<estados> EstadosRepository
        {
            get
            {

                if (this.estadosRepository == null)
                {
                    this.estadosRepository = new GenericRepository<estados>(context);
                }
                return estadosRepository;
            }
        }

        public GenericRepository<consignatario> ConsignatarioRepository
        {
            get
            {
                if (this.consignatarioRepository == null)
                {
                    this.consignatarioRepository = new GenericRepository<consignatario>(context);
                }
                return consignatarioRepository;
            }
        }

        public GenericRepository<Users> UsersRepository
        {
            get
            {
                if (this.usuarioRepository == null)
                {
                    this.usuarioRepository = new GenericRepository<Users>(context);
                }
                return usuarioRepository;
            }
        }

        public GenericRepository<PasswordRecovery> PasswordRecoveryRepository
        {
            get
            {
                if (this.passwordRecoveryRepository == null)
                {
                    this.passwordRecoveryRepository = new GenericRepository<PasswordRecovery>(context);
                }
                return passwordRecoveryRepository;
            }
        }


        public GenericRepository<Sector> SectorRepository
        {
            get
            {
                if (this.sectoresRepository == null)
                {
                    this.sectoresRepository = new GenericRepository<Sector>(context);
                }
                return sectoresRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
