using System;
using System.Collections.Generic;
using System.Web.Routing;
using SmartStore.Core.Plugins;
using SmartStore.Services;
using SmartStore.Services.Configuration;
using SmartStore.AndMore;
using SmartStore.AndMore.Settings;

using SmartStore.Licensing;
using SmartStore.Services.Tasks;

namespace SmartStore.AndMore
{
    [LicensableModule]
    public class Plugin : BasePlugin, IConfigurable
    {
        private readonly ISettingService _settingService;
        private readonly ICommonServices _services;
        private readonly IScheduleTaskService _scheduleTaskService;

        public Plugin(ISettingService settingService,
            ICommonServices services,
            IScheduleTaskService scheduleTaskService)
        {
            _settingService = settingService;
            _services = services;
            _scheduleTaskService = scheduleTaskService;
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "SmartStoreAndMore";
            routeValues = new RouteValueDictionary() { { "area", "SmartStore.AndMore" } };
        }





        public override void Install()
        {
            // Save settings with default values.
            _services.Settings.SaveSetting(new SmartStoreAndMoreSettings());

            // Import localized plugin resources (you can edit or add these in /Localization/resources.[Culture].xml).
            _services.Localization.ImportPluginResourcesFromXml(this.PluginDescriptor);

            _scheduleTaskService.GetOrAddTask<MyFirstTask>(x =>
            {
                x.Name = "SmartStore.AndMore.Tasks.MyFirstTask";
                x.CronExpression = "*/30 * * * *"; // every 30 min.
                x.Enabled = true;
                x.RunPerMachine = true;
            });

            base.Install();
        }

        public override void Uninstall()
        {
            _services.Settings.DeleteSetting<SmartStoreAndMoreSettings>();
            _services.Localization.DeleteLocaleStringResources(this.PluginDescriptor.ResourceRootKey);

            _scheduleTaskService.TryDeleteTask<MyFirstTask>();

            base.Uninstall();
        }
    }
}
