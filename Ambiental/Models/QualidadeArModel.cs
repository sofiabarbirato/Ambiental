using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Ambiental.Models
{
        public class QualidadeArModel
        {
            public virtual int Id { get; set; }
            public virtual string Localizacao { get; set; }
            public virtual string IndiceQualidade { get; set; }
            public virtual int DataLeitura { get; set; }


        public QualidadeArModel()
            {

            }

        public QualidadeArModel(int id, string localizacao, string indiceQualidade, int dataLeitura)
        {
            Id = id;
            Localizacao = localizacao;
            IndiceQualidade = indiceQualidade;
            DataLeitura = dataLeitura;
        }
    }
}