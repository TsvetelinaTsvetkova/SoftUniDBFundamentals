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

        private int projectSubMenuSelection = 2;

        private SoftUniEntities context;

        public BaseMenuLogicHandler(SoftUniEntities context)
        {
            this.context = context;
            this.baseMenu = new BaseMenu();
            this.projectMenu = new ProjectMenu();
        }

        public void InvokeActionBaseOnUserSelection(int option)
        {
            if (option == this.projectSubMenuSelection)
            {
                var selectedOptionFromProjectMenu = projectMenu.DisplayProjectMenu();

                var projectHandler = new ProjectMenuLogicHandler(context);

                projectHandler.HandlerProjectMenuCommand(selectedOptionFromProjectMenu);
            }
        }
    }
}
