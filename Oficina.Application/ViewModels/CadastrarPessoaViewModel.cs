using OficinaOS.Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaOS.Application.ViewModels
{
    public class CadastrarPessoaViewModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }


        public CadastrarPessoaDTO ConverterDTO()
        {
            return new CadastrarPessoaDTO
            {
                Cpf = Cpf,
                Nome = Nome,
                Email = Email,
                Senha = Senha,
                Telefone = Telefone
            };
        }
    }
}
