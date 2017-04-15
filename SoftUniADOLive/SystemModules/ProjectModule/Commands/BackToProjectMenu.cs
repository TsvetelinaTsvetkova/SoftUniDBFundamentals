using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive.SystemModules.ProjectModule.Commands
{
    public class BackToProjectMenu
    {
        public void ReturnToBaseMenu()
        {
            var projectMenu = new ProjectMenu();
            projectMenu.DisplayProjectMenu();
        }
    }
}
