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
    public class SkillBLLRepo : ISkillBLLRepo
    {
        private readonly ISkillDALRepo _skillDALRepo;
        public SkillBLLRepo(ISkillDALRepo skillDALRepo)
        {
            _skillDALRepo = skillDALRepo;
        }

        public void AjouterSkill(SkillBLL skill)
        {
            _skillDALRepo.AjouterSkill(skill.ToDAL());
        }

        public void Delete(int id)
        {
            _skillDALRepo.Delete(id);
        }

        public IEnumerable<SkillBLL> GetAll()
        {
            return _skillDALRepo.GetAll().Select(s => s.ToBLL());
        }
    }
}
