using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreJobCreation.Sitecore.Jobs;
using Sitecore.Jobs;

namespace SitecoreJobCreation.Sitecore.Commands
{
    public class TerminateSerializationJob : Command
    {
        public override void Execute(CommandContext context)
        {
            TerminateJobService terminateJobService = new TerminateJobService();
            terminateJobService.TerminateRunningJob();
        }
        public override CommandState QueryState(CommandContext context)
        {
            Job job = JobManager.GetJob(Constants._JobName);
            if(job != null)
            {
                if (job.Status.State != JobState.Finished)
                    return CommandState.Enabled;
            }
            return CommandState.Disabled;
        }
    }
}