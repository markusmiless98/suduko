using Suduko.Application.Services;

namespace Suduko
{
    public class Primary
    {
        static void Main(string[] arg)
        {
            Console.Write("Starting...");
            SudukoClass e = new SudukoClass();
            Thread.Sleep(1000);
            Console.WriteLine("Loaded API!");

            Thread.Sleep(2000);

            Console.WriteLine("Loading!");
            Thread.Sleep(3000);

            int i = 0;
            int row = 0;
            foreach (var item in e.SudukoRows)
            {
                string cur = "";

                if (item != "-1")
                {
                    cur = "[" + item + "]";
                }
                else
                {
                    cur = "[ ]";
                }
                if (i % 3 == 0)
                {
                    Console.Write(" | ");
                }
                Console.Write(cur);
                if (i >= 8)
                {
                    i = 0;
                    row++;
                    if (row % 3 == 0)
                    {
                        Console.WriteLine("");
                        Console.Write("-------------------------------------------");
                    }
                    Console.WriteLine("");
                }
                else
                {
                    i++;
                }
            }
        }
    }

}