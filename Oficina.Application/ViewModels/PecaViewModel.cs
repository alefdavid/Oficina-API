using OficinaOS.Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaOS.Application.ViewModels
{
    public class PecaModel
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public decimal Valor_unit { get; set; }

        public PecaDTO ConverterDTO()
        {
            return new PecaDTO
            {
                Descricao = Descricao,
                Quantidade = Quantidade,
                Marca = Marca,
                Valor_unit = Valor_unit
            };
        }

    }
}
