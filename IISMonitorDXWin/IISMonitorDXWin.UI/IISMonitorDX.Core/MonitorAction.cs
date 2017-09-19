using System;
using System.Collections;
using System.Collections.Generic;
using IISMonitorDX.Model;
using Microsoft.Web.Administration;

namespace IISMonitorDX.Core
{
    public class MonitorAction
    {
        #region Veriable

        private static MonitorAction _action = null;
        private static ServerManager _serverManager = null;
        private static object _lockObj=new object();
        #endregion

        #region Structure
        public MonitorAction()
        {
            _serverManager=new ServerManager();
        }

        public static MonitorAction Instance()
        {
            lock (_lockObj)
            {
                if (_action==null)
                {
                    _action=new MonitorAction();
                }
            }
            return _action;
        }

        #endregion

        #region Function

        public IList<String> GetApplications()
        {
            ServerManager manager=new ServerManager();
            IList<String> lists=new List<string>();
            foreach (var appPool in manager.ApplicationPools)
            {
                lists.Add(appPool.Name);
            }
            return lists;
        }

        public IISModel GetIISInformation()
        {
            IISModel model=new IISModel();
            model.ApplicationPoolsList = GetApplicationPools();
            model.SiteList = GetSites();
            model.SyncTime = DateTime.Now;
        }

        public IList<ApplicationPoolsModel> GetApplicationPools()
        {
            IList<ApplicationPoolsModel> lists = new List<ApplicationPoolsModel>();
            foreach (var appPool in _serverManager.ApplicationPools)
            {
                lists.Add(new ApplicationPoolsModel()
                {
                    Name = appPool.Name,
                    PipelModel = appPool.ManagedPipelineMode.ToString(),
                    State = appPool.State.ToString(),
                });
            }
            return lists;
        }

        public IList<SiteModel> GetSites()
        {
            IList<SiteModel> lists=new List<SiteModel>();
            foreach (var site in _serverManager.Sites)
            {
                lists.Add(new SiteModel()
                {
                    Name = site.Name,
                    State = site.State.ToString(),
                    //Port = site.Bindings[0]
                });
            }
            return lists;
        }

        #endregion
    }
}