using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive.SystemModules.BaseSystemModule
{
    public class BaseMenu
    {
        private List<string> menuOptions;

        public BaseMenu()
        {
            this.menuOptions = new List<string>();

            menuOptions.Add("1. Exit");
            menuOptions.Add("2. Project");
            menuOptions.Add("3. Town");
            menuOptions.Add("4. Address");
            menuOptions.Add("5. Department");
            menuOptions.Add("6. Employee");
        }

        public int PrintAllMainModulesOptions()
        {
            return Utility.MenuNavigationLogic(this.menuOptions);
        }
    }
}
