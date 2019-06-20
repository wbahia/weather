using System;
using System.Collections.Generic;
using System.Linq;
using Weather.BLL.Base;
using Weather.Domain.Model;

namespace Weather.BLL.Manager
{
    public class CidadeManager
    {
        public List<Cidade> ObterCidades()
        {
            List<Cidade> listaCidades = new List<Cidade>();
            using(var unitOfWork = new UnitOfWorkManager())
            {
                listaCidades = unitOfWork.GetManager<Cidade>().GetBy().ToList();
            }

            return listaCidades;

        }

        public object CadastrarCidade(string nomeCidade)
        {
            var cidade = new Cidade(nomeCidade, 10);
            
            using (var unitOfWork = new UnitOfWorkManager())
            {
                unitOfWork.GetManager<Cidade>().Add(cidade);
                unitOfWork.Commit();
            }
            return cidade;
        }
    }
}
