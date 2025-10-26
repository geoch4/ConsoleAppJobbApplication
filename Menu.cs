using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleAppJobbApplication
{
    public class Menu
    {
        private readonly JobManager _manager = new JobManager(); //

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Job Application Tracker");
                Console.WriteLine("Menu for Job Applications");
                Console.WriteLine("Steg 1: Registrera ny ansökan");
                Console.WriteLine("Steg 2: Visa alla ansökningar");
                Console.WriteLine("Steg 3: Filtrera alla ansökningar efter status");
                Console.WriteLine("Steg 4: Sortera alla ansökningar efter datum");
                Console.WriteLine("Steg 5: Visa statistik");
                Console.WriteLine("Steg 6: Uppdatera status på en ansökan");
                Console.WriteLine("Steg 7: Ta bort en ansökan");
                Console.WriteLine("Steg 8: Avsluta programmet");
                Console.WriteLine("Välj ett alternativ (1-8)");
                string choice = Console.ReadLine();//jag behöver inte deklarera som parameter för att det är en
                                                   //switch case

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        {
                            AddJob();

                            break;

                        }



                    case "2":
                        {
                            _manager.ShowAllApplications();

                            break;

                        }
                    case "3":
                        {
                            _manager.ShowByStatus();
                            break;
                        }
                    case "4":
                        {
                            SortApplications();
                            break;
                        }
                    case "5":
                        {
                            _manager.ShowStatistics();
                            break;

                        }
                    case "6":
                        {
                            _manager.UpdateStatus();
                            break;
                        }
                    case "7":
                        {
                            RemoveJob();
                            break;

                        }
                    case "8":
                        {
                            Console.WriteLine("Klar");
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Ogiltigt val, försök igen!");
                            break;

                        }



                }
            }
        }
        private void AddJob()
        {
            // ApplyForJob() ska ha signaturen: public static JobApplication ApplyForJob()
            var app = JobApplication.ApplyForJob();
            _manager.AddJob(app);
        }
       

        private void SortApplications()
        {
            Console.WriteLine("Hur vill du sortera");
            Console.WriteLine("1. Äldst till nyast");
            Console.WriteLine("2. Nyast till äldst");
            Console.WriteLine("Välj 1 eller 2");

            string val = Console.ReadLine();

            bool ascending = (val == "1");
            _manager.ShowSortedByDate(ascending);

        }

        private void RemoveJob()
        {
            Console.Write("Ange företagsnamn att ta bort: ");
            string company = Console.ReadLine();
            _manager.RemoveByCompany(company);
        }

    }
}

