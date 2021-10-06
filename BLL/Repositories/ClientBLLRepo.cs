using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using ConnectionTool;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class ClientBLLRepo : IClientBLLRepo
    {
        private readonly IClientDALRepo _clientDALRepo;

        public ClientBLLRepo(IClientDALRepo clientDALRepo)
        {
            _clientDALRepo = clientDALRepo;
        }

        public ClientBLL Login(string email, string passwd)
        {
            return _clientDALRepo.Login(email, passwd).ToBLL();
        }

        public void Register(ClientBLL client)
        {
            _clientDALRepo.Register(client.ToDAL());
        }


    }
}
