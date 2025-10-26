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
        public List<JobApplication> Applications = new List<JobApplication>();//skulle vi kunna ha en lista som en variabel?


        //Lägg till från redan skapad class JobApplication så att listan tar info från class JobApplication
        public void AddJob(JobApplication applications)
        {
            Applications.Add(applications);//här ropar man på classen igen
            Console.WriteLine();
            Console.WriteLine("Ansökan registrerad.");
        }



        //Visning av alla ansökningar
        public void ShowAllApplications() //vi döper metoden ShowAllApplication för att förstå vad metoden gör
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

            foreach (var application in Applications)
            {
                if (application.CompanyName.ToLower() == companyName.ToLower())
                {
                    Console.WriteLine("Ange ny status");
                    Console.WriteLine("Status alternativ: 0=Applied, 1= Interview, 2=Offer, 3=Rejected");

                    int statusChoice;
                    while (true)
                    {
                        Console.WriteLine("Välj ny status");
                        if (int.TryParse(Console.ReadLine(), out statusChoice) &&
                            Enum.IsDefined(typeof(Status), statusChoice))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig val, försök igen");
                        }
                    }

                    application.ApplicationStatus = (Status)statusChoice;
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
            var answered = Applications.Where(application => application.ResponseDate != default);//filtrerar bort de utan svarsdatum
            //det kan inte vara samma med null

            if (answered.Any())
            {
                var averageResponseDays = answered.Average(application => (application.ResponseDate - application.ApplicationDate).TotalDays);

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
            Status status = (Status)choice; //denna raden för att vi ska kunna relatera användarens val
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

         
        public void ShowSortedByDate(bool ascending)
        {
            IEnumerable<JobApplication> ordered = ascending
                ? Applications.OrderBy(app => app.ApplicationDate)
                : Applications.OrderByDescending(app => app.ApplicationDate);

              var list = ordered.ToList();
            if(list.Count == 0 )
            {
                Console.WriteLine("inga ansökningar att visa");
                return;
            }
            foreach(var app in ordered)
            {
                    Console.WriteLine(app.GetSummary());
            }

        }

        public void RemoveByCompany(string company)
        {
            if(string.IsNullOrWhiteSpace(company))
            {
                Console.WriteLine("Företaget finns inte.");
                return;
            }
            int removed = Applications.RemoveAll(app =>
            app.CompanyName.Equals(company, StringComparison.OrdinalIgnoreCase));

            if(removed == 0)
            {
                Console.WriteLine("inga ansökningar hitttades för att ta bort");
            }
            else
            {
                Console.WriteLine($"Tog bort {removed} ansökan för företager {company}");
            }

        }

        public void AddJob()
        {
            // ApplyForJob() ska ha signaturen: public static JobApplication ApplyForJob()
            var app = JobApplication.ApplyForJob();
            Applications.Add(app);
            Console.WriteLine("Ansökan är tillagd");
        }


        public void SortApplications()
        {
            Console.WriteLine("Hur vill du sortera");
            Console.WriteLine("1. Äldst till nyast");
            Console.WriteLine("2. Nyast till äldst");
            Console.WriteLine("Välj 1 eller 2");

            string val = Console.ReadLine();

            bool ascending = (val == "1");

           

        }

        private void RemoveJob()
        {
            Console.Write("Ange företagsnamn att ta bort: ");
            string company = Console.ReadLine();
            RemoveByCompany(company);
        }
    } 
   

}

        
    

