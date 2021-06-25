using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Api.Domain.Models.Request
{
    public class CafeRequest
    {
        public int IdCafe { get; set; }         //Identificador Serial do café
        public string Nome { get; set; }        // Nome do café nerd
        public string Tipo { get; set; }        //Tipo de café a ser inspirado
        public string Ingredientes { get; set; }//Ingredientes de acordo com o Tipo
        public char Tamanho { get; set; }       //P, M e G
        public double Preco { get; set; }       //Valor em R$
    }
}
