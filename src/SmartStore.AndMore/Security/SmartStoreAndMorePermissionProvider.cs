using System.Collections.Generic;
using System.Linq;
using SmartStore.Core.Domain.Customers;
using SmartStore.Core.Domain.Security;
using SmartStore.Core.Security;

namespace SmartStore.AndMore.Security
{
    public static class SmartStoreAndMorePermissions
    {
        public const string Self = "SmartStoreAndMore";
        public const string Read = "SmartStoreAndMore.read";
        public const string Update = "SmartStoreAndMore.update";
        public const string Display = "SmartStoreAndMore.display";
        public const string Edit = "SmartStoreAndMore.edit";
    }


    public class SmartStoreAndMorePermissionProvider : IPermissionProvider
    {
        public IEnumerable<PermissionRecord> GetPermissions()
        {
            var permissionSystemNames = PermissionHelper.GetPermissions(typeof(SmartStoreAndMorePermissions));
            var permissions = permissionSystemNames.Select(x => new PermissionRecord { SystemName = x });

            return permissions;
        }

        public IEnumerable<DefaultPermissionRecord> GetDefaultPermissions()
        {
            return new[]
            {
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Administrators,
                    PermissionRecords = new[]
                    {
                        new PermissionRecord { SystemName = SmartStoreAndMorePermissions.Self }
                    }
                },
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.ForumModerators,
                    PermissionRecords = new[]
                    {
                        new PermissionRecord { SystemName = SmartStoreAndMorePermissions.Display }
                    }
                },
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Guests,
                    PermissionRecords = new[]
                    {
                        new PermissionRecord { SystemName = SmartStoreAndMorePermissions.Display }
                    }
                },
                new DefaultPermissionRecord
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Registered,
                    PermissionRecords = new[]
                    {
                        new PermissionRecord { SystemName = SmartStoreAndMorePermissions.Display }
                    }
                }
            };
        }
    }
}