using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISkillDALRepo
    {
        void AjouterSkill(SkillDAL skill);
        void Delete(int id);
        IEnumerable<SkillDAL> GetAll();
    }
}
