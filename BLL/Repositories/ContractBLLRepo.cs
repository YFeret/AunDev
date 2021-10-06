using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class ContractBLLRepo : IContractBLLRepo
    {
        private readonly IContractDALRepo _contractDALRepo;

        public ContractBLLRepo(IContractDALRepo contractDALRepo)
        {
            _contractDALRepo = contractDALRepo;
        }


        public void AddContract(ContractBLL contract, int clientId, int devId)
        {
            _contractDALRepo.AddContract(contract.ToDAL(), clientId, devId);
        }
        public void Accept(int devId)
        {
            _contractDALRepo.Accept(devId);
        }

        public void Decline(int devId)
        {
            _contractDALRepo.Decline(devId);
        }

        public void Delete(int id)
        {
            _contractDALRepo.Delete(id);
        }

        public ContractBLL GetByClientId(ContractBLL contract, int clientId)
        {
            return _contractDALRepo.GetByClientId(contract.ToDAL(), clientId).ToBLL();
        }

        public ContractBLL GetByDevId(ContractBLL contract, int devId)
        {
            return _contractDALRepo.GetByClientId(contract.ToDAL(), devId).ToBLL();
        }
    }
}
