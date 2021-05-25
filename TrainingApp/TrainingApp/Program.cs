using System;

namespace TrainingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            DayService dayService = new DayService();
            actionService = Initialize(actionService);

            Console.WriteLine("Welcome to training app");
            while (true)
            {
                Console.WriteLine("\r\nPlease let me know what do you want to do:");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}.{mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();

                switch (operation.KeyChar)
                {
                    case '1':
                        var keyInfo = dayService.AddNewDayView(actionService);
                        int id = dayService.AddNewDay(keyInfo.KeyChar);
                        break;
                    case '2':
                        var removeId = dayService.RemoveDayView();
                        int removeTypeTraining;
                        dayService.RemoveDay(removeId, out removeTypeTraining);
                        break;
                    case '3':
                        var detailId = dayService.DayServiceSelectionView();
                        dayService.DayDetailView(detailId);
                        break;
                    case '4':
                        var typeId = dayService.TrainingTypeSelectionView();
                        dayService.DaysByTypeIdView(typeId);
                        break;
                    default:
                        Console.WriteLine("Action you entered doesn't exist");
                        break;
                }
            }
        }
        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add new training day", "Main");
            actionService.AddNewAction(2, "Remove training day", "Main");
            actionService.AddNewAction(3, "Show details", "Main");
            actionService.AddNewAction(4, "Show list of training days", "Main");

            actionService.AddNewAction(1, "Szóstka Weidera", "AddNewDayMenu");
            actionService.AddNewAction(2, "Bicycle training", "AddNewDayMenu");
            return actionService;
        }
    }
}
