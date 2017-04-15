using SoftUniADOLive.SystemModules.ProjectModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive.SystemModules.BaseSystemModule
{
   public class BaseMenuLogicHandler
    {
        private BaseMenu baseMenu;

        private ProjectMenu projectMenu;

        public BaseMenuLogicHandler()
        {
            this.baseMenu = new BaseMenu();
            this.projectMenu = new ProjectMenu();
        }

        public void InvokeActionBaseOnUserSelection(int option)
        {
            if (option == 2)
            {
              
                var selectedOptionFromProjectMenu = projectMenu.DisplayProjectMenu();

                if (selectedOptionFromProjectMenu == 8)
                {
                    
                    this.InvokeActionBaseOnUserSelection(baseMenu.PrintAllMainModulesOptions());
                }
            }

        }
    }
}
