using SoftUniADOLive.SystemModules.BaseSystemModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive.SystemModules.ProjectModule.Commands
{
  public class BackToBaseMenu
    {
        private SoftUniEntities context;

        public BackToBaseMenu(SoftUniEntities context)
        {
            this.context = context;
        }
        public void HandleBaseMenu()
        {
            var baseMenu = new BaseMenu();
            int userSelection = baseMenu.PrintAllMainModulesOptions();

            var baseMenuLogicHandler = new BaseMenuLogicHandler(context);

            baseMenuLogicHandler.InvokeActionBaseOnUserSelection(userSelection);
        }
    }
}
