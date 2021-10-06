using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class ContractBLL
    {
        public int ContractId { get; set; }
        public string Summary { get; set; }
        public int ContractLength { get; set; }
        public bool? Status { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int DevId { get; set; }
    }
}
