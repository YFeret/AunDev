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
    public class DevBLLRepo : IDevBLLRepo
    {
        private readonly IDevDALRepo _devDALRepo;

        public DevBLLRepo(IDevDALRepo devDALRepo)
        {
            _devDALRepo = devDALRepo;
        }

        public IEnumerable<DevBLL> Get()
        {
            return _devDALRepo.Get().Select(d => d.ToBLL());
        }

        public IEnumerable<DevBLL> GetBySkills()
        {
            return _devDALRepo.GetBySkills().Select(d => d.ToBLL());
        }

        public DevBLL login(string email, string passwd)
        {
            return _devDALRepo.login(email, passwd).ToBLL();
        }

        public void Register(DevBLL dev)
        {
            _devDALRepo.Register(dev.ToBLL());
        }

        public void SetSkill()
        {
            throw new NotImplementedException();
        }
    }
}
