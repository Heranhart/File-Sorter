using System.Windows.Forms;

namespace Console_Sorter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (var damb = new FolderBrowserDialog())
            {
                if (damb.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("good");
                    Console.ReadLine();
                }
            }
        }
    }
}