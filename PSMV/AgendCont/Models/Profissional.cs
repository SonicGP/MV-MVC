using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendCont.Models
{
    public class Profissional
    {
        [Key]
        public int ProfissionalId { get; set; }

        [Required(ErrorMessage = "Campo é Obrigatorio!")]
        [Display(Name = "Profissional")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Fone { get; set; }

        [Display(Name = "Função")]
        public string Funcao { get; set; }

        public virtual ICollection<Estabeleciment> Estabeleciments { get; set; }
    }
}