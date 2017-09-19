using System;
using System.Security.Cryptography.X509Certificates;
using Lynn.Article.Model;

namespace Lynn.Article.Core
{
    public interface IAnalysis
    {
        ArticleModel Analysis(string articleHtml);

        SimpleArticleModel SimpleAnalysis(String articleHtml);
    }
}