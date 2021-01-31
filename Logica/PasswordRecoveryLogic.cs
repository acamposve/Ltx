using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PasswordRecoveryLogic
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        public string IsEmailRecoverExist(string emailID)
        {
            
            var v = unitOfWork.PasswordRecoveryRepository.Get(a => a.RecoveryKey == Guid.Parse(emailID)).FirstOrDefault();
            return v.Email;
        }

        public void actualizaPass(consignatario Consigna)
        {
            var dato = unitOfWork.ConsignatarioRepository.Get(x => x.Email == Consigna.Email).FirstOrDefault();
            dato.AccessPassword = Consigna.AccessPassword;
            unitOfWork.ConsignatarioRepository.Update(dato);
            unitOfWork.Save();
        }
        public void InsertPR(PasswordRecovery pr)
        {
            unitOfWork.PasswordRecoveryRepository.Insert(pr);
            unitOfWork.Save();
        }
    }
}
