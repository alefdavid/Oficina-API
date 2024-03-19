using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Domain.Entities
{
    public class Peca : BaseEntity
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public decimal Valor_unit { get; set; }
    }
}
