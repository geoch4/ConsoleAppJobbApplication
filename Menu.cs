using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleAppJobbApplication
{
    public class Menu
    {
        private readonly JobManager _jobManager;

        public Menu(JobManager jobManager)
        {
            _jobManager = jobManager; // rätt namn
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Job Application Tracker");
                Console.WriteLine("Menu for Job Applications");
                Console.WriteLine("Steg 1: Registrera ny ansökan");
                Console.WriteLine("Steg 2: Visa alla ansökningar");
                Console.WriteLine("Steg 3: Avsluta");
                Console.WriteLine("Välj ett alternativ");
                string choice = Console.ReadLine();//jag behöver inte deklarera som parameter för att det är en
                                                   //switch case



                switch (choice)
                {
                    case "1":
                        {
                            JobApplication.ApplyForJob();

                            break;

                        }



                    case "2":
                        {                            

                            break;

                        }
                    case "3":
                        {
                            Console.WriteLine("Avslutad");
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Avslutad");
                            return;

                        }


                }
            }
        }
    }
}
