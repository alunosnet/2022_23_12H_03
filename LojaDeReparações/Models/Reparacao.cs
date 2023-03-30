using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaDeReparações.Models
{
    public class Reparacao
    {
        [Key]
        public int Id { get; set; }

        //--------------- FK
        [ForeignKey("dispositivo")]
        public int IdDispositivo { get; set; }
        public Dispositivo dispositivo { get; set; }

        //--------------- FK
        [ForeignKey("utilizador")]
        public int IdCliente { get; set; }
        public Utilizador utilizador { get; set; }

        //--------------- FK
        [ForeignKey("u")]
        public int IdFuncionario { get; set; }
        public Utilizador u { get; set; }

        //---------------

        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime data_inicio { get; set; }

        [Display(Name = "Data de Finalização")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime data_fim { get; set; }
        public int Estado { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public double preco { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Estados { get; set; }

        public Reparacao()
        {
            Estado = 0;
            data_inicio = DateTime.Now;
        }
    }
}