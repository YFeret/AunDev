using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClientBLLRepo
    {
        ClientBLL Login(string email, string passwd);

        void Register(ClientBLL client);
    }
}
