using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Weather.Domain.NotMapped
{
    [NotMapped]
    public class DomainResult<T> where T : class
    {
        #region Construtor
        public DomainResult()
        {
            Erros = new List<string>();
        }
        #endregion

        #region Propriedades
        public int? Id { get; set; }
        private bool _sucesso = true;

        public bool Sucesso
        {
            get
            {
                if (Erros.Any() || ExceptionGerada != null)
                    return false;

                return _sucesso;
            }
            set { _sucesso = value; }
        }


        /// <summary>
        /// Mensagem de sucesso
        /// </summary>
        public string Mensagem { get; set; }

        public List<string> Erros { get; set; }

        
        /// <summary>
        /// Get todas mensagens de erros e consolida em uma string com Environment.NewLine
        /// </summary>
        public string ErroMensagem
        {
            get
            {
                var erroMsg = "";
                if (Erros.Any())
                {
                    erroMsg = string.Join("" + Environment.NewLine, Erros.ToArray());
                }
                return erroMsg;
            }
        }

        public Exception ExceptionGerada
        {
            get; set;
        }

        public T Entidade { get; set; }

        #endregion

        
    }
}
