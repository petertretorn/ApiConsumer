using System;

public class SitesResponseDto
{
    public string Status { get; set; }
    public SiteDto[] Data { get; set; }
    public DateTime Timestamp { get; set; }
}

public class SiteDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public SiteInfoCollectionDto Site_info_collection { get; set; }
}

public class SiteInfoCollectionDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Body { get; set; }
}
