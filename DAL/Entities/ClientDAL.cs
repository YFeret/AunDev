using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ClientDAL
    {
        public int ClientId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}
