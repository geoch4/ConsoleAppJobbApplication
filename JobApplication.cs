using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppJobbApplication
{
    public class JobApplication
    { //JobApplication – representerar en enskild ansökan.

        //skapa variablerna/egenskaperna
        public string PositionTitle { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public string CompanyName { get; set; }
        public int SalaryExpectation { get; set; }
        public Status ApplicationStatus { get; set; }
                                                     
        //ApplicationStatus är ett egenskap av typen Status (enum)

        public enum Status
        {
            Applied = 0,
            Interview = 1,
            Offer = 2,
            Rejected = 3
        } // enum för status

        //skapa kontruktor med alla parametrar

        public JobApplication(string positionTitle, DateTime applicationDate, DateTime responseDate, string companyName,
         int salaryExpectation, Status status) // varför när vi skapar parametrarna är stora bokstäver
                                               // och när vi lägger in dem i konstruktor då blir det små???- Status status
                                               // kunde inte vara Status applicationStatus istället?
        {
            //objekt
            PositionTitle = positionTitle; //skapar objekt med this?
            ResponseDate = responseDate;
            CompanyName = companyName;
            SalaryExpectation = salaryExpectation;
            ApplicationStatus = status;
            ApplicationDate = applicationDate;// kan vi byta till det här: ApplicationDate = DateTime.Now 
                                             //ApplicationStatus = Status.Applied
        }

        public static void ApplyForJob() //metod för att skicka in ansökan
        { 
            //Registrera ny ansökan 
            Console.WriteLine("Ange Positionstitel:");
            string position = Console.ReadLine();

            Console.WriteLine("Ange företagsnamn:");
            string company = Console.ReadLine();

            int salary; //vi skapar en lokal variabel här

            while (true)
            {

                Console.WriteLine("Ange löneanspråk (heltal): ");

                if (int.TryParse(Console.ReadLine(), out salary)) 
                    break;
                Console.WriteLine("Ogiltigt tal. Försök igen.");
            }

            DateTime applicationDate; //skapar en lokal variabel här

            while (true)
            {
                Console.Write("Ange ansökningsdatum (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out applicationDate)) break;
                Console.WriteLine("Ogiltigt datum. Försök igen (format yyyy-MM-dd).");
            }


            //på status-ropar på enum från classen
            Console.WriteLine("Ange status i ansökan(0-3)");
            Console.WriteLine("Status alternativ: 0=Applied, 1= Interview, 2=Offer, 3=Rejected");//kan man inte bara ropa
            JobApplication.Status status;
            while (true)
            {
                Console.Write("Ange status (0-3): ");
                if (int.TryParse(Console.ReadLine(), out int statusChoice) &&
                    Enum.IsDefined(typeof(JobApplication.Status), statusChoice))
                {
                    status = (JobApplication.Status)statusChoice;
                    break;
                }
                Console.WriteLine("Ogiltigt val. Ange 0, 1, 2 eller 3.");
            }
            DateTime responseDate;
            while (true)
            {
                Console.Write("Ange svardatum (yyyy-MM-dd): ");//fattar inte
                if (DateTime.TryParse(Console.ReadLine(), out responseDate)) break;
                Console.WriteLine("Ogiltigt datum. Försök igen (format yyyy-MM-dd).");
            }

            var newApp = new JobApplication(
            
                position,
                applicationDate,
                responseDate,
                company,
                salary,
                status);



            Console.WriteLine("Ansökan klar");

        }

        public int GetDaysSinceApplied()
        { //skapa en metod som räknar ut antal dagar sedan ansökan skickades in
            int daysSinceApplied = (DateTime.Now - ApplicationDate).Days;
            return daysSinceApplied;
            // int GetDaysSinceApplied = 0;, i vilka fall används detta
        }
        public string GetSummary() //metod för att returnerar en kort sammanfattning av ansökan.
        {
            string GetSummary = ($"Position: {PositionTitle}, Company: {CompanyName}, Applied on: {ApplicationDate}, " +
            $"" + $"Status: {ApplicationStatus}"); 
            return GetSummary;

        }

    }
}

