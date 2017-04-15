using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADOLive.SystemModules.ProjectModule.Commands
{
    public class ShowProjectDetails
    {
        private SoftUniEntities context;

        public ShowProjectDetails(SoftUniEntities context)
        {
            this.context = context;
        }
        public void ShowDetails(Project project)
        {
            if (project == null)
            {
                Console.WriteLine("The project is not existing");
                throw new ArgumentNullException();
            }

            //-------------------------------------------------------
            Console.Clear();
            Console.WriteLine($"ID: {project.ProjectID}");
            Console.WriteLine();
            Console.WriteLine($"Project name: {project.Name}");
            Console.WriteLine();
            Console.WriteLine($"Project description: {project.Description}");
            Console.WriteLine();
            Console.WriteLine($"Project start date: {project.StartDate}");
            Console.WriteLine();
            Console.WriteLine($"Project end date: {project.EndDate}");
            Console.WriteLine();

            Console.WriteLine("Employees for current project: ");
            Console.WriteLine();

            foreach (var emp in project.Employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }

            while (true)
            {
                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "Escape":
                        var backCommand = new BackToProjectMenu(context);
                        backCommand.ReturnToBaseMenu();
                        break;
                }
            }
        }
    }
}
