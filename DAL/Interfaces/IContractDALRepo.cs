using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IContractDALRepo
    {
        void AddContract(ContractDAL contract,int clientId,int devId);
        ContractDAL GetByDevId(ContractDAL contract,int Id);
        ContractDAL GetByClientId(ContractDAL contract,int Id);
        void Delete(int id);
        void Accept(int Id);
        void Decline(int Id);
    }
}
