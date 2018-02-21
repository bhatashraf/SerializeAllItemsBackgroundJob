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
    public class SerializeAllItems : Command
    {
        private string _JobName = "SerialiazeAllItemsInBackground";
        private bool JobIsRunningOrQueued = false;
        public override void Execute(CommandContext context)
        {
            if(JobIsRunningOrQueued==false)
            {
                Item contextItem = context.Items[0];
                if (contextItem != null)
                {
                    Log.Audit(this, "Check in {0}", new[] { AuditFormatter.FormatItem(contextItem) });
                    JobService service = new JobService();
                    service.StartJob(contextItem);
                }
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

        private void JobNotRunning()
        {
            Job job = JobManager.GetJob(_JobName);
            if (job != null)
            {
                Item item = job.Options.Item;
                JobIsRunningOrQueued =  job.Status.State == JobState.Running || job.Status.State == JobState.Queued ? true : false;
            }            
        }
    }
}