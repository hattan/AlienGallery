using System;
using System.Collections.Generic;

namespace aliengallery.Models
{
    public class RedditResponse
    {
        public Data data{get;set;}
        public List<Post> Posts
        {
            get
            {
                return data.children;
            }
        }
    }

    public class Data
    {
        public List<Post> children { get; set; }
    }

    public class Post
    {
        public PostDetails data { get; set; }
        public string Title
        {
            get
            {
                return data.title;
            }
        }
        public string ImageUrl 
        {
            get
            {
                return data.preview.images[0].source.url;
            }
        }
        public string Thumbnail 
        {
            get
            {
                return data.thumbnail;
            }
        }
        public bool HasThumbNail
        {
            get
            {
                return Thumbnail != null && Thumbnail!="self" && data.thumbnail_height == 140;
            }
        }
    }

    public class PostDetails
    {
        public string id{get;set;}
        public string title{get;set;}
        public string thumbnail { get; set; }
        public int? thumbnail_height { get; set; }
        public Preview preview { get; set; }
    }

    public class Preview
    {
        public List<Image> images { get; set; }
    }

    public class Image
    {
        public Source source { get; set; }
    }

    public class Source
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public enum Gallery{Art,Landscape}
}