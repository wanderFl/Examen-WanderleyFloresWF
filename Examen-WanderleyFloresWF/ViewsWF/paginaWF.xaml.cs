using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
namespace Examen_WanderleyFloresWF.ViewsWF;

public partial class paginaWF : ContentPage
{
	public paginaWF()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        var newsApiClient = new NewsApiClient("14336ebdd12b49a0b8cad0120f273c44");
        var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
        {
            Q = "tesla",
            SortBy = SortBys.PublishedAt,
            Language = Languages.EN,
            From = new DateTime(2023, 12, 24)
        });
        if (articlesResponse.Status == Statuses.Ok)
        {
            // total results found
            Console.WriteLine(articlesResponse.TotalResults);
            // here's the first 20
            foreach (var article in articlesResponse.Articles)
            {
                Titulo.Text = article.Title;
                Author.Text= article.Author;
                Description.Text= article.Description;
                Url.Text= article.Url;
                PublishedAt.Text = ""+ article.PublishedAt;
                // title
                Console.WriteLine(article.Title);
                // author
                Console.WriteLine(article.Author);
                // description
                Console.WriteLine(article.Description);
                // url
                Console.WriteLine(article.Url);
                // published at
                Console.WriteLine(article.PublishedAt);
            }
        }
        Console.ReadLine();
    }
}