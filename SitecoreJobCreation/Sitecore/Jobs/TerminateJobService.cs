using Sitecore.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreJobCreation.Sitecore.Jobs
{
    public class TerminateJobService
    {
        string _JobName = Constants._JobName;
        public Job job
        {
            get { return JobManager.GetJob(_JobName); }
        }

        public void TerminateRunningJob()
        {
            if (job != null)
            {
                if (job.Status.State != JobState.Finished)
                {
                    job.Status.Expiry = DateTime.Now.AddMinutes(-1.0);
                    job.Status.State = JobState.Finished;
                }
            }

        }
    }
}