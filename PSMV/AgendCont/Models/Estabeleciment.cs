using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendCont.Models
{
    public class Estabeleciment
    {
        [Key]
        public int EstabelecimentId { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatorio!")]
        [Display(Name = "Estabelecimento")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Fone { get; set; }

        public int ProfissionalId { get; set; }

        public virtual Profissional Profissional { get; set; }
    }
}