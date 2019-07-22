using System;

namespace Restaurante.Domain
{
    public class Pratos
    {
        public int Id {get;set;}
        public string PratoNome {get;set;}
        public decimal PratoPreco {get;set;}
        public DateTime? DataCadastro {get;set;}
        public DateTime? DataUltimaAtualizacao {get;set;}
        public int RestauranteId {get;set;}
        public Restaurantes Restaurante {get;}
    }
}