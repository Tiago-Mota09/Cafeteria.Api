using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Api.Data.Entities
{
    public class DocesEntity
    {
        public int IdDoces { get; set; }
        public string Tipo { get; set; }
        public string Sabor { get; set; }
        public double Peso { get; set; }
        public double Preco { get; set; }        
    }
}
