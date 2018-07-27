using AutoMapper;
using Projeto.CopaMundo.Filmes.Domain;
using Projeto.CopaMundo.Filmes.Infra.Api;
using Projeto.CopaMundo.Filmes.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.CopaMundo.Filmes.MVC.Controllers
{
    public class HomeController : Controller
    {
        protected string _web = @"https://copa-filmes.azurewebsites.net/api/filmes";

        public ActionResult Index()
        {

            var webapiAddress = _web;
            var uri = new Uri(webapiAddress);


            var pessoaViewModel = Mapper.Map<IEnumerable<Filme>, IEnumerable<FilmeViewModels>>(new FilmeAPi().GetAll(uri).OrderBy(x => x.primaryTitle));


            return View(pessoaViewModel);
        }



        [HttpPost]
        public ActionResult GerarCampeonato(List<string> lstIdFilmes)
        {
            var webapiAddress = _web;
            var uri = new Uri(webapiAddress);
            
            var _GetFilmeAll = Mapper.Map<IEnumerable<Filme>, IEnumerable<FilmeViewModels>>(new FilmeAPi().GetAll(uri).OrderBy(x => x.primaryTitle));
            var _lstfilmes = new List<FilmeViewModels>();
            FilmeViewModels filmeViewModels = new FilmeViewModels();

            foreach (var item in lstIdFilmes)
            {
                var _filme = _GetFilmeAll.Where(x => x.Id == item).FirstOrDefault();
                _lstfilmes.Add(new FilmeViewModels { Id = _filme.Id, PrimaryTitle = _filme.PrimaryTitle, Year = _filme.Year, AverageRating = _filme.AverageRating });
            }
           


            #region agrupamentos
            var _grupoA = _lstfilmes.Take(4).ToList();
            var _grupoB = _lstfilmes.Skip(4).Take(4).ToList();
            var _grupoC = _lstfilmes.Skip(8).Take(4).ToList();
            var _grupoD = _lstfilmes.Skip(12).Take(4).ToList();
            var _grupoE = _lstfilmes.Skip(16).Take(4).ToList();
            var _grupoF = _lstfilmes.Skip(20).Take(4).ToList();
            var _grupoG = _lstfilmes.Skip(24).Take(4).ToList();
            var _grupoH = _lstfilmes.Skip(28).Take(4).ToList();
            #endregion

           
                        
            #region FaseGrupos
            _grupoA = FaseGrupo(_grupoA.ToList());
            _grupoB = FaseGrupo(_grupoB.ToList());
            _grupoC = FaseGrupo(_grupoC.ToList());
            _grupoD = FaseGrupo(_grupoD.ToList());
            _grupoE = FaseGrupo(_grupoE.ToList());
            _grupoF = FaseGrupo(_grupoF.ToList());
            _grupoG = FaseGrupo(_grupoG.ToList());
            _grupoH = FaseGrupo(_grupoH.ToList());
            #endregion         
            


            #region Fase de Eliminatórias
            //Os filmes disputam uma partida única contra um outro filme, não podendo haver empates.O
            //chaveamento é definido da seguinte maneira: Primeiro do Grupo A enfrenta o segundo do grupo B e o
            //primeiro do Grupo B enfrenta o segundo do grupo A. O mesmo para os grupos C - D, E - F e G – H.
            var ConfrontoAB = gerarConfrontoEliminatorias(_grupoA, _grupoB);
            var ConfrontoCD = gerarConfrontoEliminatorias(_grupoC, _grupoD);
            var ConfrontoEF = gerarConfrontoEliminatorias(_grupoE, _grupoF);
            var ConfrontGH = gerarConfrontoEliminatorias(_grupoG, _grupoH);
            #endregion

            #region Quarta de Finais
            var confrontoQuartasFinaisA = gerarConfrontos(ConfrontoAB.First(), ConfrontoAB.Last());
            var confrontoQuartasFinaisB = gerarConfrontos(ConfrontoCD.First(), ConfrontoCD.Last());
            var confrontoQuartasFinaisC = gerarConfrontos(ConfrontoEF.First(), ConfrontoEF.Last());
            var confrontoQuartasFinaisD = gerarConfrontos(ConfrontGH.First(), ConfrontGH.Last());
            #endregion

            #region SemiFinais
            var confrontoSemiFinaisA = gerarConfrontos(confrontoQuartasFinaisA, confrontoQuartasFinaisB);
            var confrontoSemiFinaisB = gerarConfrontos(confrontoQuartasFinaisC, confrontoQuartasFinaisD);
            #endregion

            #region Finais
            var Finais = gerarConfrontos(confrontoSemiFinaisA, confrontoSemiFinaisB);
            #endregion


            return Json(filmeViewModels, JsonRequestBehavior.AllowGet);
            
        }

        public List<FilmeViewModels> FaseGrupo(List<FilmeViewModels> lstGrupo)
        {
            return lstGrupo.OrderByDescending(x => x.AverageRating).Take(2).ToList();

        }

        public List<FilmeViewModels> gerarConfrontoEliminatorias(List<FilmeViewModels> ConfrontoA, List<FilmeViewModels> ConfrontoB)
        {
            var lstFaseEliminatoria = new List<FilmeViewModels>();

            for (int i = 0; i < ConfrontoA.Count(); i++)
            {
                for (int x = 1; x < ConfrontoB.Count; x--)
                {

                    if (x < 0)
                    {
                        break;
                    }

                    if (ConfrontoA[i].AverageRating > ConfrontoB[x].AverageRating)
                    {
                        lstFaseEliminatoria.Add(new FilmeViewModels { Id = ConfrontoA[i].Id, PrimaryTitle = ConfrontoA[i].PrimaryTitle, Year = ConfrontoA[i].Year, AverageRating = ConfrontoA[i].AverageRating });
                        i++;
                    }
                    else if (ConfrontoA[i].AverageRating == ConfrontoB[x].AverageRating)
                    {
                        var _lstEmpate = new List<FilmeViewModels>();

                        _lstEmpate.Add(new FilmeViewModels { Id = ConfrontoA[i].Id, PrimaryTitle = ConfrontoA[i].PrimaryTitle, Year = ConfrontoA[i].Year, AverageRating = ConfrontoA[i].AverageRating });
                        _lstEmpate.Add(new FilmeViewModels { Id = ConfrontoB[i].Id, PrimaryTitle = ConfrontoB[i].PrimaryTitle, Year = ConfrontoB[i].Year, AverageRating = ConfrontoB[i].AverageRating });

                        _lstEmpate.OrderByDescending(e => e.PrimaryTitle).FirstOrDefault();

                        lstFaseEliminatoria.Add(new FilmeViewModels { Id = _lstEmpate.FirstOrDefault().Id, PrimaryTitle = _lstEmpate.FirstOrDefault().PrimaryTitle, Year = _lstEmpate.FirstOrDefault().Year, AverageRating = _lstEmpate.FirstOrDefault().AverageRating });
                        i++;
                    }
                    else
                    {
                        lstFaseEliminatoria.Add(new FilmeViewModels { Id = ConfrontoB[x].Id, PrimaryTitle = ConfrontoB[x].PrimaryTitle, Year = ConfrontoB[x].Year, AverageRating = ConfrontoB[x].AverageRating });
                        i++;
                    }
                }
            }
            return lstFaseEliminatoria.ToList();


        }

        public FilmeViewModels gerarConfrontos(FilmeViewModels confrontoA, FilmeViewModels confrontoB)
        {
            if (confrontoA.AverageRating > confrontoB.AverageRating)
            {
                return confrontoA;
            }
            else if (confrontoA.AverageRating.Equals(confrontoB.AverageRating))
            {
                List<FilmeViewModels> lstfilmeViewModels = new List<FilmeViewModels>();

                lstfilmeViewModels.Add(confrontoA);
                lstfilmeViewModels.Add(confrontoB);

                return lstfilmeViewModels.OrderBy(e => e.PrimaryTitle).FirstOrDefault();
            }
            else
            {
                return confrontoB;
            }


        }

    }


}
