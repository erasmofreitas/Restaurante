using System;

namespace Restaurante.Domain
{
    public class Restaurantes
    {
        public int Id {get;set;}
        public string RestauranteNome {get;set;}
        public DateTime? DataCadastro {get;set;}
        public DateTime? DataUltimaAtualizacao {get;set;}
    }
}