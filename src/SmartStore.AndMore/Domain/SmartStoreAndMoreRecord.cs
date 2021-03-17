using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartStore.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartStore.AndMore.Domain
{
    // After you've created your domain record:
    // switch the project map configuration from Debug to EFMigrations
    // open the nuget package manager console
    // Choose your project as the default project
    // add your initial migration by typing: add-migration Initial
    public class SmartStoreAndMoreRecord : BaseEntity
    {
        public bool IsActive { get; set; }

        [UIHint("Media"), AdditionalMetadata("album", "SmartStoreAndMore")]
        public int PictureId { get; set; }

        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
    }
}