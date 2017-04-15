using SoftUniADOLive.SystemModules.BaseSystemModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive.SystemModules.ProjectModule.Commands
{
  public class Back
    {

        public void ReturnToBaseMenu()
        {
            var baseMenu = new BaseMenu();
            baseMenu.PrintAllMainModulesOptions();
        }
    }
}
