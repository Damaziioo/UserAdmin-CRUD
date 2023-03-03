using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdmin.UserAdmin.BLL.DTO
{
    public class UserDTO
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string telefone { get; set; }
        [Required(ErrorMessage = "Email é obrigatório!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formatação de Email inválida!")]
        public string Email { get; set; }

    }
}
