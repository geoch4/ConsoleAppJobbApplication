using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppJobbApplication
{
    public enum Status //enum utanför klassen för bättre återanvändbarhet
    {
        Applied = 0,
        Interview = 1,
        Offer = 2,
        Rejected = 3
    } 

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

        public static JobApplication ApplyForJob() //metod för att skicka in ansökan-skapar en metod här så att vi håller det kort och
                                         //rent på Program.cs
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

            DateTime applicationDate; //skapar en lokal variabel här-i vilket syfte? varför kopplas inte till konstruktor?

            while (true)
            {
                Console.Write("Ange ansökningsdatum (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out applicationDate)) 
                    break;
                Console.WriteLine("Ogiltigt datum. Försök igen (format yyyy-MM-dd).");
            }


            //på status-ropar på enum från classen-kan vi inte börja annorlunda här?
            Console.WriteLine("Ange status i ansökan(0-3)");
            Console.WriteLine("Status alternativ: 0=Applied, 1= Interview, 2=Offer, 3=Rejected");//kan man inte bara ropa

            Status status; 
            while (true)
            {
                Console.Write("Ange status (0-3): ");
                if (int.TryParse(Console.ReadLine(), out int statusChoice) &&
                    Enum.IsDefined(typeof(Status), statusChoice))
                {
                    status = (Status)statusChoice;
                    break;
                }
                Console.WriteLine("Ogiltigt val. Ange 0, 1, 2 eller 3.");
            }
            DateTime responseDate;//skapar lokal variabel här med?
            while (true)
            {
                Console.Write("Ange svardatum (yyyy-MM-dd): ");//fattar inte
                if (DateTime.TryParse(Console.ReadLine(), out responseDate)) break;
                Console.WriteLine("Ogiltigt datum. Försök igen (format yyyy-MM-dd).");
            }

            Console.WriteLine("Ansökan klar");




            return new JobApplication(
                position,
                applicationDate,
                responseDate,
                company,
                salary,
                status
   )            ;






        }

        public int GetDaysSinceApplied()
        { //skapa en metod som räknar ut antal dagar sedan ansökan skickades in
            int daysSinceApplied = (DateTime.Now - ApplicationDate).Days;
            return daysSinceApplied;
            // int GetDaysSinceApplied = 0;, i vilka fall används detta
        }
        public string GetSummary() //metod för att returnerar en kort sammanfattning av ansökan.
        {
            string summary = ($"Position: {PositionTitle}, Company: {CompanyName}, Applied on: {ApplicationDate}, " +
            $"" + $"Status: {ApplicationStatus}"); 
            return summary; //returnerar stringen, inte själva metoden

        }
        //lokala variabler
        //konstruktor tar emot data
        //kompilatorn
        //variabelnamn/typnamn-skillnader
        //debugging-felhantering-skillnader
        //Namngivning: PascalCase för egenskaper, camelCase för parametrar
        //TryParse och TryParseExact-skillnader
    }
}

