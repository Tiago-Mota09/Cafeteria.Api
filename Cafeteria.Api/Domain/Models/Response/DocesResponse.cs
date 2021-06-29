using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Api.Domain.Models.Response
{
    public class DocesResponse
    {
        public int IdDoces { get; set; }
        public string Tipo { get; set; }
        public string Sabor { get; set; }
        public double Peso { get; set; }
        public double Preco { get; set; }
    }
}
