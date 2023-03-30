using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LojaDeReparações.Models
{
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Indique um nome de utilizador")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Indique um email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Indique um perfil de utilizador")]
        public int Perfil { get; set; }
        [Display(Name = "Estado da Conta")]
        public bool Estado { get; set; }

        //dropdown perfil
        public IEnumerable<System.Web.Mvc.SelectListItem> Perfis { get; set; }

        public Utilizador()
        {
            Estado = true;
        }
    }
}