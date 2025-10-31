


namespace ConsoleAppJobbApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            JobManager jobManager = new JobManager();
            Menu menu = new Menu(); // vi skickar in JobManager till menyn
            menu.ShowMainMenu();
            JobManager AddJob = new JobManager();
            JobManager RemoveJob = new JobManager();
            JobManager SortApplications = new JobManager();

        }
    }
}


                   