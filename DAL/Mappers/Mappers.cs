using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static class Mappers
    {
        //mapper Client
        internal static ClientDAL ClientToDAL(this IDataRecord data)
        {
            return new ClientDAL()
            {
                ClientId = (int)data["ClientId"],
                Lastname = data["Lastname"].ToString(),
                Firstname = data["Firstname"].ToString(),
                Company = data["Company"].ToString(),
                Phone = data["Phone"].ToString(),
                Email = data["Email"].ToString()
            };
        }
        //mapper Skill
        internal static SkillDAL SkillToDal(this IDataRecord data)
        {
            return new SkillDAL()
            {
                Id = (int)data["SkillsId"],
                Name = data["Name"].ToString()
            };
        }
        //mapper Dev
        internal static DevDAL DEVToDAL(this IDataRecord data)
        {
            return new DevDAL()
            {
                Id = (int)data["DevId"],
                Lastname = data["Lastname"].ToString(),
                Firstname = data["Firstname"].ToString(),
                BirthDate = (DateTime)data["BirthDate"],
                Phone = data["Phone"].ToString(),
                Email = data["Email"].ToString()
            };
        }
        //mapper Contract
        internal static ContractDAL ContractToDAL(this IDataRecord data)
        {
            return new ContractDAL()
            {
                ContractId = (int)data["ContractId"],
                Summary = data["Summary"].ToString(),
                ContractLength = (int)data["ContractLength"],
                Status = (data["Status"] is DBNull) ? null : (bool?)data["Status"],
                Description = data["Description"].ToString(),
                ClientId = (int)data["ClientId"],
                DevId = (int)data["DevId"],
            };
        }
    }
}
