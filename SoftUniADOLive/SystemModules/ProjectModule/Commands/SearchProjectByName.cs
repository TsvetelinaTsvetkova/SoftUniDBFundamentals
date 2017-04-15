using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive.SystemModules.ProjectModule.Commands
{
   public class SearchProjectByName
    {
        private SoftUniEntities context;

        public SearchProjectByName(SoftUniEntities context)
        {
            this.context = context;
        }

        public void Search()
        {
            Console.Clear();
            Console.Write("Please enter a project name: ");

            var name = Console.ReadLine();

            var project = context.Projects.FirstOrDefault(p => p.Name == name);

            if (project == null)
            {

            }

            var showProjectDetails = new ShowProjectDetails(context);
            showProjectDetails.ShowDetails(project);
        }
    }
}
