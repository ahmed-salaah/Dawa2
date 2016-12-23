using GHQ.Logic.Models.Data.News;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.News
{
    public interface INewsService
    {
        NewsData SelectedNew { get; set; }
        Task<List<NewsData>> GetNewsAsync();
    }
}
