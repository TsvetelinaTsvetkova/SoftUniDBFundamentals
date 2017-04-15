using SoftUniADOLive.SystemModules.ProjectModule.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive.SystemModules.ProjectModule
{
    public class ProjectMenuLogicHandler
    {
        private SoftUniEntities context;

        private int listAllProjectsInProjectMenu = 1;

        private int back = 8;

        private int searchByProjectName = 3;

        public ProjectMenuLogicHandler(SoftUniEntities context)
        {
            this.context = context;
        }

        public void HandlerProjectMenuCommand(int command)
        {

            if (command == this.listAllProjectsInProjectMenu)
            {
                var listAllProject = new ListAllProjects();
                listAllProject.ListAll(context);
            }
            else if (command == back)
            {
                var back = new BackToBaseMenu(context);
                back.HandleBaseMenu();
            }
            else if (command == searchByProjectName)
            {
                var showProjectByName = new SearchProjectByName(context);
                showProjectByName.Search();
            }

        }
    }
}
