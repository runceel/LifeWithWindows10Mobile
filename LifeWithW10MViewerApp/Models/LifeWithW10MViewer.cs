using Prism.Mvvm;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace LifeWithW10MViewerApp.Models
{
    public class LifeWithW10MViewer : BindableBase
    {
        private Post[] posts;

        public Post[] Posts
        {
            get { return this.posts; }
            set { this.SetProperty(ref this.posts, value); }
        }

        public async Task InitializeAsync()
        {
            var client = new SyndicationClient();
            var results = await client.RetrieveFeedAsync(new Uri("http://w10m.jp/rss"));
            this.Posts = results
                .Items
                .Select(x => new Post
                {
                    Title = x.Title.Text,
                    Uri = new Uri(x.Id)
                })
                .ToArray();
        }
    }
}
