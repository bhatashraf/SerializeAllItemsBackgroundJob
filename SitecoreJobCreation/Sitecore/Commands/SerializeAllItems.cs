using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using SitecoreJobCreation.Sitecore.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;

namespace SitecoreJobCreation.Sitecore.Commands
{
    public class SerializeAllItems : Command
    {
        public override void Execute(CommandContext context)
        {
            Item contextItem = context.Items[0]; 
            if(contextItem!=null)
            {
                Log.Audit(this, "Check in {0}", new[] { AuditFormatter.FormatItem(contextItem) });
                JobService service = new JobService();
                service.StartJob(contextItem);
            }
        }

        public override CommandState QueryState(CommandContext context)
        {
            Item contextItem = context.Items[0];
            return (contextItem.Children.Count > 0) ? CommandState.Enabled : CommandState.Disabled;           
        }
    }
}