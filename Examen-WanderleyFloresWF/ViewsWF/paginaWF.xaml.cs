using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
using static System.Net.WebRequestMethods;

namespace Examen_WanderleyFloresWF.ViewsWF;

public partial class paginaWF : ContentPage
{
    public paginaWF()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //var newsApiClient = new NewsApiClient("14336ebdd12b49a0b8cad0120f273c44");
        //var articlesResponse = newsApiClient.GetEverything(new EverythingRequest

        string baseUrl = "https://newsapi.org/v2/everything";

        string apiKey = "14336ebdd12b49a0b8cad0120f273c44";
        string query = "tesla";
        string sortBy = "" + SortBys.PublishedAt;
        string language = "" + Languages.EN;
        DateTime fromDate = new DateTime(2023, 12, 24);

        string apiUrl = $"https://newsapi.org/v2/everything?apiKey=14336ebdd12b49a0b8cad0120f273c44&q=tesla&sortBy=PublishedAt&language=EN&from=2023-12-24";

        var newsApiClient = new NewsApiClient(apiKey);

        var articlesResponse = newsApiClient.GetEverything(new EverythingRequest

        {

            Q = "tesla",
            SortBy = SortBys.PublishedAt,
            Language = Languages.EN,
            From = new DateTime(2023, 12, 24)


        });
        if (articlesResponse.Status == Statuses.Ok)
        {
            NoticiasListView.ItemsSource = null;

            var listaDeArticulos = new List<Article>();

            Console.WriteLine(articlesResponse.TotalResults);

            foreach (var article in articlesResponse.Articles)
            {
                var articulo = new Article
                {
                    Title = article.Title,
                    Author = article.Author,
                    Description = article.Description,
                    Url = article.Url,
                    PublishedAt = article.PublishedAt
                };
                listaDeArticulos.Add(articulo);

                Console.WriteLine(articulo.Title);
                Console.WriteLine(articulo.Author);
                Console.WriteLine(articulo.Description);
                Console.WriteLine(articulo.Url);
                Console.WriteLine(articulo.PublishedAt);
            }

            NoticiasListView.ItemsSource = listaDeArticulos;
        }
    }

}