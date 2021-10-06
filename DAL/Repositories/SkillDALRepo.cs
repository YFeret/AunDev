using ConnectionTool;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SkillDALRepo : ISkillDALRepo
    {
        private readonly Connection _connection;

        public SkillDALRepo(Connection connection)
        {
            _connection = connection;
        }

        public void AjouterSkill(SkillDAL skill)
        {
            Command cmd = new Command("INSERT INTO Skills Values (@Name)");
            cmd.AddParameter("Name", skill.Name);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Delete(int id)
        {
            Command cmd = new Command("SPDeleteSkills",true);
            cmd.AddParameter("SkillsId", id);
            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<SkillDAL> GetAll()
        {
            Command cmd = new Command("Select SkillsId,Name From Skills");
            return _connection.ExecuteReader(cmd, dr => dr.SkillToDal());
        }
    }
}
