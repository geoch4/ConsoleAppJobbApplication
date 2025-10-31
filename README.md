Job Application Tracker (C# .NET Console App)

Ett konsolprogram som hjälper användaren att hålla koll på sina jobbansökningar.
Projektet demonstrerar objektorienterad programmering (OOP), listor, enum, LINQ, felhantering och versionshantering via GitHub.

Syfte
Syftet med uppgiften är att visa förståelse för:
- Objektorienterad programmering (klasser, objekt och metoder)
- Användning av samlingar (List)
- Filtrering, sortering och beräkningar med LINQ
- Strukturering av kod i en menybaserad konsolapplikation
-Versionshantering i Git & GitHub med branches och pull requests

Projektbeskrivning
Användaren kan registrera, uppdatera och hantera sina jobbansökningar via ett menysystem i konsolen.
Varje ansökan innehåller information som företag, position, datum, status och lön.
Programmet använder LINQ för att filtrera, sortera och visa statistik, samt färgkodar status för bättre läsbarhet.

Klassöversikt
JobApplication	Representerar en enskild ansökan med information som titel, företag, datum, lön och status. Innehåller metoder för att skapa, visa och beräkna dagar sedan ansökan skickades.
JobManager	Hanterar listan av ansökningar – lägger till, visar, filtrerar, sorterar, visar statistik och färgkodar utskrifter. Innehåller även LINQ-logiken.
Menu	Visar huvudmenyn och kopplar användarens val till rätt metoder i JobManager.
Program	Startar applikationen.

Funktioner

- Lägg till ny ansökan
-Visa alla ansökningar
-Filtrera ansökningar efter status (LINQ)
-Sortera ansökningar efter datum (OrderBy)
-Visa statistik (Count, Average, GroupBy)
-Uppdatera status
-Ta bort ansökan
-Visa ansökningar utan svar äldre än 14 dagar (VG-del)
-Färgkodning av status i konsolen (VG-del)
-Enkel felhantering med TryParse (VG-del)

LINQ-exempel i projektet
// Filtrera efter status
var interviews = Applications.Where(a => a.ApplicationStatus == Status.Interview);

// Sortera efter datum
var ordered = Applications.OrderBy(a => a.ApplicationDate);

// Statistik: genomsnittlig svarstid

Tekniker och koncept
-C# .NET Console Application
-Objektorienterad programmering (klasser, objekt, metoder)
-Enum (Status)
-LINQ (Where, OrderBy, GroupBy, Average)
-Felhantering (TryParse, Any)
-Färgkodning med Console.ForegroundColor
-Git & GitHub med flera branches, pull requests och branch-skydd
var averageResponseTime = Applications
    .Where(a => a.ResponseDate != default)
    .Average(a => (a.ResponseDate - a.ApplicationDate).TotalDays);
