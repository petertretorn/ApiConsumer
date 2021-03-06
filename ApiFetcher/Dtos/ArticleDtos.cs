﻿//partly autogenerated from Visual Studio feature: Edit -> Paste Special -> Paste JSON as Classes

using System;

using ApiFetcher.Interfaces;

namespace ApiFetcher.Dtos
{

    public class ArticlesResponseDto : IWebResponse<ArticleDto>
    {
        public string Status { get; set; }
        public ArticleDto[] Data { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class ArticleDto
    {
        public string Urn { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public bool Published { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public string Changed_date { get; set; }
        public bool Date_hidden { get; set; }
        public ImageDto[] Images { get; set; }
        public TagDto[] Tags { get; set; }
    }

    public class ImageDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Mime_type { get; set; }
        public string Url { get; set; }
        public string Alt_text { get; set; }
    }

    public class TagDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

}
