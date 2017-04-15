namespace SoftUniADOLive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SystemModules.BaseSystemModule;
    using SystemModules.ProjectModule;
    using SystemModules.ProjectModule.Commands;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();

            BackToBaseMenu baseMenu = new BackToBaseMenu(context);
            baseMenu.HandleBaseMenu();                      
        }
    }
}
