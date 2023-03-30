using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaDeReparações.Models
{
    public class Dispositivo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("utilizador")]
        [Required(ErrorMessage = "Tem de indicar o cliente")]
        public int IdUtilizador { get; set; }
        public Utilizador utilizador { get; set; }

        [Required(ErrorMessage = "Indique a marca do dispositivo")]
        [MinLength(2, ErrorMessage = "Marca de dispositivo muito pequena")]
        [UIHint("HP/Asus/Xiaomi/Samsung/Apple/...")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Indique o problema do dispositivo")]
        [MinLength(2, ErrorMessage = "Descreva melhor o problema")]
        public string Problema { get; set; }

        [Required(ErrorMessage = "Indique o tipo do dispositivo")]
        [MinLength(3, ErrorMessage = "Tipo de dispositivo muito pequeno")]
        [UIHint("Computador/Telemóvel/Televisão")]
        public string Tipo { get; set; }
        public bool Estado {get; set; }

        public Dispositivo()
        {
            Estado = false;
        }
    }
}