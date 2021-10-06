using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDevBLLRepo
    {
        DevBLL login(string email, string passwd);
        void Register(DevBLL dev);
        IEnumerable<DevBLL> Get();
        IEnumerable<DevBLL> GetBySkills();
        void SetSkill();
    }
}
