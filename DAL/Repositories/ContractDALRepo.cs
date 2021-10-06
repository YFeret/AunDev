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
    public class ContractDALRepo : IContractDALRepo
    {
        private readonly Connection _connection;
        public ContractDALRepo(Connection connection)
        {
            _connection = connection;
        }


        public void AddContract(ContractDAL contract, int clientId, int devId)
        {
            Command cmd = new Command("INSERT INTO Summary,ContractLength,Status,Description,ClientId,DevId Contract"+ 
                                      "VALUES (@Summary,@ContractLength,@Status,@Description,@ClientId,@DevId)");
            cmd.AddParameter("Summary", contract.Summary);
            cmd.AddParameter("ContractLength", contract.ContractLength);
            cmd.AddParameter("Status", null);
            cmd.AddParameter("Description", contract.Description);
            cmd.AddParameter("clientId", clientId);
            cmd.AddParameter("devId", devId);
            _connection.ExecuteNonQuery(cmd);
        }
        public void Accept(int devId)
        {
            Command cmd = new Command("UPDATE Contract SET Status = @Status WHERE DevId = @DevId");
            cmd.AddParameter("Status",true);
            cmd.AddParameter("DevId",devId);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Decline(int devId)
        {
            Command cmd = new Command("UPDATE Contract SET Status = @Status WHERE DevId = @DevId");
            cmd.AddParameter("Status", false);
            cmd.AddParameter("DevId", devId);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Contract WHERE ContractId = @ContractId");
            cmd.AddParameter("ContractId", id);
            _connection.ExecuteNonQuery(cmd);
        }

        public ContractDAL GetByClientId(ContractDAL contract, int clientId)
        {
            Command cmd = new Command("Select ContractId,Summary,ContractLength,Status,Description,ClientId,DevId FROM Contract" +
                                      "WHERE ClientId = @ClientId");
            cmd.AddParameter("ClientId",clientId);
            return _connection.ExecuteReader(cmd, dr => dr.ContractToDAL()).SingleOrDefault();
        }

        public ContractDAL GetByDevId(ContractDAL contract, int devId)
        {
            Command cmd = new Command("Select ContractId,Summary,ContractLength,Status,Description,ClientId,DevId FROM Contract" +
                                                  "WHERE DevId = @DevId");
            cmd.AddParameter("DevId", devId);
            return _connection.ExecuteReader(cmd, dr => dr.ContractToDAL()).SingleOrDefault();
        }
    }
}
