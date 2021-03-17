using System;
using SmartStore.Core.Data;
using SmartStore.Core.Infrastructure;
using SmartStore.Services.Configuration;
using SmartStore.Web.Framework;

namespace SmartStore.AndMore
{

    public class Starter : IApplicationStart
    {

        public void Start()
        {
            if (!DataSettings.DatabaseIsInstalled())
                return;

            try
            {
                var settings = EngineContext.Current.Resolve<ISettingService>();

                // Do something on application start.

            }
            catch { }
        }

        public int Order
        {
            get { return 10000; }
        }
    }


    public class PreStarter : IPreApplicationStart
    {

        public void Start()
        {
            if (!DataSettings.DatabaseIsInstalled())
                return;

            try
            {
                var settings = EngineContext.Current.Resolve<ISettingService>();

                // Do something before application start.

            }
            catch { }
        }

        public int Order
        {
            get { return 10000; }
        }
    }


    public class PostStarter : IPostApplicationStart
    {

        public void Start()
        {
            if (!DataSettings.DatabaseIsInstalled())
                return;

            try
            {
                var settings = EngineContext.Current.Resolve<ISettingService>();

                // Do something after application start.

            }
            catch { }
        }

        public int Order
        {
            get { return 10000; }
        }
    }

}
