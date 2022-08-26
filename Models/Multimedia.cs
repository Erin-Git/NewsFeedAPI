using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeedAPI.Models
{
    public class Multimedia
    {
        public int MultimediaId { get; set; }
        public string Url { get; set; }
        public string Format { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Caption { get; set; }
        public string Copyright { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
