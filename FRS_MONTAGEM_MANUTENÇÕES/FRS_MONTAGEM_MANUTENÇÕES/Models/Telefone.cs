﻿namespace FRS_Montagens_e_Manutenção.Models
{
    public class Telefone
    {
        public int id_pessoas {  get; set; }
        public string Numero { get; set; }
        public Pessoa Pessoas { get; set; }
    }
}
