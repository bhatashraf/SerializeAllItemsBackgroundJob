using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Jobs;
using Sitecore.Data.Items;
using Sitecore.Pipelines;
using sc = Sitecore;
using Sitecore.Diagnostics;


namespace SitecoreJobCreation.Sitecore.Jobs
{
    public class JobService
    {              
        private string _JobName = "SerialiazeAllItemsInBackground";
        public Job Job
        {            
            get { return JobManager.GetJob(_JobName); }
        }
        public string StartJob(Item root)
        {
                        
            JobOptions options = new JobOptions(_JobName, "Serialiaze", Context.Site.Name,this,"SerilizeItems",new object[] { root });
            JobManager.Start(options);           
            return _JobName;
        }
        public void SerilizeItems(Item root)
        {
            ProcessAllItems(root);
            if(Job !=null  )
            {
                Job.Status.State = JobState.Finished;                
            }
            
        }
        private void ProcessAllItems(Item item)
        {
            ProcessItem(item);
            foreach (Item childItem in item.Children)
            {
                ProcessAllItems(childItem);
            }
        }
        private void ProcessItem(Item item)
        {
            if(Job !=null)
            {
               //Job.Status.Processed++;
               // Job.Status.State = JobState.Running;

                if (item.Locking.IsLocked())
                {
                    sc.Data.Serialization.Manager.DumpItem(item);
                }
                else
                {
                    item.Editing.BeginEdit();
                    item.Locking.Lock();
                    sc.Data.Serialization.Manager.DumpItem(item);
                    item.Locking.Unlock();
                    item.Editing.EndEdit();
                }           
            }
        }
    }
}