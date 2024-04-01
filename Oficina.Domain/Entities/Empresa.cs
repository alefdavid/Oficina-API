using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaOS.Domain.Entities
{
    public class Empresa : Entity
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
    }
}
