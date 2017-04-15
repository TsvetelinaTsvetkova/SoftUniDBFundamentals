namespace SoftUniADOLive.SystemModules.ProjectModule.Commands
{
    public class BackToProjectMenu
    {
        private SoftUniEntities context;

        public BackToProjectMenu(SoftUniEntities context)
        {
            this.context = context;
        }
        public void ReturnToBaseMenu()
        {
            var projectMenu = new ProjectMenu();
            int userSelection = projectMenu.DisplayProjectMenu();

            var projectMenuLogicHolder = new ProjectMenuLogicHandler(context);

            projectMenuLogicHolder.HandlerProjectMenuCommand(userSelection);
        }
    }
}
