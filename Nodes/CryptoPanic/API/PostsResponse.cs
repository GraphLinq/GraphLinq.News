using System;
using System.Collections.Generic;

namespace NodeBlock.Plugin.News.Nodes.CryptoPanic.API
{

    public partial class PostsResponse
    {
        public long Count { get; set; }
        public Uri Next { get; set; }
        public object Previous { get; set; }
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        public string Kind { get; set; }
        public string Domain { get; set; }
        public Source Source { get; set; }
        public string Title { get; set; }
        public DateTimeOffset PublishedAt { get; set; }
        public string Slug { get; set; }
        public List<Currency> Currencies { get; set; }
        public long Id { get; set; }
        public Uri Url { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Votes Votes { get; set; }
    }

    public partial class Currency
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public Uri Url { get; set; }
    }

    public partial class Source
    {
        public string Title { get; set; }
        public string Region { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }
    }

    public partial class Votes
    {
        public long Negative { get; set; }
        public long Positive { get; set; }
        public long Important { get; set; }
        public long Liked { get; set; }
        public long Disliked { get; set; }
        public long Lol { get; set; }
        public long Toxic { get; set; }
        public long Saved { get; set; }
        public long Comments { get; set; }
    }

}