using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AunDevAPI.Entities.Form
{
    public class RegisterClientForm
    {
        [DisplayName("Nom :")]
        [Required]
        public string Lastname { get; set; }
        [DisplayName("Prenom :")]
        [Required]
        public string Firstname { get; set; }
        [DisplayName("Sociéte :")]
        [Required]
        public string Company { get; set; }
        [DisplayName("Numero de telephone :")]
        [Required]
        public string Phone { get; set; }
        [DisplayName("Email :")]
        [Required]
        public string Email { get; set; }
        [DisplayName("Mot de passe :")]
        [Required]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
    }
}
