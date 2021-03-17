using SmartStore.Collections;
using SmartStore.Web.Framework.UI;
using SmartStore.AndMore.Security;

namespace SmartStore.SmartStoreAndMore
{
    public class AdminMenu : AdminMenuProvider
    {
        protected override void BuildMenuCore(TreeNode<MenuItem> pluginsNode)
        {
            var menuItem = new MenuItem().ToBuilder()
                .Text("My Plugin")
                .ResKey("Plugins.FriendlyName.SmartStore.SmartStoreAndMore")
                .Icon("far fa-images")
                .PermissionNames(SmartStoreAndMorePermissions.Read)
                .Action("ConfigurePlugin", "Plugin", new { systemName = "SmartStore.AndMore", area = "Admin" })
                .ToItem();

            pluginsNode.Prepend(menuItem);
        }

        public override int Ordinal
        {
            get
            {
                return -200;
            }
        }
    }
}
