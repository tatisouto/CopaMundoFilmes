using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projeto.CopaMundo.Filmes.Domain;

namespace Projeto.CopaMundo.Filmes.Infra.Api
{
    public class FilmeAPi
    {
        public  IEnumerable<Filme> GetAll(Uri uri)
        {
            var syncClient = new WebClient();

            var content = syncClient.DownloadString(uri);
           
            return JsonConvert.DeserializeObject<List<Filme>>(content);

             

        }

    }
}
