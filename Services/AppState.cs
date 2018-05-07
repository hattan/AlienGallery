using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using aliengallery.Models;

namespace aliengallery.Services
{
    public class AppState
    {
        public List<Post> Posts{get;set;}
        public event Action OnChange;
        private readonly HttpClient http;

        public AppState(HttpClient httpInstance)
        {
            http = httpInstance;
        }

        public async Task FetchPosts(Gallery gallery)
        {
            Posts = Cache.Get(gallery);
            
            if(Posts==null)
            {
                var url = GetUrl(gallery);
                var response = await http.GetJsonAsync<RedditResponse>(url);
                Posts = response.Posts;         
                Cache.Set(gallery,Posts);
            }         
            NotifyStateChanged();
        }

        private string GetUrl(Gallery gallery)
        {
            switch(gallery)
            {
                case Gallery.Art:
                return "https://www.reddit.com/r/art.json";
                case Gallery.Landscape:
                return "https://www.reddit.com/r/imaginarylandscapes.json";
            }
            return null;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

  
}