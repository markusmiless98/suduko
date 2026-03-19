using Suduko.Application.Services;

namespace Suduko
{
    public class ApplicationTranslator
    {
        static void Main(string[] arg)
        {
            Console.Write("Starting...");
            SudukoClass e = new SudukoClass();
            Thread.Sleep(500);
            Console.WriteLine("Loaded API!");

            Thread.Sleep(1000);

            Console.WriteLine("Loading!");
            Thread.Sleep(1500);
            WriteSuduko(e);
        }
        private static async void WriteSuduko(SudukoClass e)
        {
            List<string> suduko = await e.WriteSuduko();
            Thread.Sleep(2000);

            foreach (var item in suduko)
            {
                Console.WriteLine(item);
            }
        }
    }

}