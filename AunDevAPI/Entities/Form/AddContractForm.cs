using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AunDevAPI.Entities.Form
{
    public class AddContractForm
    {
        public string Summary { get; set; }
        public int ContractLength { get; set; }
        public bool? Status { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int DevId { get; set; }
    }
}
