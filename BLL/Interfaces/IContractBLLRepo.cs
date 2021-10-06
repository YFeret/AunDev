using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IContractBLLRepo
    {
        void AddContract(ContractBLL contract, int clientId, int devId);
        ContractBLL GetByDevId(ContractBLL contract, int devId);
        ContractBLL GetByClientId(ContractBLL contract, int clientId);
        void Delete(int id);
        void Accept(int devId);
        void Decline(int devId);
    }
}
