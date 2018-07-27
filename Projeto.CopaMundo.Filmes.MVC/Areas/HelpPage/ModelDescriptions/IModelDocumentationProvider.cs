using System;
using System.Reflection;

namespace Projeto.CopaMundo.Filmes.MVC.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}