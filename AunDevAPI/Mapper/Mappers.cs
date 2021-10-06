using API = AunDevAPI.Entities;
using bll = BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AunDevAPI.Entities.Form;

namespace AunDevAPI.Mapper
{
    public static class Mappers
    {
        public static bll.ClientBLL ToBLL(this RegisterClientForm form)
        {
            return new bll.ClientBLL()
            {
                Lastname = form.Lastname,
                Firstname = form.Firstname, 
                Company = form.Company, 
                Phone = form.Phone, 
                Email = form.Email, 
                Passwd = form.Passwd
            };
        }
        public static bll.SkillBLL ToBLL(this SkillForm form)
        {
            return new bll.SkillBLL()
            {
                Name = form.Name
            };
        }
        public static bll.DevBLL ToBLL(this RegisterDevForm form)
        {
            return new bll.DevBLL()
            {
                Lastname = form.Lastname,
                Firstname = form.Firstname,
                BirthDate = form.BirthDate,
                Phone = form.Phone,
                Email = form.Email,
                Passwd = form.Passwd
            };
        }

        public static bll.ContractBLL ToBLL(this AddContractForm form)
        {
            return new bll.ContractBLL()
            {
                Summary = form.Summary,
                ContractLength = form.ContractLength,
                Status = form.Status,
                Description = form.Description,
                ClientId = form.ClientId,
                DevId = form.DevId
            };
        }
    }
}
