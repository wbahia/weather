using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Model
{
    [Table("Cidade")]
    public class Cidade
    {
        public Cidade(int id, string nome, int idAPI)
        {
            Id = id;
            Nome = nome;
            IdAPI = idAPI;
        }

        public Cidade()
        {

        }

        
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int  IdAPI { get; private set; }
    }
}
