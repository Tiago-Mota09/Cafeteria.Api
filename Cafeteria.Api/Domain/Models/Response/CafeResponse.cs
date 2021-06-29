using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Api.Domain.Models
{
    public class CafeResponse
    {
        public int IdCafe { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Ingredientes { get; set; }
        public char Tamanho { get; set; }
        public double Preco { get; set; } 
    }
}
