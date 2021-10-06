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
    public class DevDALRepo : IDevDALRepo
    {
        private readonly Connection _connection;
        public DevDALRepo(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<DevDAL> Get()
        {
            Command cmd = new Command("SELECT DevId,Lastname,Firstname,BirthDate,Phone,Email FROM Dev");
            return _connection.ExecuteReader(cmd, dr => dr.DEVToDAL());
        }

        public IEnumerable<DevDAL> GetBySkills()
        {
            //TODO
            throw new NotImplementedException();
        }

        public DevDAL login(string email, string passwd)
        {
            Command cmd = new Command("SPLoginDev", true);
            cmd.AddParameter("Email",email);
            cmd.AddParameter("Passwd",passwd);
            return _connection.ExecuteReader(cmd, d => d.DEVToDAL()).SingleOrDefault();
        }

        public void Register(DevDAL dev)
        {
            Command cmd = new Command("SPRegisterDev", true);
            cmd.AddParameter("Lastname", dev.Lastname);
            cmd.AddParameter("Firstname", dev.Firstname);
            cmd.AddParameter("BirthDate", dev.BirthDate);
            cmd.AddParameter("Phone", dev.Phone);
            cmd.AddParameter("Email", dev.Email);
            cmd.AddParameter("Passwd", dev.Passwd);
            _connection.ExecuteNonQuery(cmd);
        }

        public void SetSkill()
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
