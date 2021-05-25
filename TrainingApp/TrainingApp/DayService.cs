using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace TrainingApp
{
    public class DayService
    {
        public List<Day> Days { get; set; }

        public DayService()
        {
            Days = new List<Day>();
        }

        public ConsoleKeyInfo AddNewDayView(MenuActionService actionService)
        {
            var addNewDayMenu = actionService.GetMenuActionsByMenuName("AddNewDayMenu");
            Console.WriteLine("\r\nPlease select type of training");
            for (int i = 0; i < addNewDayMenu.Count; i++)
            {
                Console.WriteLine($"{addNewDayMenu[i].Id}.{addNewDayMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            return operation;

        }

        public int AddNewDay(char trainingType)
        {
            int trainingTypeId;
            Int32.TryParse(trainingType.ToString(), out trainingTypeId);
            Day day = new Day();
            day.TrainingTypeId = trainingTypeId;
            Console.WriteLine("\r\nPlease enter day id for new training day:");
            var id = Console.ReadLine();
            int dayId;
            Int32.TryParse(id, out dayId);
            Console.WriteLine("Please enter status of training for new day: done or missed:");
            var status = Console.ReadLine();

            day.Id = dayId;
            day.Status = status;

            Days.Add(day);

            return dayId;
        }

        public int RemoveDayView()
        {
            Console.WriteLine("\r\nPlease enter id for day you want to remove:");
            var dayId = Console.ReadKey();
            int id;
            Int32.TryParse(dayId.KeyChar.ToString(), out id);
        

            return id;
        }
        public void RemoveDay(int removeId, out int removeTypeTraining)
        {
            Console.WriteLine("\r\nPlease enter Type Training Id you want to delete");
            var removeTypeTrainingId = Console.ReadKey();
            int removeTypeId;
            Int32.TryParse(removeTypeTrainingId.KeyChar.ToString(), out removeTypeId);
            removeTypeTraining = removeTypeId;
            
            Day dayToRemove = new Day();
            foreach (var day in Days)
            {
                if (day.Id == removeId && day.TrainingTypeId == removeTypeTraining)
                {
                    dayToRemove = day;
                    Days.Remove(dayToRemove);
                    break;
                }
            }
        }

        public int DayServiceSelectionView()
        {
            Console.WriteLine("\r\nPlease enter id for day you want to show:");
            var dayId = Console.ReadKey();
            int id;
            Int32.TryParse(dayId.KeyChar.ToString(), out id);

            return id;
        }

        public void DayDetailView(int detailId)
        {
            Day productToShow = new Day();
            foreach (var day in Days)
            {
                if (day.Id == detailId)
                {
                    productToShow = day;

                    Console.WriteLine($"\r\nDay id:{productToShow.Id}");
                    Console.WriteLine($"Day status:{productToShow.Status}");
                    Console.WriteLine($"Training type id:{productToShow.TrainingTypeId}");
                }
            }
        }


        public int TrainingTypeSelectionView()
        {
            Console.WriteLine("Please enter Type id for training you want to show:");
            var dayId = Console.ReadKey();
            int id;
            Int32.TryParse(dayId.KeyChar.ToString(), out id);

            return id;
        }

        public void DaysByTypeIdView(int typeId)
        {
            List<Day> toShow = new List<Day>();
            foreach (var day in Days)
            {
                if (day.TrainingTypeId == typeId)
                {
                    toShow.Add(day);
                }
            }
            Console.WriteLine($"{toShow}");
        }
    }
}
