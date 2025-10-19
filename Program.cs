


namespace ConsoleAppJobbApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            JobManager jobManager = new JobManager();
            Menu menu = new Menu(jobManager); // vi skickar in JobManager till menyn
            menu.ShowMenu();


        }
    }
}


                   