using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppJobbApplication
{
    public class JobManager
    {
        //JobManager – ansvarar för att hantera alla ansökningar (listan, logik och LINQ).
        public List<JobApplication> Applications = new List<JobApplication>();


        //Lägg till från redan skapad class JobApplication så att listan tar info från class JobApplication
        public void AddJob(JobApplication applications)
        {
            Applications.Add(applications);//här ropar man på classen igen
            Console.WriteLine();
            Console.WriteLine("Ansökan registrerad.");
        }



        //Visning av alla ansökningar
        public  void ShowAllApplication() //vi döper metoden ShowAllApplication för att förstå vad metoden gör
        {

            if (Applications.Count == 0) //== betyder "lika med"-exakt-annat sätt att formulera i kodform?
            {
                Console.WriteLine("Inga ansökningar registrerade.");
                return;


            }

            else foreach (var application in Applications)
                {
                    Console.WriteLine(application.GetSummary()); //anropar metoden GetSummary från class JobApplication
                }

        }
        public void UpdateStatus()//skapa metod för att uppdatera status på ansökan 
        {
            Console.WriteLine("Ange företagsnamn för att uppdatera status:");
            string companyName = Console.ReadLine();

            foreach(var application in Applications)
            {
                if (application.CompanyName.ToLower() == companyName.ToLower())
                {
                    Console.WriteLine("Ange ny status");
                    Console.WriteLine("Status alternativ: 0=Applied, 1= Interview, 2=Offer, 3=Rejected");

                    int statusChoice;
                    while(true)
                    {
                        Console.WriteLine("Välj ny status");
                        if(int.TryParse(Console.ReadLine(), out statusChoice) &&
                            Enum.IsDefined(typeof(JobApplication.Status), statusChoice))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig val, försök igen");
                        }
                    }

                    application.ApplicationStatus = (JobApplication.Status)statusChoice;
                    Console.WriteLine($"Status uppdaterad för {companyName} till {application.ApplicationStatus}");
                }
            }

            
        }

        public void ShowStatistics() //får utgå ifrån att det är statistik för antal ansökningar
        {
            Console.WriteLine("Visa statistik");
            Console.WriteLine($"Totalt antal ansökningar: {Applications.Count}");// totalt antal ansökningar som finns  

            //antal ansökningar per status-filtrering
            var statusGroups = Applications

                .GroupBy(application => application.ApplicationStatus) //gruppera efter status först-application(alla ansökningar)
                .Select(group => new { Status = group.Key, Count = group.Count() }) //sorterar grupperna först och skapar
                                                                                    //små sammanfattande objekt med status och antal
                .OrderBy(x => x.Status);//sorterar alfabetiskt efter status(från A-B)-x en variabel vi döper

            //skriv ut resultat med Console.WriteLine
            Console.WriteLine("\nAntal per status:");

            foreach (var group in statusGroups)
            {
                Console.WriteLine($"{group.Status}: {group.Count}");
            }

            //genomsnittligt svarstid
            var answered = Applications.Where(application => application.ResponseDate != null);//filtrerar bort de utan svarsdatum

            if (answered.Any())
            {
                var averageResponseDays = answered.Average(application=> (application.ResponseDate - application.ApplicationDate).TotalDays);
                   
                Console.WriteLine($"\nGenomsnittlig svarstid: {averageResponseDays} dagar");
            }
            else
            {
                Console.WriteLine("\nInga besvarade ansökningar för att beräkna genomsnittlig svarstid.");
            }
        }

        public void ShowByStatus()
        {  //status kommer från användaren som skriver t.ex. applied)
            Console.WriteLine("Ange status för filtrering(0=Applied, 1=Interview, 2=Offer, 3=Rejected):");
            Console.WriteLine("Ange siffra 0-3");
          
            int choice = int.Parse(Console.ReadLine()); //skapar en lokal variabel-choice
            JobApplication.Status status = (JobApplication.Status)choice; //denna raden för att vi ska kunna relatera användarens val
                                                                          //till status-syftet med det är att vi ska vara medvetna om vad
                                                                          //valet(choice) handlar om




            //1. filtrera listan med LINQ-börja med Where
            var resultOfList = Applications.Where(application => application.ApplicationStatus == status);
            //relaterad till application(namnet vi ger)


            //2. om resultatet är tomt, visa meddelande

            if (!resultOfList.Any()) //Any-inbyggd metod-ifall det finns något i listan, ! betyder "inte"
            {
                Console.WriteLine("Inga ansökningar med den angivna statusen hittades.");
                return; //returnerar svaret jag får
            }
            //3. annars visa sammanfattning för varje ansökan i resultatet-skriv ut träffarna
            
            else foreach (var app in resultOfList)
            {
                    Console.WriteLine($"Ansökningar med status:");
                    Console.WriteLine(app.GetSummary());
                   
                }


        }
    }

}