using System;
using System.Collections.Generic;

namespace IISMonitorDX.Model
{
    public class IISModel
    {
        #region
        public string ServerIP { get; set; }
        public DateTime SyncTime { get; set; }

        public string State { get; set; }
        public IList<SiteModel> SiteList { get; set; }

        public IList<ApplicationPoolsModel> ApplicationPoolsList { get; set; } 
        #endregion
    }
}