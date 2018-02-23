using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using SitecoreJobCreation.Sitecore.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;
//using Sitecore;
using sc = Sitecore;
using Sitecore.Jobs;

namespace SitecoreJobCreation.Sitecore.Commands
{
    public class SerializationJob : Command
    {

        string _JobName = Constants._JobName;
        public override void Execute(CommandContext context)
        {
            

            if (JobNotRunningOrQueued(_JobName))
            {
                Item contextItem = context.Items[0];
                if (contextItem != null)
                {
                    Log.Audit(this, "Check in {0}", new[] { AuditFormatter.FormatItem(contextItem) });
                    JobService service = new JobService();
                    service.StartJob(contextItem);
                }
                if (IsJobFinished(_JobName))
                    sc.Context.ClientPage.ClientResponse.Alert("Job completed!...");
            }
            else
            {
                sc.Context.ClientPage.ClientResponse.Confirm("Job with this name is already running or queued!..");
            }

        }

        public override CommandState QueryState(CommandContext context)
        {
            Item contextItem = context.Items[0];
            return (contextItem.Children.Count > 0) ? CommandState.Enabled : CommandState.Disabled;
        }

        private bool JobNotRunningOrQueued(string JobName)
        {
            Job job = JobManager.GetJob(JobName);
            if (job != null)
            {
                // Item item = job.Options.Item;
                return (job.Status.State == JobState.Finished) ? true : false;
                
            }
            return true;
        }
        private bool IsJobFinished(string JobName)
        {
            Job job = JobManager.GetJob(JobName);
            if(job!=null)
            {
                return job.Status.State == JobState.Finished;
            }
            return false;
        }
    }
}