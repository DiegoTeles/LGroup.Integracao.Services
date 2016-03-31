using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LGroup.Integracao.Services.Models
{
    public class ContatoMOD
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }

        //COMPOSIÇÃO
        //NOME BUNITÃO POO
        //PROGRAMAÇÃO ORIENTADA A OBJETOS
        public SexoMOD Sexo { get; set; }
    }
}