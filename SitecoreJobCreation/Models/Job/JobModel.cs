using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreJobCreation.Models.Job
{
    public class JobModel
    {
        public string Title { get; set; }
        public string Progress { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string QueueTime { get; set; }
        public string Category { get; set; }

    }
}