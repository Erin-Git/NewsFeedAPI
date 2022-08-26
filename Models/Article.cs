using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeedAPI.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Url { get; set; }
        public string Uri { get; set; }
        public string ByLine { get; set; }
        public string ItemType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public string MaterialTypeFacet { get; set; }
        public string Kicker { get; set; }
        public string DesFacet { get; set; }
        public string OrgFacet { get; set; }
        public string PerFacet { get; set; }
        public string GeoFacet { get; set; }
        public string ShortUrl { get; set; }
        public int MultimediaId { get; set; }
        public virtual ICollection<Multimedia> Multimedia { get; set; }
    }
}
