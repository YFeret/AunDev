using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AunDevAPI.Entities.Form
{
    public class RegisterDevForm
    {
        [DisplayName("Nom :")]
        [Required]
        public string Lastname { get; set; }
        [DisplayName("Prenom :")]
        [Required]
        public string Firstname { get; set; }
        [DisplayName("Annee de naissance :")]
        [Required]
        public DateTime BirthDate { get; set; }
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
