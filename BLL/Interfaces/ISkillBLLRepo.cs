using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISkillBLLRepo
    {
        void AjouterSkill(SkillBLL skill);
        void Delete(int id);
        IEnumerable<SkillBLL> GetAll();
    }
}
