using System.Collections.Generic;
using GHQ.Logic.Models.Data.News;
using GHQ.Logic.Models.Response;
using Exceptions;
using Newtonsoft.Json;

namespace GHQ
{
    public class NewsTranslator
    {
        static public List<NewsData> Translate(NewsResponse response)
        {
            try
            {
                var translatedNews = new List<NewsData>();

                for (int i = 0; i < response.d.results.Length; i++)
                {
                    NewsData news = new NewsData();
                    news.EventDescription = response.d.results[i].EventDescription;
                    news.ShortDescription = response.d.results[i].ShortDescription;
                    news.Title = response.d.results[i].Title;
                    news.Date = response.d.results[i].PublishedDate.Date;

                    translatedNews.Add(news);
                }
                return translatedNews;
            }
            catch (System.Exception ex)
            {
                throw new ParsingException("Error Translating News", JsonConvert.SerializeObject(response));
            }
        }
    }
}
