using Sitecore.Jobs;
using SitecoreJobCreation.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitecoreJobCreation.Sitecore.admin
{
    public partial class JobPage : System.Web.UI.Page
    {
        List<Job> Jobs = JobManager.GetJobs().ToList();
        //public Job job
        //{
        //    get { return Jobs.Where(j => j.Name == _JobName).FirstOrDefault(); }
        //}
        public IEnumerable<Job> totalQueuedJobs
        {
            get { return Jobs.Where(j => j.Status.State == JobState.Queued); }
        }
        public IEnumerable<Job> totalFinishedJobs
        {
            get { return Jobs.Where(j => j.Status.State == JobState.Finished); }
        }
        public IEnumerable<Job> totalRunningJobs
        {
            get { return Jobs.Where(j => j.Status.State == JobState.Running); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                TotalNumberOfJobs.Text = Jobs.Count.ToString();
                TotalNumberOfRunningJobs.Text = totalRunningJobs.Count().ToString();
                TotalNumberOfQueuedJobs.Text = totalQueuedJobs.Count().ToString();
                TotalNumberOfFinishedJobs.Text = totalFinishedJobs.Count().ToString();

                rptRunningJobs.DataSource = FinishedJobs(totalFinishedJobs);
                rptRunningJobs.DataBind();

                rptQueuedJobs.DataSource = QueuedJobs(totalQueuedJobs);
                rptQueuedJobs.DataBind();

                rptRunningJobs.DataSource = RunningJobs(totalRunningJobs);
                rptRunningJobs.DataBind();

            }


        }
        private IEnumerable<JobModel> FinishedJobs(IEnumerable<Job> finishedJobs)
        {
            List<JobModel> jobs = new List<JobModel>();
            if (totalFinishedJobs != null)
            {
                JobModel jobModel = new JobModel();
                foreach (Job job in finishedJobs)
                {
                    jobModel.Title = job.Name;
                    jobModel.Priority = job.Options.Priority.ToString();
                    jobModel.Status = job.Status.ToString();
                    jobModel.Progress = job.Status.Processed.ToString();
                    jobModel.QueueTime = job.QueueTime.ToString();
                    jobs.Add(jobModel);
                }
                return jobs;
            }
            return null;
        }
        private IEnumerable<JobModel> QueuedJobs(IEnumerable<Job> queuedJobs)
        {
            List<JobModel> jobs = new List<JobModel>();
            if (queuedJobs != null)
            {
                JobModel jobModel = new JobModel();
                foreach (Job job in queuedJobs)
                {
                    jobModel.Title = job.Name;
                    jobModel.Priority = job.Options.Priority.ToString();
                    jobModel.Status = job.Status.ToString();
                    jobModel.Progress = job.Status.Processed.ToString();
                    jobModel.QueueTime = job.QueueTime.ToString();
                    jobs.Add(jobModel);
                }
                return jobs;
            }
            return null;
        }
        private IEnumerable<JobModel> RunningJobs(IEnumerable<Job> runningJobs)
        {
            List<JobModel> jobs = new List<JobModel>();
            if (runningJobs != null)
            {
                JobModel jobModel = new JobModel();
                foreach (Job job in runningJobs)
                {
                    jobModel.Title = job.Name;
                    jobModel.Priority = job.Options.Priority.ToString();
                    jobModel.Status = job.Status.ToString();
                    jobModel.Progress = job.Status.Processed.ToString();
                    jobModel.QueueTime = job.QueueTime.ToString();
                    jobs.Add(jobModel);
                }
                return jobs;
            }
            return null;
        }
    }
}