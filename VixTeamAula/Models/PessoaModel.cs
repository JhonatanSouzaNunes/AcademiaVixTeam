using System.ComponentModel.DataAnnotations;
namespace VixTeamAula.Models
{
    public class PessoaModel
    {

        [Key]
        public int codigo { get; set; }
        
        [Display(Name ="Nome")]
        public string NomePessoa { get; set; }
       
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Filhos")]
        public int QtdFilhos { get; set; }
        
        [Display(Name = "Sálario")]
        public decimal Salario { get; set; }

        [Display(Name = "Situação")]
        public bool Situacao
        {
            get; 
            set; 
                    
        }
        public string Ativo
        {
            get
            {
                return (bool)this.Situacao ? "Ativo" : "Inativo";
            }
        }

    }

}
