using AutoMapper;
using Projeto.CopaMundo.Filmes.Domain;
using Projeto.CopaMundo.Filmes.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.CopaMundo.Filmes.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile :  Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            ConfigureMappings();
        }


        private void ConfigureMappings()
        {
            CreateMap<Filme, FilmeViewModels>().ReverseMap();
          

        }
    }
}
