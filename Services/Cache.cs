using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using aliengallery.Models;

namespace aliengallery.Services
{
    public class Cache
    {
        private static Dictionary<Gallery,List<Post>> _data = new Dictionary<Gallery,List<Post>>();

        public static List<Post> Get(Gallery gallery) 
        {
            return _data.ContainsKey(gallery) ? _data[gallery] : null;
        }

        public static void Set(Gallery gallery,List<Post> posts) 
        {
            _data.Add(gallery,posts);
        }
    }  
}