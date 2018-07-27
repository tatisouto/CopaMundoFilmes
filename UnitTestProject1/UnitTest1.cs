using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto.CopaMundo.Filmes.Domain;
using Projeto.CopaMundo.Filmes.Infra.Api;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var webapiAddress = @"https://copa-filmes.azurewebsites.net/api/filmes";
            var uri = new Uri(webapiAddress);

            var filme = new List<Filme>();

            filme = new FilmeAPi().GetAll(uri);
        }



    }
}
