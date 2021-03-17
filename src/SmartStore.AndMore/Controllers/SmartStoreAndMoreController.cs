﻿using System.Web.Mvc;
using SmartStore.Services;
using SmartStore.Services.Common;
using SmartStore.Web.Framework.Controllers;
using SmartStore.Web.Framework.Settings;
using SmartStore.Web.Framework.Security;
using SmartStore.AndMore.Models;
using SmartStore.AndMore.Settings;
using SmartStore.ComponentModel;
using SmartStore.Licensing;


namespace SmartStore.Controllers
{
    public class SmartStoreAndMoreController : AdminControllerBase
    {
        private readonly ICommonServices _services;
        private readonly IGenericAttributeService _genericAttributeService;

        public SmartStoreAndMoreController(
            ICommonServices services,
            IGenericAttributeService genericAttributeService)
        {
            _services = services;
            _genericAttributeService = genericAttributeService;
        }

        [LicenseRequired]
        [AdminAuthorize]
        [ChildActionOnly]
        [LoadSetting]
        public ActionResult Configure(SmartStoreAndMoreSettings settings)
        {
            var model = new ConfigurationModel();
            MiniMapper.Map(settings, model);



            return View(model);
        }

        [LicenseRequired]
        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        [SaveSetting]
        public ActionResult Configure(SmartStoreAndMoreSettings settings, ConfigurationModel model, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                return Configure(settings);
            }


            MiniMapper.Map(model, settings);
            return RedirectToConfiguration("SmartStore.AndMore");
        }




        [AdminAuthorize]
        public ActionResult AdminEditTab(int entityId, string entityName)
        {
            var model = new AdminEditTabModel();

            // Simple values can be stored and obtained as GenericAttributes. More complex values should implement their own domain objects.
            // Get saved value from GenericAttribute. (Value persitence can be found in the ModelBoundEventConsumer.)
            model.IsActive = _genericAttributeService.GetAttribute<bool>(entityName, entityId, "SmartStoreAndMoreIsActive");
            model.EntityId = entityId;
            model.EntityName = entityName;

            var result = PartialView(model);
            result.ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CustomProperties[SmartStoreAndMore]" };
            return result;
        }

    }
}