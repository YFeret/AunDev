using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal = DAL.Entities;
using bll = BLL.Entities;
namespace BLL.Mappers
{
    internal static class Mappers
    {
        //Mapper Client BLL -> DAL / DAL -> BLL
        internal static bll.ClientBLL ToBLL(this dal.ClientDAL client)
        {
            return new bll.ClientBLL()
            {
                Id = client.ClientId, 
                Lastname = client.Lastname, 
                Firstname = client.Firstname, 
                Company = client.Company, 
                Phone = client.Phone, 
                Email = client.Email
            };
        }
        internal static dal.ClientDAL ToDAL(this bll.ClientBLL client)
        {
            return new dal.ClientDAL()
            {
                ClientId = client.Id,
                Lastname = client.Lastname,
                Firstname = client.Firstname,
                Company = client.Company,
                Phone = client.Phone,
                Email = client.Email,
                Passwd = client.Passwd
            };
        }
        //Mapper Skills BLL -> DAL / DAL -> BLL
        internal static bll.SkillBLL ToBLL(this dal.SkillDAL skill)
        {
            return new bll.SkillBLL()
            {
                SkillId = skill.Id,
                Name = skill.Name
            };
        }
        internal static dal.SkillDAL ToDAL(this bll.SkillBLL skill)
        {
            return new dal.SkillDAL()
            {
                Id = skill.SkillId,
                Name = skill.Name
            };
        }
        //Mapper Dev BLL -> DAL / DAL -> BLL
        internal static bll.DevBLL ToBLL(this dal.DevDAL dev)
        {
            return new bll.DevBLL()
            {
                Id = dev.Id,
                Lastname = dev.Lastname,
                Firstname = dev.Firstname,
                BirthDate = dev.BirthDate,
                Phone = dev.Phone,
                Email = dev.Email,
                Passwd = dev.Passwd
            };
        }
        internal static dal.DevDAL ToBLL(this bll.DevBLL dev)
        {
            return new dal.DevDAL()
            {
                Id = dev.Id,
                Lastname = dev.Lastname,
                Firstname = dev.Firstname,
                BirthDate = dev.BirthDate,
                Phone = dev.Phone,
                Email = dev.Email,
                Passwd = dev.Passwd
            };
        }
        //mapper Contract BLL -> DAL / DAL -> BLL
        internal static bll.ContractBLL ToBLL(this dal.ContractDAL contract)
        {
            return new bll.ContractBLL()
            {
                ContractId = contract.ContractId,
                Summary = contract.Summary,
                ContractLength = contract.ContractLength,
                Status = contract.Status,
                Description = contract.Description,
                ClientId = contract.ClientId,
                DevId = contract.DevId
            };
        }
        internal static dal.ContractDAL ToDAL(this bll.ContractBLL contract)
        {
            return new dal.ContractDAL()
            {
                ContractId = contract.ContractId,
                Summary = contract.Summary,
                ContractLength = contract.ContractLength,
                Status = contract.Status,
                Description = contract.Description,
                ClientId = contract.ClientId,
                DevId = contract.DevId
            };
        }
    }
}
