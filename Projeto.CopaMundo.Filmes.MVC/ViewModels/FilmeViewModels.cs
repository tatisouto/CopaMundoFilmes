using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.CopaMundo.Filmes.MVC.ViewModels
{
    public class FilmeViewModels
    {        
        public string Id { get; set; }       
        public string PrimaryTitle { get; set; }        
        public string Year { get; set; }       
        public double AverageRating { get; set; }

        public List<FilmeViewModels> lstOitavaFinais { get; set; }
        public List<FilmeViewModels> lstQuartaFinais { get; set; }
        public List<FilmeViewModels> lstSemiFinais { get; set; }
        public List<FilmeViewModels> lstFinais { get; set; }
    }
}