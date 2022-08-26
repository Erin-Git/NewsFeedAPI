using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeedAPI.Models
{
    public class ApiResponse
    {
        public int NumResult { get; set; }
        public dynamic Result { get; set; }
        public string Status { get; set; }
        public bool IsExecuted { get; set; }
    }
}
