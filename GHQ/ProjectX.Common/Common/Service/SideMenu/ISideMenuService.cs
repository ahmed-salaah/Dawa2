using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.SideMenu
{
    public interface ISideMenuService
    {
        List<SideMenuItem> GetLogginSideMenuItems();
        List<SideMenuItem> GetNotLogginSideMenuItems();
    }
}
