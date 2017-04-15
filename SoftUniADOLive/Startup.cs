namespace SoftUniADOLive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            // Window initialization
            Console.WindowHeight = 17;
            Console.BufferHeight = 17;
            Console.WindowWidth = 50;
            Console.BufferWidth = 50;

            // DB init 
            var context = new SoftUniEntities();

            //ListAll(context);
            SearchProjectByName(context);

            //comment
            var selectedOption = DisplayProjectMenu();

            NavigateAfterProjectMenuSelection(selectedOption,context);
        }

        private static void NavigateAfterProjectMenuSelection(int selectedOption, SoftUniEntities context)
        {
            if (selectedOption == 1)
            {
                ListAll(context);
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

        }

        private static int DisplayProjectMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select an option");
            Console.WriteLine("1. List all project");
            Console.WriteLine("2. View details for specific project");
            Console.WriteLine("3. Search for project by name");
            Console.WriteLine("4. Assign employees");
            Console.WriteLine("5. Release employees");
            Console.WriteLine("6. Create new project");
            Console.WriteLine("7. Edit project");

            var selectedOption = int.Parse(Console.ReadLine());

            while (selectedOption < 1 || selectedOption > 7)
            {
                Console.Write("Please enter an existing command: ");

                selectedOption = int.Parse(Console.ReadLine());
            }

            return selectedOption;
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

        private static void ListAll(SoftUniEntities context)
        {
            int pageSize = 14;

            var projects = context.Projects.ToList();
            int page = 0;
            int maxPages = (int)Math.Ceiling(projects.Count / (double)pageSize);
            int pointer = 1;

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine($" ID | Project Name (Page {page + 1} of {maxPages})");
                Console.WriteLine("----+----------------------------");

                int current = 1;
                foreach (var proj in projects.Skip(pageSize * page).Take(pageSize))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{proj.ProjectID,4}| {proj.Name}");
                    current++;
                }

                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "Enter":
                        var currentProject = projects.Skip(pageSize * page + pointer - 1).First();
                        ShowDetails(currentProject);
                        Console.WriteLine("Enter pressed");
                        break;
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
