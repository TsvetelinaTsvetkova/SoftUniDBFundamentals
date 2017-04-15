using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive.SystemModules.ProjectModule
{
    public class ProjectMenu
    {
        private List<string> menuOptions;

        public ProjectMenu()
        {
            this.menuOptions = new List<string>();
            menuOptions.Add("1. List all project");
            menuOptions.Add("2. View details for specific project");
            menuOptions.Add("3. Search for project by name");
            menuOptions.Add("4. Assign employees");
            menuOptions.Add("5. Release employees");
            menuOptions.Add("6. Create new project");
            menuOptions.Add("7. Edit project");
            menuOptions.Add("8. Back");
        }

        public int DisplayProjectMenu()
        {
           return Utility.MenuNavigationLogic(menuOptions);
        }
    }
}
