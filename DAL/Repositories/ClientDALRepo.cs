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
    public class ClientDALRepo : IClientDALRepo
    {
        private readonly Connection _connection;

        public ClientDALRepo(Connection connection)
        {
            _connection = connection;
        }

        public ClientDAL Login(string email, string passwd)
        {
            Command command = new Command("SPLoginClient", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, dr => dr.ClientToDAL()).SingleOrDefault();
        }

        public void Register(ClientDAL client)
        {
            Command cmd = new Command("SPAddClient",true);
            cmd.AddParameter("Lastname", client.Lastname);
            cmd.AddParameter("Firstname", client.Firstname);
            cmd.AddParameter("Company", client.Company);
            cmd.AddParameter("Phone", client.Phone);
            cmd.AddParameter("Email", client.Email);
            cmd.AddParameter("Passwd", client.Passwd);
            _connection.ExecuteNonQuery(cmd);
            
            client.Passwd = null;
        }
    }
}
