﻿using SmartStore.Core.Configuration;

namespace SmartStore.AndMore.Settings
{
    public class SmartStoreAndMoreSettings : ISettings
    {
        public string MyFirstSetting { get; set; }


        public int PictureId { get; set; }
        public string Color { get; set; }
        public string Text { get; set; }




    }
}