namespace SoftUniADOLive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SystemModules.BaseSystemModule;
    using SystemModules.ProjectModule;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();

            var baseMenu = new BaseMenu();

            var option = baseMenu.PrintAllMainModulesOptions();

            var baseMenuLogicHandler = new BaseMenuLogicHandler(context);

            baseMenuLogicHandler.InvokeActionBaseOnUserSelection(option);
        }
    }
}
