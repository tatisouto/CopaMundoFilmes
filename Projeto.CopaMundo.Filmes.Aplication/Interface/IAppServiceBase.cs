using Projeto.CopaMundo.Filmes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.CopaMundo.Filmes.Aplication.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> GetAll();
        //public static List<Filme> GetAll(Uri uri);
    }
}
