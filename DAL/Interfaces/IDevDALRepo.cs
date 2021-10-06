using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDevDALRepo
    {
        DevDAL login(string email, string passwd);
        void Register(DevDAL dev);
        IEnumerable<DevDAL> Get();
        IEnumerable<DevDAL> GetBySkills();
        void SetSkill();
    }
}
