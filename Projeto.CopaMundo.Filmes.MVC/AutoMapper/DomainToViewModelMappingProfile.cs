using AutoMapper;
using Projeto.CopaMundo.Filmes.Domain;
using Projeto.CopaMundo.Filmes.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.CopaMundo.Filmes.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }


        public DomainToViewModelMappingProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<FilmeViewModels, Filme>().ReverseMap();
            

        }
    }
}
