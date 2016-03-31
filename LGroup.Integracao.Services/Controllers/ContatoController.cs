using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//SUBIMOS PARA MEMORIA AS PROPRIEDADES E O BANCO DE DADOS
using LGroup.Integracao.Services.DataAccess;
using LGroup.Integracao.Services.Models;

//LIBERAMOS O ACESSO EXTERNO
using System.Web.Http.Cors;

//GET - LEITURA
//POST - GRAVAÇÃO 
//PUT - ATUALIZAÇÃO
//DELETE - DELETAR

namespace LGroup.Integracao.Services.Controllers
{
    [EnableCors("*", "*", "*", "*")]
    public class ContatoController : ApiController
    {

        [HttpGet]
        public List<ContatoMOD> Listar()
        {
            //ABRIAMOS A CONEXAO COM O BANCO DE DADOS
            using (var conexao = new INCUBADORA4Entities())
            {
                //LINQ
                var retorno = (from C in conexao.TB_CONTATO
                               select new ContatoMOD
                               {
                                 Codigo = C.ID_CONTATO,
                                 Nome = C.NM_CONTATO,
                                 Email = C.DS_EMAIL,
                                 Telefone = C.NR_TELEFONE,
                                 DataNascimento = C.DT_NASCIMENTO,
                                 Sexo = new SexoMOD
                                 {
                                     Codigo = C.ID_SEXO,
                                     Descricao = C.TB_SEXO.DS_SEXO
                                 }
                               }).ToList();

                return retorno;
            }
        }

        //VERIFICAMOS SE O EMAIL EXISTE
        [HttpGet]
        public Boolean EmailJaExiste(string texto_)
        {
            //ABRIMOS A CONEXAO COM O BANCO DE DADOS
            using (var conexao = new INCUBADORA4Entities())
            {
                return conexao.TB_CONTATO.Any(x=>x.DS_EMAIL == texto_);
            }
        }


        //VERIFICAMOS SE O TELEFONE EXISTE
        [HttpGet]
        public Boolean TelefoneJaExiste(string numero_)
        {
            using (var conexao = new INCUBADORA4Entities())
            {
                return conexao.TB_CONTATO.Any(x => x.NR_TELEFONE == numero_);
            }
        }

    }
}
