using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MCrypt.Tools
{
    /// <summary>
    /// Use this class to provide Backgound worker progress changes between methods.
    /// </summary>
    public class BgwProgressUpdater
    {
        /// <summary>
        /// Background worker to target.
        /// </summary>
        private BackgroundWorker bgw;

        /// <summary>
        /// PRIVATE. Percentage of the progress. Must be between 0 and 100.
        /// </summary>
        private int percentage;
        /// <summary>
        /// Percentage of the progress. Must be between 0 and 100.
        /// </summary>
        public int Percentage
        {
            get
            {
                return percentage;
            }
            private set
            {
                //if (value >= 0 && value <= 100)
                //{
                //    this.percentage = value;
                //}
                //else
                //{
                //    throw new ArgumentOutOfRangeException("The provided percentage is out of range: it must be between 0 and 100.");
                //}
                this.percentage = value;
            }
        }

        /// <summary>
        /// PRIVATE. Object to pass to the report progress handler.
        /// </summary>
        private object userState;
        /// <summary>
        /// Object to pass to the report progress handler.
        /// </summary>
        public object UserState
        {
            get
            {
                return this.userState;
            }
            private set
            {
                this.userState = value;
            }
        }

        /// <summary>
        /// Background worker progress updates manager.
        /// </summary>
        /// <param name="bgw">Background worker to target.</param>
        public BgwProgressUpdater(BackgroundWorker bgw)
        {
            if (!bgw.WorkerReportsProgress)
            {
                throw new ArgumentException("The provided Background Worker does not report progress.", "bgw");
            }
            this.bgw = bgw;
            Percentage = 0;
            UserState = null;
        }

        /// <summary>
        /// Report progress. Not updated arguments are still sent back.
        /// </summary>
        /// <param name="percentage">Percentage of the progress. Must be between 0 and 100.</param>
        public void ProgressChanged(int percentage)
        {
            this.Percentage = percentage;

            bgw.ReportProgress(this.Percentage, this.UserState);
        }

        /// <summary>
        /// Report progress. Not updated arguments are still sent back.
        /// </summary>
        /// <param name="userState">Object to pass to the report progress handler.</param>
        public void ProgressChanged(object userState)
        {
            this.UserState = userState;

            bgw.ReportProgress(this.Percentage, this.UserState);
        }

        /// <summary>
        /// Report progress. Not updated arguments are still sent back.
        /// </summary>
        /// <param name="percentage">Percentage of the progress. Must be between 0 and 100.</param>
        /// <param name="userState">Object to pass to the report progress handler.</param>
        public void ProgressChanged(int percentage, object userState)
        {
            this.Percentage = percentage;
            this.UserState = userState;

            bgw.ReportProgress(this.Percentage, this.UserState);
        }
    }
}
