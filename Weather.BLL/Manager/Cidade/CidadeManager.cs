using System;
using System.Collections.Generic;
using System.Linq;
using Weather.BLL.Base;
using Weather.Domain.Model;
using Weather.Domain.NotMapped;
using Weather.Proxy;
using Weather.Proxy.Client;

namespace Weather.BLL.Manager
{
    public class CidadeManager
    {
        public List<Cidade> ObterCidades()
        {
            List<Cidade> listaCidades = new List<Cidade>();
            using (var unitOfWork = new UnitOfWorkManager())
            {
                listaCidades = unitOfWork.GetManager<Cidade>().GetBy().ToList();
            }

            return listaCidades;

        }

        public DomainResult<Cidade> CadastrarCidade(string nomeCidade)
        {
            var retorno = new DomainResult<Cidade>();

            try
            {
                //verifica se a cidade existe na api do openweather
                ClientConfig.ApiUrl = "http://api.openweathermap.org/data/2.5";
                ClientConfig.ApiKey = "a75f4b55aed47dd3b7b65f58a242855f";

                var result = CurrentWeather.GetByCityName(nomeCidade);

                if (!result.Success || result.Item == null)
                {
                    retorno.Sucesso = false;
                    retorno.Mensagem = "A cidade informada não foi encontrada na API do OpenWeather.";
                    return retorno;
                }

                var cidade = new Cidade(result.Item.City, result.Item.CityId);

                using (var unitOfWork = new UnitOfWorkManager())
                {
                    // não adiciona cidade caso já exista cadastrada
                    if (unitOfWork.GetManager<Cidade>().GetBy(x => x.Nome.Equals(nomeCidade)).Any())
                    {
                        retorno.Sucesso = false;
                        retorno.Mensagem = "A cidade informada já existe.";
                        return retorno;
                    }

                    unitOfWork.GetManager<Cidade>().Add(cidade);
                    unitOfWork.Commit();
                }

                retorno.Sucesso = true;
                retorno.Entidade = cidade;

            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = ex.Message;
            }

            return retorno;

        }
    }
}
