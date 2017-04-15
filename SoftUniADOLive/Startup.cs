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

            // DB init 

            //ListAll(context);
            //SearchProjectByName(context);

        
            //var selectedOption = DisplayProjectMenu();

            //NavigateAfterProjectMenuSelection(selectedOption,context);
        }

        private static void NavigateAfterProjectMenuSelection(int selectedOption, SoftUniEntities context)
        {
            if (selectedOption == 1)
            {
                //ListAll(context);
            }
            else if (selectedOption == 2)
            {

            }
            else if (selectedOption == 3)
            {
                SearchProjectByName(context);
            }
            else if (selectedOption == 4)
            {

            }
            else if (selectedOption == 5)
            {

            }
            else if (selectedOption == 6)
            {

            }
            else if (selectedOption == 7)
            {

            }
            else if (selectedOption == 8)
            {

            }
        }



        private static void SearchProjectByName(SoftUniEntities context)
        {
            Console.Write("Please enter project name: ");
            var name = Console.ReadLine();

            var project = context.Projects.FirstOrDefault(p => p.Name == name);

            try
            {
                ShowDetails(project);
            }
            catch (Exception)
            {


            }



        }

        

        static void ShowDetails(Project project)
        {
            if (project == null)
            {
                Console.WriteLine("The project is not existing");
                throw new ArgumentNullException();
            }

            //-------------------------------------------------------
            Console.Clear();
            Console.WriteLine($"ID: {project.ProjectID,4}| {project.Name}");
            Utility.PrintHLine();
            Console.WriteLine(project.Description);
            Utility.PrintHLine();
            Console.WriteLine($"{project.StartDate,-24}| {project.EndDate}");
            Utility.PrintHLine();
            Console.WriteLine($"Page ");
            Console.WriteLine("---------------------------------");
            Console.ReadKey();
            int pageSize = 16 - Console.CursorTop;

            var employees = project.Employees.ToList();
            int page = 0;
            int maxPages = (int)Math.Ceiling(employees.Count / (double)pageSize);
            int pointer = 1;

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine($"ID: {project.ProjectID,4}| {project.Name}");
                Utility.PrintHLine();
                Console.WriteLine(project.Description);
                Utility.PrintHLine();
                Console.WriteLine($"{project.StartDate,-24}| {project.EndDate}");
                Utility.PrintHLine();
                Console.WriteLine($"Page {page + 1} of {maxPages})");
                Console.WriteLine("---------------------------------");

                int current = 1;
                foreach (var emp in employees.Skip(pageSize * page).Take(pageSize))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{emp.FirstName} {emp.LastName}");
                    current++;
                }

                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    /*
                    case "Enter":
                        var currentProject = employees.Skip(pageSize * page + pointer - 1).First();
                        ShowDetails(currentProject);
                        Console.WriteLine("Enter pressed");
                        break; */
                    case "UpArrow":
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        else if (page > 0)
                        {
                            page--;
                            pointer = pageSize;
                        }
                        break;
                    case "DownArrow":
                        if (pointer < pageSize)
                        {
                            pointer++;
                        }
                        else if (page + 1 <= maxPages)
                        {
                            page++;
                            pointer = 1;
                        }
                        break;
                    case "Escape":
                        return;
                }
            }

            //-------------------------------
        }
    }
}
